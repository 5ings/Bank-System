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

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAccountId.Text, out int accountId)) //yjrfmhyf
            {
                MessageBox.Show("Моля, въведете валидно ID на сметката на клиента!", "Невалидна сметка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Б. Проверка дали въведената сума е число и дали е положително
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, въведете валидна положителна сума за внасяне!", "Невалидна сума", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Извикваме логиката от TransactionController
                await _transactionController.DepositAsync(accountId, amount);

                // Записваме транзакцията в системния одит лог
                await _userController.LogActionAsync(_currentTeller.UserID, $"Касиер {_currentTeller.Username} внесе {amount:F2} лв. по сметка с ID {accountId}.");

                MessageBox.Show($"Успешно внесени {amount:F2} лв. по сметка №{accountId}!", "Успешен депозит", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Clear();
            }
            catch (Exception ex)
            {
                // Тук Entity Framework ще ни върне грешка, ако сметката не съществува
                MessageBox.Show($"Операцията беше отказана!\nПричина: {ex.Message}", "Грешка при депозит", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
