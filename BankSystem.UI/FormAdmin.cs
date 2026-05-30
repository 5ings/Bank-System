using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
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
    public partial class FormAdmin : Form
    {
        private User _adminUser;
        private UserController _userController;
        private UserController UserController => _userController ??= new UserController();

        private SystemLogController _logController;
        private SystemLogController LogController => _logController ??= new SystemLogController();
        public FormAdmin(User loggedUser)
        {
            InitializeComponent();
            _adminUser = loggedUser;
        }
        public FormAdmin()
        {
            InitializeComponent();
            _userController = new UserController();
            _logController = new SystemLogController();

        }


        private async void FormAdmin_Load(object sender, EventArgs e)
        {
            await RefreshDataAndLogs();
            dgvUsers.ReadOnly = false;

            if (dgvUsers.Columns["IsActive"] != null)
            {
                dgvUsers.Columns["IsActive"].ReadOnly = false;
            }

            await RefreshDataAndLogs();
        }

        private async System.Threading.Tasks.Task RefreshDataAndLogs()
        {
            try
            {
                List<User> users = await this.UserController.GetAllUsers();

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;

                if (dgvUsers.Columns["PasswordHash"] != null)
                    dgvUsers.Columns["PasswordHash"].Visible = false;

                List<SystemLog> logs = await this.LogController.GetAllLogs();

                dgvLogs.DataSource = null;
                dgvLogs.DataSource = logs;

                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при опресняване на данните: {ex.Message}", "Системна грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Моля, попълнете потребителско име и парола за новия касиер!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Паролата за служител трябва да бъде поне 4 символа!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User newTeller = new User
                {
                    Username = username,
                    PasswordHash = password,
                    Role = UserRole.Teller,
                    ClientID = null
                };

                await _userController.CreateUser(newTeller);

                MessageBox.Show($"Успешно създаден нов профил на касиер: {username}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNewUsername.Clear();
                txtNewPassword.Clear();

                await RefreshDataAndLogs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неуспешно създаване! Потребителското име вероятно вече съществува.\nДетайли: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Моля, изберете потребител от таблицата, който искате да изтриете!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User selectedUser = (User)dgvUsers.CurrentRow.DataBoundItem;

            if (selectedUser.Username.ToLower() == "admin")
            {
                MessageBox.Show("Критична системна защита: Не можете да изтриете главния администраторски профил!", "Отказ за изтриване", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show($"Сигурни ли сте, че искате окончателно да изтриете профила на {selectedUser.Username}?",
                                                  "Потвърждение за изтриване", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                try
                {
                    await _userController.DeleteUser(selectedUser.UserID);
                    MessageBox.Show("Потребителският профил беше изтрит успешно от базата данни.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await RefreshDataAndLogs();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("REFERENCE constraint"))
                    {
                        DialogResult deactivateResult = MessageBox.Show(
                            "Този потребител не може да бъде изтрит физически, тъй като има финансова история, банкови сметки или системни одит логове. Сигурността на банката не позволява изтриването му!\n\nИскате ли да ДЕАКТИВИРАТЕ профила му вместо това?",
                            "Опция за сигурност", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (deactivateResult == DialogResult.OK)
                        {
                            await _userController.DeactivateUser(selectedUser.UserID, _adminUser.UserID);

                            MessageBox.Show("Профилът беше успешно деактивиран и достъпът му до системата е спрян!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            await RefreshDataAndLogs();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Грешка при изтриване: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog();
            this.Close();
        }
       
    }
}
