namespace P_K_accounting
{
    partial class Clients_Form
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
            clientsTable = new DataGridView();
            updatingPanel = new Panel();
            clientIdUpdateText = new TextBox();
            label1 = new Label();
            clientEmailUpdateText = new TextBox();
            label2 = new Label();
            clientPhoneUpdateText = new TextBox();
            Phone = new Label();
            updateBtn = new Button();
            clientFirstNameUpdateText = new TextBox();
            clientLastNameUpdateText = new TextBox();
            FirstName = new Label();
            LastName = new Label();
            deleteBtn = new Button();
            updatePanelBtn = new Button();
            addPanelBtn = new Button();
            addingPanel = new Panel();
            loginText = new TextBox();
            login = new Label();
            clientEmailText = new TextBox();
            clientEmail = new Label();
            clientPhoneText = new TextBox();
            clientPhone = new Label();
            addBtn = new Button();
            clientFirstNameText = new TextBox();
            clientLastNameText = new TextBox();
            clientFirstName = new Label();
            clientLastName = new Label();
            ((System.ComponentModel.ISupportInitialize)clientsTable).BeginInit();
            updatingPanel.SuspendLayout();
            addingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // clientsTable
            // 
            clientsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsTable.Location = new Point(354, 80);
            clientsTable.Name = "clientsTable";
            clientsTable.ReadOnly = true;
            clientsTable.RowTemplate.Height = 25;
            clientsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsTable.Size = new Size(700, 250);
            clientsTable.TabIndex = 0;
            clientsTable.CellClick += clientsTable_CellClick;
            // 
            // updatingPanel
            // 
            updatingPanel.BackColor = Color.Transparent;
            updatingPanel.Controls.Add(clientIdUpdateText);
            updatingPanel.Controls.Add(label1);
            updatingPanel.Controls.Add(clientEmailUpdateText);
            updatingPanel.Controls.Add(label2);
            updatingPanel.Controls.Add(clientPhoneUpdateText);
            updatingPanel.Controls.Add(Phone);
            updatingPanel.Controls.Add(updateBtn);
            updatingPanel.Controls.Add(clientFirstNameUpdateText);
            updatingPanel.Controls.Add(clientLastNameUpdateText);
            updatingPanel.Controls.Add(FirstName);
            updatingPanel.Controls.Add(LastName);
            updatingPanel.Location = new Point(1148, 64);
            updatingPanel.Name = "updatingPanel";
            updatingPanel.Size = new Size(244, 369);
            updatingPanel.TabIndex = 20;
            updatingPanel.Visible = false;
            // 
            // clientIdUpdateText
            // 
            clientIdUpdateText.Location = new Point(18, 52);
            clientIdUpdateText.Name = "clientIdUpdateText";
            clientIdUpdateText.ReadOnly = true;
            clientIdUpdateText.Size = new Size(199, 23);
            clientIdUpdateText.TabIndex = 28;
            clientIdUpdateText.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 27;
            label1.Text = "ClientID";
            // 
            // clientEmailUpdateText
            // 
            clientEmailUpdateText.Location = new Point(19, 261);
            clientEmailUpdateText.Name = "clientEmailUpdateText";
            clientEmailUpdateText.Size = new Size(199, 23);
            clientEmailUpdateText.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(19, 237);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 25;
            label2.Text = "Email";
            // 
            // clientPhoneUpdateText
            // 
            clientPhoneUpdateText.Location = new Point(20, 211);
            clientPhoneUpdateText.Name = "clientPhoneUpdateText";
            clientPhoneUpdateText.Size = new Size(199, 23);
            clientPhoneUpdateText.TabIndex = 24;
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Phone.ForeColor = SystemColors.Desktop;
            Phone.Location = new Point(20, 187);
            Phone.Name = "Phone";
            Phone.Size = new Size(54, 21);
            Phone.TabIndex = 23;
            Phone.Text = "Phone";
            // 
            // updateBtn
            // 
            updateBtn.ForeColor = SystemColors.Desktop;
            updateBtn.Location = new Point(20, 317);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(199, 39);
            updateBtn.TabIndex = 22;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // clientFirstNameUpdateText
            // 
            clientFirstNameUpdateText.Location = new Point(18, 111);
            clientFirstNameUpdateText.Name = "clientFirstNameUpdateText";
            clientFirstNameUpdateText.Size = new Size(199, 23);
            clientFirstNameUpdateText.TabIndex = 5;
            // 
            // clientLastNameUpdateText
            // 
            clientLastNameUpdateText.Location = new Point(18, 161);
            clientLastNameUpdateText.Name = "clientLastNameUpdateText";
            clientLastNameUpdateText.Size = new Size(199, 23);
            clientLastNameUpdateText.TabIndex = 13;
            // 
            // FirstName
            // 
            FirstName.AutoSize = true;
            FirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FirstName.ForeColor = SystemColors.Desktop;
            FirstName.Location = new Point(18, 87);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(82, 21);
            FirstName.TabIndex = 4;
            FirstName.Text = "FirstName";
            // 
            // LastName
            // 
            LastName.AutoSize = true;
            LastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LastName.ForeColor = SystemColors.Desktop;
            LastName.Location = new Point(18, 137);
            LastName.Name = "LastName";
            LastName.Size = new Size(80, 21);
            LastName.TabIndex = 12;
            LastName.Text = "LastName";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(354, 369);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(199, 39);
            deleteBtn.TabIndex = 21;
            deleteBtn.Text = "Delete Client";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteClientButton_Click;
            // 
            // updatePanelBtn
            // 
            updatePanelBtn.ForeColor = SystemColors.Desktop;
            updatePanelBtn.Location = new Point(30, 516);
            updatePanelBtn.Name = "updatePanelBtn";
            updatePanelBtn.Size = new Size(199, 39);
            updatePanelBtn.TabIndex = 22;
            updatePanelBtn.Text = "Update Client";
            updatePanelBtn.UseVisualStyleBackColor = true;
            updatePanelBtn.Click += updateClientPanel_Click;
            // 
            // addPanelBtn
            // 
            addPanelBtn.ForeColor = SystemColors.Desktop;
            addPanelBtn.Location = new Point(30, 468);
            addPanelBtn.Name = "addPanelBtn";
            addPanelBtn.Size = new Size(199, 39);
            addPanelBtn.TabIndex = 23;
            addPanelBtn.Text = "Add Client";
            addPanelBtn.UseVisualStyleBackColor = true;
            addPanelBtn.Click += addClientPanel_Click;
            // 
            // addingPanel
            // 
            addingPanel.BackColor = Color.Transparent;
            addingPanel.Controls.Add(loginText);
            addingPanel.Controls.Add(login);
            addingPanel.Controls.Add(clientEmailText);
            addingPanel.Controls.Add(clientEmail);
            addingPanel.Controls.Add(clientPhoneText);
            addingPanel.Controls.Add(clientPhone);
            addingPanel.Controls.Add(addBtn);
            addingPanel.Controls.Add(clientFirstNameText);
            addingPanel.Controls.Add(clientLastNameText);
            addingPanel.Controls.Add(clientFirstName);
            addingPanel.Controls.Add(clientLastName);
            addingPanel.Location = new Point(12, 75);
            addingPanel.Name = "addingPanel";
            addingPanel.Size = new Size(244, 369);
            addingPanel.TabIndex = 29;
            // 
            // loginText
            // 
            loginText.Location = new Point(18, 52);
            loginText.Name = "loginText";
            loginText.Size = new Size(199, 23);
            loginText.TabIndex = 28;
            loginText.Text = "IdentificationLogin";
            // 
            // login
            // 
            login.AutoSize = true;
            login.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            login.ForeColor = SystemColors.Desktop;
            login.Location = new Point(18, 28);
            login.Name = "login";
            login.Size = new Size(49, 21);
            login.TabIndex = 27;
            login.Text = "Login";
            // 
            // clientEmailText
            // 
            clientEmailText.Location = new Point(17, 263);
            clientEmailText.Name = "clientEmailText";
            clientEmailText.Size = new Size(199, 23);
            clientEmailText.TabIndex = 26;
            // 
            // clientEmail
            // 
            clientEmail.AutoSize = true;
            clientEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clientEmail.ForeColor = SystemColors.Desktop;
            clientEmail.Location = new Point(17, 239);
            clientEmail.Name = "clientEmail";
            clientEmail.Size = new Size(48, 21);
            clientEmail.TabIndex = 25;
            clientEmail.Text = "Email";
            // 
            // clientPhoneText
            // 
            clientPhoneText.Location = new Point(18, 213);
            clientPhoneText.Name = "clientPhoneText";
            clientPhoneText.Size = new Size(199, 23);
            clientPhoneText.TabIndex = 24;
            // 
            // clientPhone
            // 
            clientPhone.AutoSize = true;
            clientPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clientPhone.ForeColor = SystemColors.Desktop;
            clientPhone.Location = new Point(18, 189);
            clientPhone.Name = "clientPhone";
            clientPhone.Size = new Size(54, 21);
            clientPhone.TabIndex = 23;
            clientPhone.Text = "Phone";
            // 
            // addBtn
            // 
            addBtn.ForeColor = SystemColors.Desktop;
            addBtn.Location = new Point(18, 319);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(199, 39);
            addBtn.TabIndex = 22;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // clientFirstNameText
            // 
            clientFirstNameText.Location = new Point(18, 111);
            clientFirstNameText.Name = "clientFirstNameText";
            clientFirstNameText.Size = new Size(199, 23);
            clientFirstNameText.TabIndex = 5;
            // 
            // clientLastNameText
            // 
            clientLastNameText.Location = new Point(18, 161);
            clientLastNameText.Name = "clientLastNameText";
            clientLastNameText.Size = new Size(199, 23);
            clientLastNameText.TabIndex = 13;
            // 
            // clientFirstName
            // 
            clientFirstName.AutoSize = true;
            clientFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clientFirstName.ForeColor = SystemColors.Desktop;
            clientFirstName.Location = new Point(18, 87);
            clientFirstName.Name = "clientFirstName";
            clientFirstName.Size = new Size(82, 21);
            clientFirstName.TabIndex = 4;
            clientFirstName.Text = "FirstName";
            // 
            // clientLastName
            // 
            clientLastName.AutoSize = true;
            clientLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            clientLastName.ForeColor = SystemColors.Desktop;
            clientLastName.Location = new Point(18, 137);
            clientLastName.Name = "clientLastName";
            clientLastName.Size = new Size(80, 21);
            clientLastName.TabIndex = 12;
            clientLastName.Text = "LastName";
            // 
            // Clients_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1503, 567);
            Controls.Add(addingPanel);
            Controls.Add(addPanelBtn);
            Controls.Add(updatePanelBtn);
            Controls.Add(deleteBtn);
            Controls.Add(updatingPanel);
            Controls.Add(clientsTable);
            Name = "Clients_Form";
            Text = "Clients_Form";
            Load += Clients_Form_Load;
            ((System.ComponentModel.ISupportInitialize)clientsTable).EndInit();
            updatingPanel.ResumeLayout(false);
            updatingPanel.PerformLayout();
            addingPanel.ResumeLayout(false);
            addingPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView clientsTable;
        private Panel updatingPanel;
        private TextBox clientEmailUpdateText;
        private Label label2;
        private TextBox clientPhoneUpdateText;
        private Label Phone;
        private Button updateBtn;
        private TextBox clientFirstNameUpdateText;
        private TextBox clientLastNameUpdateText;
        private Label FirstName;
        private Label LastName;
        private TextBox clientIdUpdateText;
        private Label label1;
        private Button deleteBtn;
        private Button updatePanelBtn;
        private Button addPanelBtn;
        private Panel addingPanel;
        private TextBox loginText;
        private Label login;
        private TextBox clientEmailText;
        private Label clientEmail;
        private TextBox clientPhoneText;
        private Label clientPhone;
        private Button addBtn;
        private TextBox clientFirstNameText;
        private TextBox clientLastNameText;
        private Label clientFirstName;
        private Label clientLastName;
    }
}