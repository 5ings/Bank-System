namespace BankSystem.UI
{
    partial class FormTeller
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
            grpClientManagement = new GroupBox();
            btnRegisterClient = new Button();
            txtClientPassword = new TextBox();
            txtClientUsername = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtEGN = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnTransfer = new Button();
            btnWithdraw = new Button();
            btnDeposit = new Button();
            txtTargetIban = new TextBox();
            label10 = new Label();
            txtAmount = new TextBox();
            label9 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label11 = new Label();
            grpClientManagement.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grpClientManagement
            // 
            grpClientManagement.BackColor = Color.LightSteelBlue;
            grpClientManagement.Controls.Add(btnRegisterClient);
            grpClientManagement.Controls.Add(txtClientPassword);
            grpClientManagement.Controls.Add(txtClientUsername);
            grpClientManagement.Controls.Add(label8);
            grpClientManagement.Controls.Add(label7);
            grpClientManagement.Controls.Add(txtEmail);
            grpClientManagement.Controls.Add(txtPhone);
            grpClientManagement.Controls.Add(txtEGN);
            grpClientManagement.Controls.Add(txtLastName);
            grpClientManagement.Controls.Add(txtFirstName);
            grpClientManagement.Controls.Add(label6);
            grpClientManagement.Controls.Add(label5);
            grpClientManagement.Controls.Add(label4);
            grpClientManagement.Controls.Add(label3);
            grpClientManagement.Controls.Add(label2);
            grpClientManagement.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpClientManagement.Location = new Point(79, 87);
            grpClientManagement.Name = "grpClientManagement";
            grpClientManagement.Size = new Size(500, 601);
            grpClientManagement.TabIndex = 0;
            grpClientManagement.TabStop = false;
            grpClientManagement.Text = "Управление и Регистрация на клиенти";
            // 
            // btnRegisterClient
            // 
            btnRegisterClient.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterClient.Location = new Point(40, 530);
            btnRegisterClient.Name = "btnRegisterClient";
            btnRegisterClient.Size = new Size(413, 52);
            btnRegisterClient.TabIndex = 16;
            btnRegisterClient.Text = "Регистрирай клиент и профил";
            btnRegisterClient.UseVisualStyleBackColor = true;
            btnRegisterClient.Click += btnRegisterClient_Click;
            // 
            // txtClientPassword
            // 
            txtClientPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientPassword.Location = new Point(40, 478);
            txtClientPassword.Name = "txtClientPassword";
            txtClientPassword.Size = new Size(415, 34);
            txtClientPassword.TabIndex = 15;
            // 
            // txtClientUsername
            // 
            txtClientUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientUsername.Location = new Point(40, 410);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.Size = new Size(415, 34);
            txtClientUsername.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(38, 447);
            label8.Name = "label8";
            label8.Size = new Size(81, 28);
            label8.TabIndex = 13;
            label8.Text = "Парола";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 379);
            label7.Name = "label7";
            label7.Size = new Size(193, 28);
            label7.TabIndex = 12;
            label7.Text = "Потребителско име";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(38, 342);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(415, 34);
            txtEmail.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(38, 274);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(415, 34);
            txtPhone.TabIndex = 10;
            // 
            // txtEGN
            // 
            txtEGN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEGN.Location = new Point(38, 206);
            txtEGN.Name = "txtEGN";
            txtEGN.Size = new Size(415, 34);
            txtEGN.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(38, 138);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(415, 34);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(38, 70);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(415, 34);
            txtFirstName.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(38, 311);
            label6.Name = "label6";
            label6.Size = new Size(74, 28);
            label6.TabIndex = 6;
            label6.Text = "Имейл";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(38, 243);
            label5.Name = "label5";
            label5.Size = new Size(91, 28);
            label5.TabIndex = 5;
            label5.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(38, 175);
            label4.Name = "label4";
            label4.Size = new Size(45, 28);
            label4.TabIndex = 4;
            label4.Text = "ЕГН";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(38, 107);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 3;
            label3.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 39);
            label2.Name = "label2";
            label2.Size = new Size(51, 28);
            label2.TabIndex = 2;
            label2.Text = "Име";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.LightSteelBlue;
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btnTransfer);
            groupBox2.Controls.Add(btnWithdraw);
            groupBox2.Controls.Add(btnDeposit);
            groupBox2.Controls.Add(txtTargetIban);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtAmount);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(722, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(500, 601);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Финансови операции по сметки";
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransfer.Location = new Point(45, 500);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(413, 52);
            btnTransfer.TabIndex = 19;
            btnTransfer.Text = "Превод";
            btnTransfer.UseVisualStyleBackColor = true;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWithdraw.Location = new Point(45, 410);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(413, 52);
            btnWithdraw.TabIndex = 18;
            btnWithdraw.Text = "Теглене";
            btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeposit.Location = new Point(43, 324);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(413, 52);
            btnDeposit.TabIndex = 17;
            btnDeposit.Text = "Внасяне";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // txtTargetIban
            // 
            txtTargetIban.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTargetIban.Location = new Point(43, 240);
            txtTargetIban.Name = "txtTargetIban";
            txtTargetIban.Size = new Size(415, 34);
            txtTargetIban.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(41, 187);
            label10.Name = "label10";
            label10.Size = new Size(56, 28);
            label10.TabIndex = 9;
            label10.Text = "IBAN";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(41, 150);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(415, 34);
            txtAmount.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(39, 107);
            label9.Name = "label9";
            label9.Size = new Size(58, 28);
            label9.TabIndex = 3;
            label9.Text = "Сума";
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
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bank;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(396, 15);
            label1.Name = "label1";
            label1.Size = new Size(474, 41);
            label1.TabIndex = 2;
            label1.Text = "Работно място: оператор/касиер";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(41, 39);
            label11.Name = "label11";
            label11.Size = new Size(58, 28);
            label11.TabIndex = 20;
            label11.Text = "Сума";
            // 
            // FormTeller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 700);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(grpClientManagement);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTeller";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTeller";
            Load += FormTeller_Load;
            grpClientManagement.ResumeLayout(false);
            grpClientManagement.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpClientManagement;
        private GroupBox groupBox2;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtEGN;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtClientPassword;
        private TextBox txtClientUsername;
        private Label label8;
        private Label label7;
        private Button btnRegisterClient;
        private Label label10;
        private TextBox txtAmount;
        private Label label9;
        private Button btnTransfer;
        private Button btnWithdraw;
        private Button btnDeposit;
        private TextBox txtTargetIban;
        private Label label11;
    }
}