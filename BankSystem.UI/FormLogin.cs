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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.UI
{
    public partial class FormLogin : Form
    {
        private readonly UserController _userController;
        private readonly SystemLogController _logController;
        public FormLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _userController = new UserController();
            _logController = new SystemLogController();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Моля, попълнете потребителско име и парола преди да продължите!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User loggedUser = await _userController.LoginUser(username, password);

                if (loggedUser != null)
                {
                    await _logController.LogAction(loggedUser.UserID, $"Успешен вход в системата на потребител: {loggedUser.Username}.");

                    MessageBox.Show($"Успешен вход! Добре дошли, {loggedUser.Username}.",
                                    "Добре дошли", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form nextForm = null;

                    switch (loggedUser.Role)
                    {
                        case UserRole.Admin:
                            nextForm = new FormAdmin(loggedUser);
                            break;

                        case UserRole.Teller:
                            nextForm = new FormTeller(loggedUser);
                            break;

                        case UserRole.Client:
                            if (loggedUser.ClientID != null)
                            {
                                nextForm = new FormClient(loggedUser);
                            }
                            else
                            {
                                MessageBox.Show("Грешка: Профилът ви не е свързан с реално досие на клиент!",
                                                "Критична грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;

                        default:
                            MessageBox.Show("Непозната потребителска роля в системата!",
                                            "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    if (nextForm != null)
                    {
                        this.Hide();

                        nextForm.ShowDialog();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Грешно потребителско име или парола! Опитайте отново.",
                                    "Неуспешен вход", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Достъпът отказан", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
