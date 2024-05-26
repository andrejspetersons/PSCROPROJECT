namespace P_K_accounting
{
    partial class Accounting_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            clientDropDown = new ComboBox();
            client = new Label();
            serviceNameAdd = new Label();
            amountText = new TextBox();
            AmountAdd = new Label();
            clientBillsTable = new DataGridView();
            issueDateTimePicker = new DateTimePicker();
            IssueDateAdd = new Label();
            DueToDateAdd = new Label();
            duetoDateTimePicker = new DateTimePicker();
            addingPanelBtn = new Button();
            AddPanel = new Panel();
            serviceDropDown = new ComboBox();
            addBtn = new Button();
            UpdatePanel = new Panel();
            idUpdateText = new TextBox();
            IdUpdate = new Label();
            updateBtn = new Button();
            serviceNameUpdateText = new TextBox();
            issueDateUpdate = new Label();
            amountUpdateText = new TextBox();
            ServiceNameUpdate = new Label();
            updateIssueDateTimePicker = new DateTimePicker();
            updateDueToDateTimePicker = new DateTimePicker();
            dueToDateUpdate = new Label();
            Amountupdate = new Label();
            updatingPanelBtn = new Button();
            deleteBtn = new Button();
            getClientRecords = new Button();
            btnToClientsForm = new Button();
            btnToServiceForm = new Button();
            getServiceDropDownBtn = new Button();
            getClientDropDownBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)clientBillsTable).BeginInit();
            AddPanel.SuspendLayout();
            UpdatePanel.SuspendLayout();
            SuspendLayout();
            // 
            // clientDropDown
            // 
            clientDropDown.FormattingEnabled = true;
            clientDropDown.Location = new Point(88, 39);
            clientDropDown.Name = "clientDropDown";
            clientDropDown.Size = new Size(231, 23);
            clientDropDown.TabIndex = 1;
            clientDropDown.SelectedIndexChanged += clientDropDown_SelectedIndexChanged;
            // 
            // client
            // 
            client.AutoSize = true;
            client.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            client.ForeColor = SystemColors.Desktop;
            client.Location = new Point(32, 39);
            client.Name = "client";
            client.Size = new Size(50, 21);
            client.TabIndex = 2;
            client.Text = "Client";
            // 
            // serviceNameAdd
            // 
            serviceNameAdd.AutoSize = true;
            serviceNameAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            serviceNameAdd.ForeColor = SystemColors.Desktop;
            serviceNameAdd.Location = new Point(14, 28);
            serviceNameAdd.Name = "serviceNameAdd";
            serviceNameAdd.Size = new Size(102, 21);
            serviceNameAdd.TabIndex = 4;
            serviceNameAdd.Text = "ServiceName";
            // 
            // amountText
            // 
            amountText.Location = new Point(14, 107);
            amountText.Name = "amountText";
            amountText.Size = new Size(199, 23);
            amountText.TabIndex = 13;
            // 
            // AmountAdd
            // 
            AmountAdd.AutoSize = true;
            AmountAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AmountAdd.ForeColor = SystemColors.Desktop;
            AmountAdd.Location = new Point(14, 83);
            AmountAdd.Name = "AmountAdd";
            AmountAdd.Size = new Size(66, 21);
            AmountAdd.TabIndex = 12;
            AmountAdd.Text = "Amount";
            // 
            // clientBillsTable
            // 
            clientBillsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientBillsTable.Location = new Point(286, 95);
            clientBillsTable.Name = "clientBillsTable";
            clientBillsTable.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            clientBillsTable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            clientBillsTable.RowTemplate.Height = 25;
            clientBillsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientBillsTable.Size = new Size(700, 250);
            clientBillsTable.TabIndex = 3;
            clientBillsTable.CellClick += clientBillsTable_CellClick;
            clientBillsTable.ColumnHeaderMouseClick += clientBillsTable_ColumnHeaderMouseClick;
            clientBillsTable.RowPrePaint += clientBillsTable_RowPrePaint;
            // 
            // issueDateTimePicker
            // 
            issueDateTimePicker.Location = new Point(14, 157);
            issueDateTimePicker.Name = "issueDateTimePicker";
            issueDateTimePicker.Size = new Size(200, 23);
            issueDateTimePicker.TabIndex = 14;
            // 
            // IssueDateAdd
            // 
            IssueDateAdd.AutoSize = true;
            IssueDateAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IssueDateAdd.ForeColor = SystemColors.Desktop;
            IssueDateAdd.Location = new Point(13, 133);
            IssueDateAdd.Name = "IssueDateAdd";
            IssueDateAdd.Size = new Size(77, 21);
            IssueDateAdd.TabIndex = 15;
            IssueDateAdd.Text = "IssueDate";
            // 
            // DueToDateAdd
            // 
            DueToDateAdd.AutoSize = true;
            DueToDateAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DueToDateAdd.ForeColor = SystemColors.Desktop;
            DueToDateAdd.Location = new Point(13, 192);
            DueToDateAdd.Name = "DueToDateAdd";
            DueToDateAdd.Size = new Size(85, 21);
            DueToDateAdd.TabIndex = 17;
            DueToDateAdd.Text = "DueToDate";
            // 
            // duetoDateTimePicker
            // 
            duetoDateTimePicker.Location = new Point(14, 216);
            duetoDateTimePicker.Name = "duetoDateTimePicker";
            duetoDateTimePicker.Size = new Size(200, 23);
            duetoDateTimePicker.TabIndex = 16;
            // 
            // addingPanelBtn
            // 
            addingPanelBtn.ForeColor = SystemColors.Desktop;
            addingPanelBtn.Location = new Point(30, 468);
            addingPanelBtn.Name = "addingPanelBtn";
            addingPanelBtn.Size = new Size(199, 39);
            addingPanelBtn.TabIndex = 18;
            addingPanelBtn.Text = "Add Bill";
            addingPanelBtn.UseVisualStyleBackColor = true;
            addingPanelBtn.Click += addingPanelBtn_Click;
            // 
            // AddPanel
            // 
            AddPanel.BackColor = Color.Transparent;
            AddPanel.Controls.Add(serviceDropDown);
            AddPanel.Controls.Add(addBtn);
            AddPanel.Controls.Add(IssueDateAdd);
            AddPanel.Controls.Add(amountText);
            AddPanel.Controls.Add(serviceNameAdd);
            AddPanel.Controls.Add(issueDateTimePicker);
            AddPanel.Controls.Add(duetoDateTimePicker);
            AddPanel.Controls.Add(DueToDateAdd);
            AddPanel.Controls.Add(AmountAdd);
            AddPanel.Location = new Point(12, 92);
            AddPanel.Name = "AddPanel";
            AddPanel.Size = new Size(244, 320);
            AddPanel.TabIndex = 19;
            // 
            // serviceDropDown
            // 
            serviceDropDown.FormattingEnabled = true;
            serviceDropDown.Location = new Point(13, 52);
            serviceDropDown.Name = "serviceDropDown";
            serviceDropDown.Size = new Size(199, 23);
            serviceDropDown.TabIndex = 29;
            // 
            // addBtn
            // 
            addBtn.ForeColor = SystemColors.Desktop;
            addBtn.Location = new Point(14, 251);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(199, 39);
            addBtn.TabIndex = 22;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // UpdatePanel
            // 
            UpdatePanel.Controls.Add(idUpdateText);
            UpdatePanel.Controls.Add(IdUpdate);
            UpdatePanel.Controls.Add(updateBtn);
            UpdatePanel.Controls.Add(serviceNameUpdateText);
            UpdatePanel.Controls.Add(issueDateUpdate);
            UpdatePanel.Controls.Add(amountUpdateText);
            UpdatePanel.Controls.Add(ServiceNameUpdate);
            UpdatePanel.Controls.Add(updateIssueDateTimePicker);
            UpdatePanel.Controls.Add(updateDueToDateTimePicker);
            UpdatePanel.Controls.Add(dueToDateUpdate);
            UpdatePanel.Controls.Add(Amountupdate);
            UpdatePanel.Location = new Point(1123, 92);
            UpdatePanel.Name = "UpdatePanel";
            UpdatePanel.Size = new Size(244, 401);
            UpdatePanel.TabIndex = 20;
            UpdatePanel.Visible = false;
            // 
            // idUpdateText
            // 
            idUpdateText.Location = new Point(19, 47);
            idUpdateText.Name = "idUpdateText";
            idUpdateText.Size = new Size(199, 23);
            idUpdateText.TabIndex = 25;
            idUpdateText.Text = "0";
            // 
            // IdUpdate
            // 
            IdUpdate.AutoSize = true;
            IdUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IdUpdate.ForeColor = SystemColors.Desktop;
            IdUpdate.Location = new Point(19, 23);
            IdUpdate.Name = "IdUpdate";
            IdUpdate.Size = new Size(104, 21);
            IdUpdate.TabIndex = 24;
            IdUpdate.Text = "PaymentBillId";
            // 
            // updateBtn
            // 
            updateBtn.ForeColor = SystemColors.Desktop;
            updateBtn.Location = new Point(19, 333);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(199, 39);
            updateBtn.TabIndex = 23;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // serviceNameUpdateText
            // 
            serviceNameUpdateText.Location = new Point(18, 107);
            serviceNameUpdateText.Name = "serviceNameUpdateText";
            serviceNameUpdateText.Size = new Size(199, 23);
            serviceNameUpdateText.TabIndex = 5;
            // 
            // issueDateUpdate
            // 
            issueDateUpdate.AutoSize = true;
            issueDateUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            issueDateUpdate.ForeColor = SystemColors.Desktop;
            issueDateUpdate.Location = new Point(18, 204);
            issueDateUpdate.Name = "issueDateUpdate";
            issueDateUpdate.Size = new Size(77, 21);
            issueDateUpdate.TabIndex = 15;
            issueDateUpdate.Text = "IssueDate";
            // 
            // amountUpdateText
            // 
            amountUpdateText.Location = new Point(18, 170);
            amountUpdateText.Name = "amountUpdateText";
            amountUpdateText.Size = new Size(199, 23);
            amountUpdateText.TabIndex = 13;
            // 
            // ServiceNameUpdate
            // 
            ServiceNameUpdate.AutoSize = true;
            ServiceNameUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ServiceNameUpdate.ForeColor = SystemColors.Desktop;
            ServiceNameUpdate.Location = new Point(18, 83);
            ServiceNameUpdate.Name = "ServiceNameUpdate";
            ServiceNameUpdate.Size = new Size(102, 21);
            ServiceNameUpdate.TabIndex = 4;
            ServiceNameUpdate.Text = "ServiceName";
            // 
            // updateIssueDateTimePicker
            // 
            updateIssueDateTimePicker.Location = new Point(17, 228);
            updateIssueDateTimePicker.Name = "updateIssueDateTimePicker";
            updateIssueDateTimePicker.Size = new Size(200, 23);
            updateIssueDateTimePicker.TabIndex = 14;
            // 
            // updateDueToDateTimePicker
            // 
            updateDueToDateTimePicker.Location = new Point(18, 293);
            updateDueToDateTimePicker.Name = "updateDueToDateTimePicker";
            updateDueToDateTimePicker.Size = new Size(200, 23);
            updateDueToDateTimePicker.TabIndex = 16;
            // 
            // dueToDateUpdate
            // 
            dueToDateUpdate.AutoSize = true;
            dueToDateUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dueToDateUpdate.ForeColor = SystemColors.Desktop;
            dueToDateUpdate.Location = new Point(19, 269);
            dueToDateUpdate.Name = "dueToDateUpdate";
            dueToDateUpdate.Size = new Size(85, 21);
            dueToDateUpdate.TabIndex = 17;
            dueToDateUpdate.Text = "DueToDate";
            // 
            // Amountupdate
            // 
            Amountupdate.AutoSize = true;
            Amountupdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Amountupdate.ForeColor = SystemColors.Desktop;
            Amountupdate.Location = new Point(18, 146);
            Amountupdate.Name = "Amountupdate";
            Amountupdate.Size = new Size(66, 21);
            Amountupdate.TabIndex = 12;
            Amountupdate.Text = "Amount";
            // 
            // updatingPanelBtn
            // 
            updatingPanelBtn.ForeColor = SystemColors.Desktop;
            updatingPanelBtn.Location = new Point(30, 516);
            updatingPanelBtn.Name = "updatingPanelBtn";
            updatingPanelBtn.Size = new Size(199, 39);
            updatingPanelBtn.TabIndex = 21;
            updatingPanelBtn.Text = "Update Bill";
            updatingPanelBtn.UseVisualStyleBackColor = true;
            updatingPanelBtn.Click += updatingPanelBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.ForeColor = SystemColors.Desktop;
            deleteBtn.Location = new Point(286, 379);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(199, 39);
            deleteBtn.TabIndex = 23;
            deleteBtn.Text = "Delete Bill";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBillBtn_Click;
            // 
            // getClientRecords
            // 
            getClientRecords.ForeColor = SystemColors.Desktop;
            getClientRecords.Location = new Point(827, 30);
            getClientRecords.Name = "getClientRecords";
            getClientRecords.Size = new Size(199, 39);
            getClientRecords.TabIndex = 26;
            getClientRecords.Text = "GetClientRecords";
            getClientRecords.UseVisualStyleBackColor = true;
            getClientRecords.Click += getClientRecords_Click;
            // 
            // btnToClientsForm
            // 
            btnToClientsForm.ForeColor = SystemColors.Desktop;
            btnToClientsForm.Location = new Point(1059, 30);
            btnToClientsForm.Name = "btnToClientsForm";
            btnToClientsForm.Size = new Size(199, 39);
            btnToClientsForm.TabIndex = 27;
            btnToClientsForm.Text = "ManageClientsForm";
            btnToClientsForm.UseVisualStyleBackColor = true;
            btnToClientsForm.Click += btnToClientsForm_Click;
            // 
            // btnToServiceForm
            // 
            btnToServiceForm.ForeColor = SystemColors.Desktop;
            btnToServiceForm.Location = new Point(1291, 30);
            btnToServiceForm.Name = "btnToServiceForm";
            btnToServiceForm.Size = new Size(199, 39);
            btnToServiceForm.TabIndex = 28;
            btnToServiceForm.Text = "ManageServiceForm";
            btnToServiceForm.UseVisualStyleBackColor = true;
            btnToServiceForm.Click += btnToServiceForm_Click;
            // 
            // getServiceDropDownBtn
            // 
            getServiceDropDownBtn.ForeColor = SystemColors.Desktop;
            getServiceDropDownBtn.Location = new Point(594, 30);
            getServiceDropDownBtn.Name = "getServiceDropDownBtn";
            getServiceDropDownBtn.Size = new Size(199, 39);
            getServiceDropDownBtn.TabIndex = 29;
            getServiceDropDownBtn.Text = "GetServiceDropDown";
            getServiceDropDownBtn.UseVisualStyleBackColor = true;
            getServiceDropDownBtn.Click += getServiceDropDownBtn_Click;
            // 
            // getClientDropDownBtn
            // 
            getClientDropDownBtn.ForeColor = SystemColors.Desktop;
            getClientDropDownBtn.Location = new Point(364, 30);
            getClientDropDownBtn.Name = "getClientDropDownBtn";
            getClientDropDownBtn.Size = new Size(199, 39);
            getClientDropDownBtn.TabIndex = 30;
            getClientDropDownBtn.Text = "GetClientDropDown";
            getClientDropDownBtn.UseVisualStyleBackColor = true;
            getClientDropDownBtn.Click += getClientDropDownBtn_Click;
            // 
            // Accounting_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1760, 818);
            Controls.Add(getClientDropDownBtn);
            Controls.Add(getServiceDropDownBtn);
            Controls.Add(btnToServiceForm);
            Controls.Add(btnToClientsForm);
            Controls.Add(getClientRecords);
            Controls.Add(deleteBtn);
            Controls.Add(UpdatePanel);
            Controls.Add(updatingPanelBtn);
            Controls.Add(addingPanelBtn);
            Controls.Add(clientBillsTable);
            Controls.Add(client);
            Controls.Add(clientDropDown);
            Controls.Add(AddPanel);
            ForeColor = SystemColors.HighlightText;
            Name = "Accounting_Form";
            Text = "Form1";
            Load += Accounting_Form_Load;
            ((System.ComponentModel.ISupportInitialize)clientBillsTable).EndInit();
            AddPanel.ResumeLayout(false);
            AddPanel.PerformLayout();
            UpdatePanel.ResumeLayout(false);
            UpdatePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox clientDropDown;
        private Label client;
        private Label serviceNameAdd;
        private TextBox amountText;
        private Label AmountAdd;
        private DataGridView clientBillsTable;
        private DateTimePicker issueDateTimePicker;
        private Label IssueDateAdd;
        private Label DueToDateAdd;
        private DateTimePicker duetoDateTimePicker;
        private Button addingPanelBtn;
        private Panel AddPanel;
        private Panel UpdatePanel;
        private TextBox serviceNameUpdateText;
        private Label issueDateUpdate;
        private TextBox amountUpdateText;
        private Label ServiceNameUpdate;
        private DateTimePicker updateIssueDateTimePicker;
        private DateTimePicker updateDueToDateTimePicker;
        private Label dueToDateUpdate;
        private Label Amountupdate;
        private Button updatingPanelBtn;
        private Button addBtn;
        private Button updateBtn;
        private TextBox idUpdateText;
        private Label IdUpdate;
        private Button deleteBtn;
        private Button getClientRecords;
        private Button btnToClientsForm;
        private Button btnToServiceForm;
        private ComboBox serviceDropDown;
        private Button getServiceDropDownBtn;
        private Button getClientDropDownBtn;
    }
}
