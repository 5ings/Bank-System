namespace BankSystem.UI
{
    partial class FormClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            pictureBox2 = new PictureBox();
            lblClientPhone = new Label();
            lblClientEgn = new Label();
            lblClientName = new Label();
            label1 = new Label();
            label2 = new Label();
            dgvAccounts = new DataGridView();
            groupBox2 = new GroupBox();
            MyAccountsComboBox = new ComboBox();
            button1 = new Button();
            imageList1 = new ImageList(components);
            AmountTextBox = new TextBox();
            lblAmount = new Label();
            RecipientIbanTextBox = new TextBox();
            lblToIban = new Label();
            lblFromIban = new Label();
            btnLogOut = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BankLogo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightSteelBlue;
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(lblClientPhone);
            groupBox1.Controls.Add(lblClientEgn);
            groupBox1.Controls.Add(lblClientName);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(25, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(520, 115);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Личен профил";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.ClientPhoto;
            pictureBox2.Location = new Point(433, 25);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(70, 70);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // lblClientPhone
            // 
            lblClientPhone.AutoSize = true;
            lblClientPhone.Location = new Point(20, 85);
            lblClientPhone.Name = "lblClientPhone";
            lblClientPhone.Size = new Size(51, 20);
            lblClientPhone.TabIndex = 2;
            lblClientPhone.Text = "label4";
            // 
            // lblClientEgn
            // 
            lblClientEgn.AutoSize = true;
            lblClientEgn.Location = new Point(20, 55);
            lblClientEgn.Name = "lblClientEgn";
            lblClientEgn.Size = new Size(51, 20);
            lblClientEgn.TabIndex = 1;
            lblClientEgn.Text = "label3";
            // 
            // lblClientName
            // 
            lblClientName.AutoSize = true;
            lblClientName.Location = new Point(20, 25);
            lblClientName.Name = "lblClientName";
            lblClientName.Size = new Size(51, 20);
            lblClientName.TabIndex = 0;
            lblClientName.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(286, 9);
            label1.Name = "label1";
            label1.Size = new Size(551, 32);
            label1.TabIndex = 3;
            label1.Text = "Добре дошли във вашето онлайн банкиране";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 220);
            label2.Name = "label2";
            label2.Size = new Size(269, 20);
            label2.TabIndex = 4;
            label2.Text = "Налични банкови сметки и баланси";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = Color.FromArgb(245, 247, 250);
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(25, 245);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.Size = new Size(520, 210);
            dgvAccounts.TabIndex = 5;
            dgvAccounts.CellContentClick += dgvAccounts_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.LightSteelBlue;
            groupBox2.Controls.Add(MyAccountsComboBox);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(AmountTextBox);
            groupBox2.Controls.Add(lblAmount);
            groupBox2.Controls.Add(RecipientIbanTextBox);
            groupBox2.Controls.Add(lblToIban);
            groupBox2.Controls.Add(lblFromIban);
            groupBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(580, 90);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(535, 365);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // MyAccountsComboBox
            // 
            MyAccountsComboBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MyAccountsComboBox.FormattingEnabled = true;
            MyAccountsComboBox.Location = new Point(25, 50);
            MyAccountsComboBox.Name = "MyAccountsComboBox";
            MyAccountsComboBox.Size = new Size(485, 25);
            MyAccountsComboBox.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(40, 167, 69);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 0;
            button1.ImageList = imageList1;
            button1.Location = new Point(25, 250);
            button1.Name = "button1";
            button1.Size = new Size(485, 45);
            button1.TabIndex = 8;
            button1.Text = "Потвърди и изпрати превода";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "TransferTo.png");
            imageList1.Images.SetKeyName(1, "Exit.png");
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(25, 182);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(220, 25);
            AmountTextBox.TabIndex = 7;
            AmountTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(25, 160);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(40, 17);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "Сума";
            // 
            // RecipientIbanTextBox
            // 
            RecipientIbanTextBox.Location = new Point(25, 117);
            RecipientIbanTextBox.Name = "RecipientIbanTextBox";
            RecipientIbanTextBox.Size = new Size(485, 25);
            RecipientIbanTextBox.TabIndex = 5;
            // 
            // lblToIban
            // 
            lblToIban.AutoSize = true;
            lblToIban.Location = new Point(25, 95);
            lblToIban.Name = "lblToIban";
            lblToIban.Size = new Size(129, 17);
            lblToIban.TabIndex = 4;
            lblToIban.Text = "IBAN на получател";
            // 
            // lblFromIban
            // 
            lblFromIban.AutoSize = true;
            lblFromIban.Location = new Point(25, 30);
            lblFromIban.Name = "lblFromIban";
            lblFromIban.Size = new Size(39, 17);
            lblFromIban.TabIndex = 2;
            lblFromIban.Text = "IBAN";
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
            btnLogOut.Location = new Point(1013, 481);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(130, 32);
            btnLogOut.TabIndex = 7;
            btnLogOut.Text = "Изход";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1155, 61);
            panel1.TabIndex = 8;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 525);
            Controls.Add(panel1);
            Controls.Add(btnLogOut);
            Controls.Add(groupBox2);
            Controls.Add(dgvAccounts);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormClient";
            Load += FormClient_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private Label lblClientPhone;
        private Label lblClientEgn;
        private Label lblClientName;
        private Label label2;
        private DataGridView dgvAccounts;
        private GroupBox groupBox2;
        private Label lblFromIban;
        private Button button1;
        private TextBox AmountTextBox;
        private Label lblAmount;
        private TextBox RecipientIbanTextBox;
        private Label lblToIban;
        private Button btnLogOut;
        private Panel panel1;
        private PictureBox pictureBox2;
        private ImageList imageList1;
        private ComboBox MyAccountsComboBox;
    }
}