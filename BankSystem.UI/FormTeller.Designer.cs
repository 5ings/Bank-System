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
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnLogOut = new Button();
            imageList1 = new ImageList(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button2 = new Button();
            tabPage3 = new TabPage();
            button3 = new Button();
            groupBox1 = new GroupBox();
            CardTypeComboBox = new ComboBox();
            label17 = new Label();
            CurrencyComboBox = new ComboBox();
            EgnTextBox = new TextBox();
            label15 = new Label();
            button1 = new Button();
            BalanceTextBox = new TextBox();
            label13 = new Label();
            label14 = new Label();
            grpClientManagement.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
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
            grpClientManagement.Location = new Point(123, 83);
            grpClientManagement.Name = "grpClientManagement";
            grpClientManagement.Size = new Size(1081, 404);
            grpClientManagement.TabIndex = 0;
            grpClientManagement.TabStop = false;
            grpClientManagement.Text = "Управление и Регистрация на клиенти";
            // 
            // btnRegisterClient
            // 
            btnRegisterClient.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterClient.Location = new Point(565, 261);
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
            txtClientPassword.Location = new Point(565, 139);
            txtClientPassword.Name = "txtClientPassword";
            txtClientPassword.Size = new Size(415, 34);
            txtClientPassword.TabIndex = 15;
            // 
            // txtClientUsername
            // 
            txtClientUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientUsername.Location = new Point(565, 69);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.Size = new Size(415, 34);
            txtClientUsername.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(565, 111);
            label8.Name = "label8";
            label8.Size = new Size(81, 28);
            label8.TabIndex = 13;
            label8.Text = "Парола";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(565, 39);
            label7.Name = "label7";
            label7.Size = new Size(193, 28);
            label7.TabIndex = 12;
            label7.Text = "Потребителско име";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(38, 341);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(415, 34);
            txtEmail.TabIndex = 11;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(38, 275);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(415, 34);
            txtPhone.TabIndex = 10;
            // 
            // txtEGN
            // 
            txtEGN.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEGN.Location = new Point(38, 205);
            txtEGN.Name = "txtEGN";
            txtEGN.Size = new Size(415, 34);
            txtEGN.TabIndex = 9;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(38, 139);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(415, 34);
            txtLastName.TabIndex = 8;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(38, 69);
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
            groupBox2.Location = new Point(170, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(985, 404);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Финансови операции по сметки";
            // 
            // txtSourceIban
            // 
            txtSourceIban.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSourceIban.Location = new Point(39, 96);
            txtSourceIban.Name = "txtSourceIban";
            txtSourceIban.Size = new Size(418, 34);
            txtSourceIban.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(39, 65);
            label11.Name = "label11";
            label11.Size = new Size(56, 28);
            label11.TabIndex = 20;
            label11.Text = "IBAN";
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTransfer.Location = new Point(528, 235);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(416, 52);
            btnTransfer.TabIndex = 19;
            btnTransfer.Text = "Превод";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnWithdraw.Location = new Point(39, 315);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(418, 52);
            btnWithdraw.TabIndex = 18;
            btnWithdraw.Text = "Теглене";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeposit.Location = new Point(39, 235);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(418, 52);
            btnDeposit.TabIndex = 17;
            btnDeposit.Text = "Внасяне";
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // txtTargetIban
            // 
            txtTargetIban.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTargetIban.Location = new Point(526, 96);
            txtTargetIban.Name = "txtTargetIban";
            txtTargetIban.Size = new Size(418, 34);
            txtTargetIban.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(526, 65);
            label10.Name = "label10";
            label10.Size = new Size(183, 28);
            label10.TabIndex = 9;
            label10.Text = "IBAN на получател";
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(39, 164);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(418, 34);
            txtAmount.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(39, 133);
            label9.Name = "label9";
            label9.Size = new Size(58, 28);
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
            panel1.Name = "panel1";
            panel1.Size = new Size(1320, 69);
            panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Teller;
            pictureBox2.Location = new Point(1250, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 61);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BankLogo;
            pictureBox1.Location = new Point(3, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 61);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(395, 15);
            label1.Name = "label1";
            label1.Size = new Size(499, 41);
            label1.TabIndex = 2;
            label1.Text = "Работно място: оператор/касиер";
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
            btnLogOut.Location = new Point(1155, 543);
            btnLogOut.Margin = new Padding(3, 4, 3, 4);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(149, 43);
            btnLogOut.TabIndex = 8;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 69);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1320, 631);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(grpClientManagement);
            tabPage1.Controls.Add(btnLogOut);
            tabPage1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1312, 598);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Управления на клиенти";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1312, 598);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Финансови операции";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(220, 53, 69);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImageKey = "Exit.png";
            button2.ImageList = imageList1;
            button2.Location = new Point(1155, 546);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(149, 43);
            button2.TabIndex = 9;
            button2.Text = "Изход";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(1312, 598);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Управление на сметки и карти";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(220, 53, 69);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImageKey = "Exit.png";
            button3.ImageList = imageList1;
            button3.Location = new Point(1155, 546);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(149, 43);
            button3.TabIndex = 9;
            button3.Text = "Изход";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightSteelBlue;
            groupBox1.Controls.Add(CardTypeComboBox);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(CurrencyComboBox);
            groupBox1.Controls.Add(EgnTextBox);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(BalanceTextBox);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label14);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(391, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(504, 459);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // CardTypeComboBox
            // 
            CardTypeComboBox.FormattingEnabled = true;
            CardTypeComboBox.Items.AddRange(new object[] { "DebitVisa", "CreditVisa", "DebitMasterCard", "CreditMasterCard" });
            CardTypeComboBox.Location = new Point(39, 160);
            CardTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            CardTypeComboBox.Name = "CardTypeComboBox";
            CardTypeComboBox.Size = new Size(418, 33);
            CardTypeComboBox.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(39, 128);
            label17.Name = "label17";
            label17.Size = new Size(101, 28);
            label17.TabIndex = 27;
            label17.Text = "Вид карта";
            // 
            // CurrencyComboBox
            // 
            CurrencyComboBox.FormattingEnabled = true;
            CurrencyComboBox.Items.AddRange(new object[] { "EUR", "USD" });
            CurrencyComboBox.Location = new Point(39, 311);
            CurrencyComboBox.Margin = new Padding(3, 4, 3, 4);
            CurrencyComboBox.Name = "CurrencyComboBox";
            CurrencyComboBox.Size = new Size(418, 33);
            CurrencyComboBox.TabIndex = 24;
            // 
            // EgnTextBox
            // 
            EgnTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EgnTextBox.Location = new Point(39, 80);
            EgnTextBox.Name = "EgnTextBox";
            EgnTextBox.Size = new Size(418, 34);
            EgnTextBox.TabIndex = 23;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(39, 49);
            label15.Name = "label15";
            label15.Size = new Size(140, 28);
            label15.TabIndex = 22;
            label15.Text = "ЕГН на клиент";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(39, 380);
            button1.Name = "button1";
            button1.Size = new Size(416, 52);
            button1.TabIndex = 19;
            button1.Text = "Създай сметка и карта";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BalanceTextBox
            // 
            BalanceTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BalanceTextBox.Location = new Point(39, 237);
            BalanceTextBox.Name = "BalanceTextBox";
            BalanceTextBox.Size = new Size(418, 34);
            BalanceTextBox.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(39, 197);
            label13.Name = "label13";
            label13.Size = new Size(159, 28);
            label13.TabIndex = 9;
            label13.Text = "Начален баланс";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(39, 279);
            label14.Name = "label14";
            label14.Size = new Size(72, 28);
            label14.TabIndex = 3;
            label14.Text = "Валута";
            // 
            // FormTeller
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 700);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        private TextBox EgnTextBox;
        private Label label15;
        private Button button1;
        private TextBox BalanceTextBox;
        private Label label13;
        private Label label14;
        private Label label17;
        private ComboBox CurrencyComboBox;
        private ComboBox CardTypeComboBox;
        private Button button2;
        private Button button3;
    }
}