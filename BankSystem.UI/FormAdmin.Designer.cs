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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            btnDeleteUser = new TabPage();
            btnLogOut = new Button();
            imageList1 = new ImageList(components);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1155, 52);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Admin;
            pictureBox2.Location = new Point(1090, 3);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(58, 46);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BankLogo;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(340, 11);
            label1.Name = "label1";
            label1.Size = new Size(461, 32);
            label1.TabIndex = 1;
            label1.Text = "Панел за администрация и сигурност";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(btnDeleteUser);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 52);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1155, 473);
            tabControl1.TabIndex = 1;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Controls.Add(btnLogOut);
            btnDeleteUser.Controls.Add(button1);
            btnDeleteUser.Controls.Add(dgvUsers);
            btnDeleteUser.Controls.Add(groupBox1);
            btnDeleteUser.Location = new Point(4, 24);
            btnDeleteUser.Margin = new Padding(3, 2, 3, 2);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Padding = new Padding(3, 2, 3, 2);
            btnDeleteUser.Size = new Size(1147, 445);
            btnDeleteUser.TabIndex = 0;
            btnDeleteUser.Text = "Служители";
            btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(220, 53, 69);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.ImageKey = "Exit.png";
            btnLogOut.ImageList = imageList1;
            btnLogOut.Location = new Point(1014, 405);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(130, 32);
            btnLogOut.TabIndex = 9;
            btnLogOut.Text = "Изход";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "TransferTo.png");
            imageList1.Images.SetKeyName(1, "Exit.png");
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(661, 382);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(335, 39);
            button1.TabIndex = 6;
            button1.Text = "Изтрий маркирания профил";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.WhiteSmoke;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvUsers.Location = new Point(542, 24);
            dgvUsers.Margin = new Padding(3, 2, 3, 2);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(572, 338);
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
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(61, 24);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(424, 398);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавяне на нов служител (касиер)";
            // 
            // btnCreateUser
            // 
            btnCreateUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreateUser.Location = new Point(93, 320);
            btnCreateUser.Margin = new Padding(3, 2, 3, 2);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(238, 39);
            btnCreateUser.TabIndex = 5;
            btnCreateUser.Text = "Създай профил";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.Location = new Point(31, 224);
            txtNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(364, 32);
            txtNewPassword.TabIndex = 4;
            // 
            // txtNewUsername
            // 
            txtNewUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewUsername.Location = new Point(31, 142);
            txtNewUsername.Margin = new Padding(3, 2, 3, 2);
            txtNewUsername.Name = "txtNewUsername";
            txtNewUsername.Size = new Size(364, 32);
            txtNewUsername.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 188);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Парола";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 106);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 1;
            label2.Text = "Потребителско име";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvLogs);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1147, 445);
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
            dgvLogs.Location = new Point(3, 2);
            dgvLogs.Margin = new Padding(3, 2, 3, 2);
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.RowHeadersWidth = 51;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(1141, 441);
            dgvLogs.TabIndex = 0;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 525);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            Load += FormAdmin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Button btnLogOut;
        private ImageList imageList1;
        private PictureBox pictureBox2;

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = true;

            if (dgvUsers.Columns["IsActive"] != null)
            { 
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "IsActiveColumn";
                chk.HeaderText = "Активен";
                chk.DataPropertyName = "IsActive"; // Името на свойството от класа User

                dgvUsers.Columns.Add(chk);
            }
        }
    }
}