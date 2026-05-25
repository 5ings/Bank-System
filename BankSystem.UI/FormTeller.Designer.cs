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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeller));
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
            txtSourceIban = new TextBox();
            label11 = new Label();
            btnTransfer = new Button();
            btnWithdraw = new Button();
            btnDeposit = new Button();
            txtTargetIban = new TextBox();
            label10 = new Label();
            txtAmount = new TextBox();
            label9 = new Label();
            panel1 = new Panel();
            btnLogOut = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            imageList1 = new ImageList(components);
            pictureBox2 = new PictureBox();
            grpClientManagement.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            grpClientManagement.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpClientManagement.Location = new Point(69, 65);
            grpClientManagement.Margin = new Padding(3, 2, 3, 2);
            grpClientManagement.Name = "grpClientManagement";
            grpClientManagement.Padding = new Padding(3, 2, 3, 2);
            grpClientManagement.Size = new Size(438, 451);
            grpClientManagement.TabIndex = 0;
            grpClientManagement.TabStop = false;
            grpClientManagement.Text = "Управление и Регистрация на клиенти";
            // 
            // btnRegisterClient
            // 
            btnRegisterClient.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterClient.Location = new Point(35, 398);
            btnRegisterClient.Margin = new Padding(3, 2, 3, 2);
            btnRegisterClient.Name = "btnRegisterClient";
            btnRegisterClient.Size = new Size(361, 39);
            btnRegisterClient.TabIndex = 16;
            btnRegisterClient.Text = "Регистрирай клиент и профил";
            btnRegisterClient.UseVisualStyleBackColor = true;
            btnRegisterClient.Click += btnRegisterClient_Click;
            // 
            // txtClientPassword
            // 
            txtClientPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientPassword.Location = new Point(35, 358);
            txtClientPassword.Margin = new Padding(3, 2, 3, 2);
            txtClientPassword.Name = "txtClientPassword";
            txtClientPassword.Size = new Size(364, 29);
            txtClientPassword.TabIndex = 15;
            // 
            // txtClientUsername
            // 
            txtClientUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientUsername.Location = new Point(35, 308);
            txtClientUsername.Margin = new Padding(3, 2, 3, 2);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.Size = new Size(364, 29);
            txtClientUsername.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(33, 335);
            label8.Name = "label8";
            label8.Size = new Size(63, 21);
            label8.TabIndex = 13;
            label8.Text = "Парола";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(33, 284);
            label7.Name = "label7";
            label7.Size = new Size(151, 21);
            label7.TabIndex = 12;
            label7.Text = "Потребителско име";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(33, 256);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(364, 29);
            txtEmail.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(33, 206);
            txtPhone.Margin = new Padding(3, 2, 3, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(364, 29);
            txtPhone.TabIndex = 10;
            // 
            // txtEGN
            // 
            txtEGN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEGN.Location = new Point(33, 154);
            txtEGN.Margin = new Padding(3, 2, 3, 2);
            txtEGN.Name = "txtEGN";
            txtEGN.Size = new Size(364, 29);
            txtEGN.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(33, 104);
            txtLastName.Margin = new Padding(3, 2, 3, 2);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(364, 29);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(33, 52);
            txtFirstName.Margin = new Padding(3, 2, 3, 2);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(364, 29);
            txtFirstName.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 233);
            label6.Name = "label6";
            label6.Size = new Size(58, 21);
            label6.TabIndex = 6;
            label6.Text = "Имейл";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 182);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 5;
            label5.Text = "Телефон";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 131);
            label4.Name = "label4";
            label4.Size = new Size(37, 21);
            label4.TabIndex = 4;
            label4.Text = "ЕГН";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 80);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 3;
            label3.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 29);
            label2.Name = "label2";
            label2.Size = new Size(41, 21);
            label2.TabIndex = 2;
            label2.Text = "Име";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.LightSteelBlue;
            groupBox2.Controls.Add(txtSourceIban);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btnTransfer);
            groupBox2.Controls.Add(btnWithdraw);
            groupBox2.Controls.Add(btnDeposit);
            groupBox2.Controls.Add(txtTargetIban);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtAmount);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(632, 65);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(438, 387);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Финансови операции по сметки";
            // 
            // txtSourceIban
            // 
            txtSourceIban.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSourceIban.Location = new Point(34, 72);
            txtSourceIban.Margin = new Padding(3, 2, 3, 2);
            txtSourceIban.Name = "txtSourceIban";
            txtSourceIban.Size = new Size(366, 29);
            txtSourceIban.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(34, 49);
            label11.Name = "label11";
            label11.Size = new Size(45, 21);
            label11.TabIndex = 20;
            label11.Text = "IBAN";
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransfer.Location = new Point(36, 325);
            btnTransfer.Margin = new Padding(3, 2, 3, 2);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(364, 39);
            btnTransfer.TabIndex = 19;
            btnTransfer.Text = "Превод";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWithdraw.Location = new Point(34, 274);
            btnWithdraw.Margin = new Padding(3, 2, 3, 2);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(366, 39);
            btnWithdraw.TabIndex = 18;
            btnWithdraw.Text = "Теглене";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeposit.Location = new Point(34, 223);
            btnDeposit.Margin = new Padding(3, 2, 3, 2);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(366, 39);
            btnDeposit.TabIndex = 17;
            btnDeposit.Text = "Внасяне";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // txtTargetIban
            // 
            txtTargetIban.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTargetIban.Location = new Point(34, 182);
            txtTargetIban.Margin = new Padding(3, 2, 3, 2);
            txtTargetIban.Name = "txtTargetIban";
            txtTargetIban.Size = new Size(366, 29);
            txtTargetIban.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(36, 154);
            label10.Name = "label10";
            label10.Size = new Size(144, 21);
            label10.TabIndex = 9;
            label10.Text = "IBAN на получател";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(34, 123);
            txtAmount.Margin = new Padding(3, 2, 3, 2);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(366, 29);
            txtAmount.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(34, 100);
            label9.Name = "label9";
            label9.Size = new Size(47, 21);
            label9.TabIndex = 3;
            label9.Text = "Сума";
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
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(220, 53, 69);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.ImageKey = "Exit.png";
            btnLogOut.ImageList = imageList1;
            btnLogOut.Location = new Point(1013, 484);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(130, 32);
            btnLogOut.TabIndex = 8;
            btnLogOut.Text = "Изход";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BankLogo;
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(346, 11);
            label1.Name = "label1";
            label1.Size = new Size(408, 32);
            label1.TabIndex = 2;
            label1.Text = "Работно място: оператор/касиер";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "TransferTo.png");
            imageList1.Images.SetKeyName(1, "Exit.png");
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Teller;
            pictureBox2.Location = new Point(1094, 4);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(58, 46);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // FormTeller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 525);
            Controls.Add(btnLogOut);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(grpClientManagement);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private TextBox txtSourceIban;
        private Button btnLogOut;
        private ImageList imageList1;
        private PictureBox pictureBox2;
    }
}