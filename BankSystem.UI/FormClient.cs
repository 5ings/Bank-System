using BankSystem.Controller;
using BankSystem.Data.Entities;
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
        }
        public FormClient(User loggedInClient)
        {
            InitializeComponent();
            _clientController = new ClientController();
            _transactionController = new TransactionController();
            _logController = new SystemLogController();
            _currentClientUser = loggedInClient;
        }
        private async void FormClient_Load(object sender, EventArgs e)
        {
            await RefreshClientData();
        }

        private async Task RefreshClientData()
        {
            try
            {
                _clientProfile = await _clientController.GetClientByEgn(_currentClientUser.Client.EGN);

                if (_clientProfile != null)
                {
                    lblClientName.Text = $"Име: {_clientProfile.FirstName} {_clientProfile.LastName}";
                    lblClientEgn.Text = $"ЕГН: {_clientProfile.EGN}";
                    lblClientPhone.Text = $"Телефон: {_clientProfile.Phone}";

                    if (_clientProfile.Accounts != null)
                    {
                        var accountsList = _clientProfile.Accounts.Select(a => new
                        {
                            Номер = a.AccountID,
                            IBAN = a.IBAN,
                            Баланс = $"{a.Balance:F2} лв."
                        }).ToList();

                        dgvAccounts.DataSource = accountsList;
                    }
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
            string fromIban = txtFromIban.Text.Trim();
            string toIban = txtToIban.Text.Trim();

            if (string.IsNullOrEmpty(fromIban) || string.IsNullOrEmpty(toIban))
            {
                MessageBox.Show("Моля, попълнете правилно и двата IBAN адреса!", "Празни полета", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtClientAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Моля, въведете валидна положителна сума за превода!", "Невалидна сума", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sourceAcc = await _transactionController.GetAccountByIban(fromIban);

                if (sourceAcc == null)
                {
                    MessageBox.Show("Въведеният от Вас изходящ IBAN не съществува в системата!", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sourceAcc.ClientID != _clientProfile.ClientID)
                {
                    MessageBox.Show("Нямате правомощия да извършвате транзакции от сметка, която не е Ваша собственост!", "Отказ за достъп", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                await _transactionController.TransferMoney(sourceAcc.AccountID, toIban, amount);

                await _logController.LogAction(_currentClientUser.UserID, $"Клиентът извърши онлайн превод на стойност {amount:F2} лв. от IBAN {fromIban} към IBAN {toIban}.");

                MessageBox.Show("Транзакцията беше обработена успешно през дигиталния Ви офис!", "Успешен превод", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtClientAmount.Clear();
                txtToIban.Clear();

                await RefreshClientData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Транзакцията пропадна:\n{ex.Message}", "Неуспешен трансфер", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
