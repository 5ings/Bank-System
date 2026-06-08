using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.UI
{
    public partial class FormTeller : Form
    {
        private readonly ClientController _clientController;
        private readonly UserController _userController;
        private readonly TransactionController _transactionController;
        private readonly SystemLogController _logController;
        private readonly AccountController _accountController;
        private readonly BankCardController _cardController;
        private readonly User _currentTeller;
        public FormTeller()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public FormTeller(User loggedInTeller)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            BankDbContext dbContext = new BankDbContext();

            _clientController = new ClientController(dbContext);
            _userController = new UserController();
            _transactionController = new TransactionController();
            _logController = new SystemLogController();

            _accountController = new AccountController();
            _cardController = new BankCardController();

            _currentTeller = loggedInTeller;
        }
        private void FormTeller_Load(object sender, EventArgs e)
        {

        }

        private async void btnRegisterClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
        string.IsNullOrWhiteSpace(txtEGN.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
        string.IsNullOrWhiteSpace(txtClientUsername.Text) || string.IsNullOrWhiteSpace(txtClientPassword.Text))
            {
                MessageBox.Show("Всички полета са задължителни за регистрация на клиент!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string egn = txtEGN.Text.Trim();
            if (egn.Length != 10 || !long.TryParse(egn, out _))
            {
                MessageBox.Show("Невалидно ЕГН! Трябва да съдържа точно 10 цифри.", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Моля, въведете валиден имейл адрес!", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txtClientPassword.Text.Trim();
            if (password.Length < 5)
            {
                MessageBox.Show("Паролата за онлайн банкиране на клиента трябва да е поне 5 символа!", "Слаба парола", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Client newClient = new Client
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    EGN = egn,
                    Phone = txtPhone.Text.Trim(),
                    Email = email
                };

                await _clientController.CreateClient(newClient);

                User newClientUser = new User
                {
                    Username = txtClientUsername.Text.Trim(),
                    PasswordHash = password,
                    Role = UserRole.Client,
                    ClientID = newClient.ClientID,
                    IsActive = true
                };

                await _userController.CreateUser(newClientUser);

                if (_currentTeller != null)
                {
                    await _logController.LogAction(_currentTeller.UserID, $"Касиер {_currentTeller.Username} регистрира нов клиент: {newClient.FirstName} {newClient.LastName}.");
                }

                MessageBox.Show($"Клиентът {newClient.FirstName} {newClient.LastName} и профилът му бяха създадени успешно!",
                                "Успешна регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearRegistrationFields();
            }
            catch (Exception ex)
            {
                Exception realError = ex;
                while (realError.InnerException != null)
                {
                    realError = realError.InnerException;
                }

                MessageBox.Show($"Регистрацията пропадна!\n\nДетайли: {realError.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearRegistrationFields()
        {
            txtFirstName.Clear(); txtLastName.Clear(); txtEGN.Clear();
            txtPhone.Clear(); txtEmail.Clear(); txtClientUsername.Clear(); txtClientPassword.Clear();
        }

        private async void btnDeposit_Click(object sender, EventArgs e)
        {
            string sourceIban = txtSourceIban.Text.Trim();

            if (string.IsNullOrEmpty(sourceIban) || !decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, въведете валиден IBAN и положителна сума!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var account = await _transactionController.GetAccountByIban(sourceIban);
                if (account == null) return;

                await _transactionController.DepositMoney(account.AccountID, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Касиер {_currentTeller.Username} внесе {amount:F2} {account.Currency} по IBAN {sourceIban}.");
                MessageBox.Show($"Успешно внесени {amount:F2} {account.Currency}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                txtSourceIban.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при депозит: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnWithdraw_Click(object sender, EventArgs e)
        {
            string sourceIban = txtSourceIban.Text.Trim();

            if (string.IsNullOrEmpty(sourceIban) || !decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, въведете валиден IBAN и положителна сума!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var account = await _transactionController.GetAccountByIban(sourceIban);
                if (account == null) return;

                await _transactionController.WithdrawMoney(account.AccountID, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Касиер {_currentTeller.Username} изтегли {amount:F2} {account.Currency} от IBAN {sourceIban}.");
                MessageBox.Show($"Успешно изтеглени {amount:F2} {account.Currency}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                txtSourceIban.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при теглене: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            string sourceIban = txtSourceIban.Text.Trim();
            string targetIban = txtTargetIban.Text.Trim();

            if (string.IsNullOrEmpty(sourceIban) || string.IsNullOrEmpty(targetIban) || !decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, попълнете двата IBAN-а и валидна сума!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sourceAccount = await _transactionController.GetAccountByIban(sourceIban);

                await _transactionController.TransferMoney(sourceAccount.AccountID, targetIban, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Касиерски превод на {amount:F2} {sourceAccount.Currency} от IBAN {sourceIban} към IBAN {targetIban}.");
                MessageBox.Show("Преводът беше изпълнен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAmount.Clear();
                txtSourceIban.Clear();
                txtTargetIban.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при превода: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            this.Close();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string egn = EgnTextBox.Text.Trim();
            string selectedCurrency = CurrencyComboBox.Text;
            string selectedCardType = CardTypeComboBox.Text;

            if (string.IsNullOrEmpty(egn) || string.IsNullOrEmpty(selectedCurrency) || string.IsNullOrEmpty(selectedCardType))
            {
                MessageBox.Show("Моля, въведете ЕГН на клиента, изберете Валута и Тип карта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(BalanceTextBox.Text, out decimal initialBalance) || initialBalance < 0)
            {
                MessageBox.Show("Моля, въведете валиден начален баланс (равен или по-голям от 0)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var client = await _clientController.GetClientByEgn(egn);
                if (client == null)
                {
                    MessageBox.Show("Няма регистриран клиент с такова ЕГН в системата!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Account newAccount = new Account
                {
                    ClientID = client.ClientID,
                    Balance = initialBalance,
                    Currency = selectedCurrency
!
                };
                await _accountController.CreateAccount(newAccount);

                CardType cardType = (CardType)Enum.Parse(typeof(CardType), selectedCardType);

                BankCard newCard = new BankCard
                {
                    AccountID = newAccount.AccountID,
                    CardType = cardType
                };
                await _cardController.CreateBankCard(newCard);

                await _logController.LogAction(_currentTeller.UserID,
                    $"Създадена нова сметка ({newAccount.IBAN}) и {cardType} карта за клиент {client.FirstName} {client.LastName}.");

                MessageBox.Show($"Успешно генериран IBAN: {newAccount.IBAN}\nУспешно издадена дебитна карта!\n\nЗаписано в профила на {client.FirstName} {client.LastName}.",
                                "Успешна операция", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проблем при автоматичното генериране: {ex.Message}", "Грешка при запис", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            EgnTextBox.Clear();
            BalanceTextBox.Clear();
            CurrencyComboBox.SelectedIndex = -1;
            CardTypeComboBox.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
