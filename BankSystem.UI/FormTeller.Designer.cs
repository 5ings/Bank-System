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
            tabPage3 = new TabPage();
            groupBox1 = new GroupBox();
            CVVTextBox = new TextBox();
            label19 = new Label();
            ExpiryDateTextBox = new TextBox();
            label18 = new Label();
            CardTypeComboBox = new ComboBox();
            label17 = new Label();
            CardNumberTextBox = new TextBox();
            label16 = new Label();
            CurrencyComboBox = new ComboBox();
            EgnTextBox = new TextBox();
            label15 = new Label();
            IbanTextBox = new TextBox();
            label12 = new Label();
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
            grpClientManagement.Location = new Point(108, 62);
            grpClientManagement.Margin = new Padding(3, 2, 3, 2);
            grpClientManagement.Name = "grpClientManagement";
            grpClientManagement.Padding = new Padding(3, 2, 3, 2);
            grpClientManagement.Size = new Size(946, 303);
            grpClientManagement.TabIndex = 0;
            grpClientManagement.TabStop = false;
            grpClientManagement.Text = "Управление и Регистрация на клиенти";
            // 
            // btnRegisterClient
            // 
            btnRegisterClient.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterClient.Location = new Point(494, 196);
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
            txtClientPassword.Location = new Point(494, 104);
            txtClientPassword.Margin = new Padding(3, 2, 3, 2);
            txtClientPassword.Name = "txtClientPassword";
            txtClientPassword.Size = new Size(364, 29);
            txtClientPassword.TabIndex = 15;
            // 
            // txtClientUsername
            // 
            txtClientUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtClientUsername.Location = new Point(494, 52);
            txtClientUsername.Margin = new Padding(3, 2, 3, 2);
            txtClientUsername.Name = "txtClientUsername";
            txtClientUsername.Size = new Size(364, 29);
            txtClientUsername.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(494, 83);
            label8.Name = "label8";
            label8.Size = new Size(63, 21);
            label8.TabIndex = 13;
            label8.Text = "Парола";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(494, 29);
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
            groupBox2.Location = new Point(149, 71);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(862, 303);
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
            btnTransfer.Location = new Point(462, 176);
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
            btnWithdraw.Location = new Point(34, 236);
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
            btnDeposit.Location = new Point(34, 176);
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
            txtTargetIban.Location = new Point(460, 72);
            txtTargetIban.Margin = new Padding(3, 2, 3, 2);
            txtTargetIban.Name = "txtTargetIban";
            txtTargetIban.Size = new Size(366, 29);
            txtTargetIban.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(460, 49);
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
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(220, 53, 69);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.White;
            btnLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogOut.ImageKey = "Exit.png";
            btnLogOut.ImageList = imageList1;
            btnLogOut.Location = new Point(1011, 407);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(130, 32);
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
            tabControl1.Location = new Point(0, 52);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1155, 473);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(grpClientManagement);
            tabPage1.Controls.Add(btnLogOut);
            tabPage1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1147, 445);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Управления на клиенти";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1147, 445);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Финансови операции";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1147, 445);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Управление на сметки и карти";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightSteelBlue;
            groupBox1.Controls.Add(CVVTextBox);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(ExpiryDateTextBox);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(CardTypeComboBox);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(CardNumberTextBox);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(CurrencyComboBox);
            groupBox1.Controls.Add(EgnTextBox);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(IbanTextBox);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(BalanceTextBox);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label14);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(143, 73);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(862, 344);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // CVVTextBox
            // 
            CVVTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CVVTextBox.Location = new Point(436, 232);
            CVVTextBox.Margin = new Padding(3, 2, 3, 2);
            CVVTextBox.Name = "CVVTextBox";
            CVVTextBox.Size = new Size(366, 29);
            CVVTextBox.TabIndex = 33;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(436, 209);
            label19.Name = "label19";
            label19.Size = new Size(40, 21);
            label19.TabIndex = 32;
            label19.Text = "CVV";
            // 
            // ExpiryDateTextBox
            // 
            ExpiryDateTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExpiryDateTextBox.Location = new Point(438, 178);
            ExpiryDateTextBox.Margin = new Padding(3, 2, 3, 2);
            ExpiryDateTextBox.Name = "ExpiryDateTextBox";
            ExpiryDateTextBox.Size = new Size(366, 29);
            ExpiryDateTextBox.TabIndex = 31;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(438, 148);
            label18.Name = "label18";
            label18.Size = new Size(135, 21);
            label18.TabIndex = 30;
            label18.Text = "Дата на изтичане";
            // 
            // CardTypeComboBox
            // 
            CardTypeComboBox.FormattingEnabled = true;
            CardTypeComboBox.Items.AddRange(new object[] { "DebitVisa", "CreditVisa", "DebitMasterCard", "CreditMasterCard" });
            CardTypeComboBox.Location = new Point(438, 117);
            CardTypeComboBox.Name = "CardTypeComboBox";
            CardTypeComboBox.Size = new Size(366, 28);
            CardTypeComboBox.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(436, 91);
            label17.Name = "label17";
            label17.Size = new Size(81, 21);
            label17.TabIndex = 27;
            label17.Text = "Вид карта";
            // 
            // CardNumberTextBox
            // 
            CardNumberTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CardNumberTextBox.Location = new Point(436, 60);
            CardNumberTextBox.Margin = new Padding(3, 2, 3, 2);
            CardNumberTextBox.Name = "CardNumberTextBox";
            CardNumberTextBox.Size = new Size(366, 29);
            CardNumberTextBox.TabIndex = 26;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(436, 37);
            label16.Name = "label16";
            label16.Size = new Size(123, 21);
            label16.TabIndex = 25;
            label16.Text = "Номер на карта";
            // 
            // CurrencyComboBox
            // 
            CurrencyComboBox.FormattingEnabled = true;
            CurrencyComboBox.Items.AddRange(new object[] { "EUR", "USD" });
            CurrencyComboBox.Location = new Point(34, 233);
            CurrencyComboBox.Name = "CurrencyComboBox";
            CurrencyComboBox.Size = new Size(366, 28);
            CurrencyComboBox.TabIndex = 24;
            // 
            // EgnTextBox
            // 
            EgnTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EgnTextBox.Location = new Point(34, 60);
            EgnTextBox.Margin = new Padding(3, 2, 3, 2);
            EgnTextBox.Name = "EgnTextBox";
            EgnTextBox.Size = new Size(366, 29);
            EgnTextBox.TabIndex = 23;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(34, 37);
            label15.Name = "label15";
            label15.Size = new Size(111, 21);
            label15.TabIndex = 22;
            label15.Text = "ЕГН на клиент";
            // 
            // IbanTextBox
            // 
            IbanTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IbanTextBox.Location = new Point(34, 114);
            IbanTextBox.Margin = new Padding(3, 2, 3, 2);
            IbanTextBox.Name = "IbanTextBox";
            IbanTextBox.Size = new Size(366, 29);
            IbanTextBox.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(34, 91);
            label12.Name = "label12";
            label12.Size = new Size(45, 21);
            label12.TabIndex = 20;
            label12.Text = "IBAN";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(256, 285);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(364, 39);
            button1.TabIndex = 19;
            button1.Text = "Създай сметка и карта";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BalanceTextBox
            // 
            BalanceTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BalanceTextBox.Location = new Point(34, 178);
            BalanceTextBox.Margin = new Padding(3, 2, 3, 2);
            BalanceTextBox.Name = "BalanceTextBox";
            BalanceTextBox.Size = new Size(366, 29);
            BalanceTextBox.TabIndex = 10;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(34, 148);
            label13.Name = "label13";
            label13.Size = new Size(124, 21);
            label13.TabIndex = 9;
            label13.Text = "Начален баланс";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(34, 209);
            label14.Name = "label14";
            label14.Size = new Size(58, 21);
            label14.TabIndex = 3;
            label14.Text = "Валута";
            // 
            // FormTeller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 525);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
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
        private TextBox IbanTextBox;
        private Label label12;
        private Button button1;
        private TextBox BalanceTextBox;
        private Label label13;
        private Label label14;
        private Label label17;
        private TextBox CardNumberTextBox;
        private Label label16;
        private ComboBox CurrencyComboBox;
        private ComboBox CardTypeComboBox;
        private TextBox CVVTextBox;
        private Label label19;
        private TextBox ExpiryDateTextBox;
        private Label label18;
    }
}