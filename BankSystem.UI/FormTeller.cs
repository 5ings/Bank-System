using BankSystem.Controller;
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
        private User _tellerUser;
        private readonly ClientController _clientController;
        private readonly UserController _userController;
        private readonly TransactionController _transactionController;
        private readonly SystemLogController _logController;
        private readonly User _currentTeller;
        public FormTeller()
        {
            InitializeComponent();
        }

        public FormTeller(User loggedInTeller)
        {
            InitializeComponent();
            _clientController = new ClientController();
            _userController = new UserController();
            _transactionController = new TransactionController();
            _logController = new SystemLogController();
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
                    ClientID = newClient.ClientID
                };

                await _userController.CreateUser(newClientUser);

                MessageBox.Show($"Клиентът {newClient.FirstName} {newClient.LastName} и неговият профил за онлайн банкиране бяха създадени успешно!",
                                "Успешна регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearRegistrationFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Регистрацията пропадна! Възможно е ЕГН-то, Имейлът или Потребителското име вече да съществуват в базата данни.\nДетайли: {ex.Message}",
                                "Системна дупликация", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (account == null)
                {
                    MessageBox.Show("Не съществува сметка с такъв IBAN!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await _transactionController.DepositMoney(account.AccountID, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Касиер {_currentTeller.Username} внесе {amount:F2} лв. по IBAN {sourceIban}.");
                MessageBox.Show($"Успешно внесени {amount:F2} лв.!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (account == null)
                {
                    MessageBox.Show("Не съществува сметка с такъв IBAN!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                await _transactionController.WithdrawMoney(account.AccountID, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Касиер {_currentTeller.Username} изтегли {amount:F2} лв. от IBAN {sourceIban}.");
                MessageBox.Show($"Успешно изтеглени {amount:F2} лв.!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var targetAccount = await _transactionController.GetAccountByIban(targetIban);

                if (sourceAccount == null || targetAccount == null)
                {
                    MessageBox.Show("Един от въведените IBAN-и не съществува!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                await _transactionController.TransferMoney(sourceAccount.AccountID, txtTargetIban.Text, amount);

                await _logController.LogAction(_currentTeller.UserID, $"Превод на {amount:F2} лв. от IBAN {sourceIban} към IBAN {targetIban}.");
                MessageBox.Show("Преводът беше изпълнен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Clear();
                txtTargetIban.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при превода: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
