namespace BankSystem.UI
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            btnDeleteUser = new TabPage();
            button1 = new Button();
            dgvUsers = new DataGridView();
            groupBox1 = new GroupBox();
            btnCreateUser = new Button();
            txtNewPassword = new TextBox();
            txtNewUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            dgvLogs = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            btnDeleteUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1320, 70);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bank;
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(389, 15);
            label1.Name = "label1";
            label1.Size = new Size(528, 41);
            label1.TabIndex = 1;
            label1.Text = "Панел за администрация и сигурност";
            label1.Click += label1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(btnDeleteUser);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 70);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1320, 630);
            tabControl1.TabIndex = 1;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Controls.Add(button1);
            btnDeleteUser.Controls.Add(dgvUsers);
            btnDeleteUser.Controls.Add(groupBox1);
            btnDeleteUser.Location = new Point(4, 29);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Padding = new Padding(3);
            btnDeleteUser.Size = new Size(1312, 597);
            btnDeleteUser.TabIndex = 0;
            btnDeleteUser.Text = "Служители";
            btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(755, 510);
            button1.Name = "button1";
            button1.Size = new Size(383, 52);
            button1.TabIndex = 6;
            button1.Text = "Изтрий маркирания профил";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.WhiteSmoke;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(619, 32);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(654, 451);
            dgvUsers.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightSteelBlue;
            groupBox1.Controls.Add(btnCreateUser);
            groupBox1.Controls.Add(txtNewPassword);
            groupBox1.Controls.Add(txtNewUsername);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(70, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(484, 530);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавяне на нов служител (касиер)";
            // 
            // btnCreateUser
            // 
            btnCreateUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateUser.Location = new Point(106, 427);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(272, 52);
            btnCreateUser.TabIndex = 5;
            btnCreateUser.Text = "Създай профил";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(35, 298);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(415, 38);
            txtNewPassword.TabIndex = 4;
            // 
            // txtNewUsername
            // 
            txtNewUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewUsername.Location = new Point(35, 190);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(415, 38);
            txtNewUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(35, 251);
            label3.Name = "label3";
            label3.Size = new Size(93, 31);
            label3.TabIndex = 2;
            label3.Text = "Парола";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 142);
            label2.Name = "label2";
            label2.Size = new Size(219, 31);
            label2.TabIndex = 1;
            label2.Text = "Потребителско име";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvLogs);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1312, 597);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Одит логове (сигурност)";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvLogs
            // 
            dgvLogs.BackgroundColor = Color.WhiteSmoke;
            dgvLogs.BorderStyle = BorderStyle.None;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.Location = new Point(3, 3);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowHeadersWidth = 51;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(1306, 591);
            dgvLogs.TabIndex = 0;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 700);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            btnDeleteUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage btnDeleteUser;
        private GroupBox groupBox1;
        private TabPage tabPage2;
        private DataGridView dgvUsers;
        private Label label3;
        private Label label2;
        private TextBox txtNewPassword;
        private TextBox txtNewUsername;
        private Button btnCreateUser;
        private Button button1;
        private DataGridView dgvLogs;
    }
}