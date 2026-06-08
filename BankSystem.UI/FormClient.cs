using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.UI
{
    public partial class FormClient : Form
    {
        private readonly ClientController _clientController;
        private readonly TransactionController _transactionController;
        private readonly SystemLogController _logController;
        private readonly User _currentClientUser;
        private Client _clientProfile;
        public FormClient()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public FormClient(User loggedInClient)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _clientController = new ClientController();
            _transactionController = new TransactionController();
            _logController = new SystemLogController();
            _currentClientUser = loggedInClient;
        }
        private async void FormClient_Load(object sender, EventArgs e)
        {
            if (_currentClientUser == null || _currentClientUser.Client == null)
            {
                MessageBox.Show("Грешка при автентикацията! Няма зареден клиентски профил.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            await RefreshClientData();
        }

        private void LoadAccountsToComboBox()
        {
            if (_clientProfile != null && _clientProfile.Accounts != null)
            {
                var accountsForCombo = _clientProfile.Accounts.ToList();

                MyAccountsComboBox.DataSource = accountsForCombo;
                MyAccountsComboBox.DisplayMember = "IBAN";
                MyAccountsComboBox.ValueMember = "AccountID";
            }
        }
        private async Task RefreshClientData()
        {
            try
            {
                _clientProfile = await _clientController.GetClientByEgn(_currentClientUser.Client.EGN);

                if (_clientProfile != null)
                {
                    dgvAccounts.DataSource = null;
                    MyAccountsComboBox.DataSource = null;

                    lblClientName.Text = $"Име: {_clientProfile.FirstName} {_clientProfile.LastName}";
                    lblClientEgn.Text = $"ЕГН: {_clientProfile.EGN}";
                    lblClientPhone.Text = $"Телефон: {_clientProfile.Phone}";

                    LoadAccountsToComboBox();

                    var accountsList = _clientProfile.Accounts.Select(a => new
                    {
                        Номер = a.AccountID,
                        IBAN = a.IBAN,
                        Баланс = $"{a.Balance:F2} {a.Currency}"
                    }).ToList();

                    dgvAccounts.DataSource = accountsList;
                    dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Не беше намерен съответстващ клиентски профил за този потребител в базата данни.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при опресняване на данните: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnClientTransfer_Click(object sender, EventArgs e)
        {
            // ЗАЩИТА: Вместо "as Account", взимаме директно SelectedValue благодарение на ValueMember
            if (MyAccountsComboBox.SelectedValue == null || !(MyAccountsComboBox.SelectedValue is int sourceAccountId))
            {
                MessageBox.Show("Моля, изберете валидна Ваша сметка от падащото меню!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string toIban = RecipientIbanTextBox.Text.Trim();
            if (string.IsNullOrEmpty(toIban))
            {
                MessageBox.Show("Моля, въведете IBAN на получателя!", "Празно поле", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(AmountTextBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, въведете валидна положителна сума за превода!", "Невалидна сума", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sourceIbanText = MyAccountsComboBox.Text;

                await _transactionController.TransferMoney(sourceAccountId, toIban, amount);

                await _logController.LogAction(_currentClientUser.UserID,
                    $"Клиентът извършил превод на стойност {amount:F2} от сметка с IBAN {sourceIbanText} към {toIban}.");

                MessageBox.Show("Транзакцията беше обработена успешно!", "Успешен превод", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AmountTextBox.Clear();
                RecipientIbanTextBox.Clear();

                await RefreshClientData();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Невалидни данни", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Бизнес правило", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\nДетайли: " + ex.InnerException.Message;
                }
                MessageBox.Show($"Транзакцията пропадна:\n{errorMessage}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //if (_transactionController == null)
            //{
            //    MessageBox.Show("Грешка: TransactionController не е инициализиран!");
            //    return;
            //}

            //var sourceAcc = MyAccountsComboBox.SelectedItem as Account;
            //if (sourceAcc == null)
            //{
            //    MessageBox.Show($"Избраният елемент не е Account. Избрано: {MyAccountsComboBox.SelectedItem?.GetType().Name ?? "null"}");
            //    return;
            //}

            //string toIban = RecipientIbanTextBox.Text?.Trim();

            //if (string.IsNullOrEmpty(toIban))
            //{
            //    MessageBox.Show("Моля, въведете IBAN на получател!");
            //    return;
            //}

            //if (!decimal.TryParse(AmountTextBox.Text, out decimal amount) || amount <= 0)
            //{
            //    MessageBox.Show("Моля, въведете валидна положителна сума!");
            //    return;
            //}

            //try
            //{
            //    await _transactionController.TransferMoney(sourceAcc.AccountID, toIban, amount);
            //    MessageBox.Show("Преводът е успешен!");

            //    AmountTextBox.Clear();
            //    RecipientIbanTextBox.Clear();
            //    await RefreshClientData();
            //}
            //catch (Exception ex)
            //{
            //    string errorMessage = ex.Message;
            //    if (ex.InnerException != null)
            //    {
            //        errorMessage += "\n\nДетайли: " + ex.InnerException.Message;
            //    }
            //    MessageBox.Show($"Грешка в базата/логиката: {errorMessage}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ////await RefreshClientData();
        }
        
    }
}
