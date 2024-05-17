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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            clientDropDown = new ComboBox();
            client = new Label();
            ServiceNameAdd = new Label();
            ServiceNameText = new TextBox();
            AmountText = new TextBox();
            AmountAdd = new Label();
            clientBillsTable = new DataGridView();
            issueDateTimePicker = new DateTimePicker();
            IssueDateAdd = new Label();
            DueToDateAdd = new Label();
            duetoDateTimePicker = new DateTimePicker();
            addingPanel = new Button();
            AddPanel = new Panel();
            addBtn = new Button();
            UpdatePanel = new Panel();
            IdUpdateText = new TextBox();
            IdUpdate = new Label();
            updateBtn = new Button();
            ServiceNameUpdateText = new TextBox();
            issueDateUpdate = new Label();
            AmountUpdateText = new TextBox();
            ServiceNameUpdate = new Label();
            updateIssueDateTimePicker = new DateTimePicker();
            updateDueToDateTimPicker = new DateTimePicker();
            dueToDateUpdate = new Label();
            Amountupdate = new Label();
            updatingPanel = new Button();
            button1 = new Button();
            deleteBillBtn = new Button();
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
            // ServiceNameAdd
            // 
            ServiceNameAdd.AutoSize = true;
            ServiceNameAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ServiceNameAdd.ForeColor = SystemColors.Desktop;
            ServiceNameAdd.Location = new Point(14, 28);
            ServiceNameAdd.Name = "ServiceNameAdd";
            ServiceNameAdd.Size = new Size(102, 21);
            ServiceNameAdd.TabIndex = 4;
            ServiceNameAdd.Text = "ServiceName";
            // 
            // ServiceNameText
            // 
            ServiceNameText.Location = new Point(14, 52);
            ServiceNameText.Name = "ServiceNameText";
            ServiceNameText.Size = new Size(199, 23);
            ServiceNameText.TabIndex = 5;
            // 
            // AmountText
            // 
            AmountText.Location = new Point(14, 115);
            AmountText.Name = "AmountText";
            AmountText.Size = new Size(199, 23);
            AmountText.TabIndex = 13;
            // 
            // AmountAdd
            // 
            AmountAdd.AutoSize = true;
            AmountAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AmountAdd.ForeColor = SystemColors.Desktop;
            AmountAdd.Location = new Point(14, 91);
            AmountAdd.Name = "AmountAdd";
            AmountAdd.Size = new Size(66, 21);
            AmountAdd.TabIndex = 12;
            AmountAdd.Text = "Amount";
            // 
            // clientBillsTable
            // 
            clientBillsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientBillsTable.Location = new Point(286, 111);
            clientBillsTable.Name = "clientBillsTable";
            clientBillsTable.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            clientBillsTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            clientBillsTable.RowTemplate.Height = 25;
            clientBillsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientBillsTable.Size = new Size(707, 248);
            clientBillsTable.TabIndex = 3;
            clientBillsTable.CellClick += clientBillsTable_CellClick;
            clientBillsTable.ColumnHeaderMouseClick += clientBillsTable_ColumnHeaderMouseClick;
            clientBillsTable.RowPrePaint += clientBillsTable_RowPrePaint;
            // 
            // issueDateTimePicker
            // 
            issueDateTimePicker.Location = new Point(13, 173);
            issueDateTimePicker.Name = "issueDateTimePicker";
            issueDateTimePicker.Size = new Size(200, 23);
            issueDateTimePicker.TabIndex = 14;
            // 
            // IssueDateAdd
            // 
            IssueDateAdd.AutoSize = true;
            IssueDateAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IssueDateAdd.ForeColor = SystemColors.Desktop;
            IssueDateAdd.Location = new Point(14, 149);
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
            DueToDateAdd.Location = new Point(15, 214);
            DueToDateAdd.Name = "DueToDateAdd";
            DueToDateAdd.Size = new Size(85, 21);
            DueToDateAdd.TabIndex = 17;
            DueToDateAdd.Text = "DueToDate";
            // 
            // duetoDateTimePicker
            // 
            duetoDateTimePicker.Location = new Point(14, 238);
            duetoDateTimePicker.Name = "duetoDateTimePicker";
            duetoDateTimePicker.Size = new Size(200, 23);
            duetoDateTimePicker.TabIndex = 16;
            // 
            // addingPanel
            // 
            addingPanel.ForeColor = SystemColors.Desktop;
            addingPanel.Location = new Point(25, 556);
            addingPanel.Name = "addingPanel";
            addingPanel.Size = new Size(199, 39);
            addingPanel.TabIndex = 18;
            addingPanel.Text = "Add Bill";
            addingPanel.UseVisualStyleBackColor = true;
            addingPanel.Click += addingPanel_Click;
            // 
            // AddPanel
            // 
            AddPanel.BackColor = Color.Transparent;
            AddPanel.Controls.Add(addBtn);
            AddPanel.Controls.Add(ServiceNameText);
            AddPanel.Controls.Add(IssueDateAdd);
            AddPanel.Controls.Add(AmountText);
            AddPanel.Controls.Add(ServiceNameAdd);
            AddPanel.Controls.Add(issueDateTimePicker);
            AddPanel.Controls.Add(duetoDateTimePicker);
            AddPanel.Controls.Add(DueToDateAdd);
            AddPanel.Controls.Add(AmountAdd);
            AddPanel.Location = new Point(12, 92);
            AddPanel.Name = "AddPanel";
            AddPanel.Size = new Size(244, 320);
            AddPanel.TabIndex = 19;
            // 
            // addBtn
            // 
            addBtn.ForeColor = SystemColors.Desktop;
            addBtn.Location = new Point(15, 267);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(199, 39);
            addBtn.TabIndex = 22;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // UpdatePanel
            // 
            UpdatePanel.Controls.Add(IdUpdateText);
            UpdatePanel.Controls.Add(IdUpdate);
            UpdatePanel.Controls.Add(updateBtn);
            UpdatePanel.Controls.Add(ServiceNameUpdateText);
            UpdatePanel.Controls.Add(issueDateUpdate);
            UpdatePanel.Controls.Add(AmountUpdateText);
            UpdatePanel.Controls.Add(ServiceNameUpdate);
            UpdatePanel.Controls.Add(updateIssueDateTimePicker);
            UpdatePanel.Controls.Add(updateDueToDateTimPicker);
            UpdatePanel.Controls.Add(dueToDateUpdate);
            UpdatePanel.Controls.Add(Amountupdate);
            UpdatePanel.Location = new Point(1123, 92);
            UpdatePanel.Name = "UpdatePanel";
            UpdatePanel.Size = new Size(244, 401);
            UpdatePanel.TabIndex = 20;
            UpdatePanel.Visible = false;
            // 
            // IdUpdateText
            // 
            IdUpdateText.Location = new Point(19, 47);
            IdUpdateText.Name = "IdUpdateText";
            IdUpdateText.Size = new Size(199, 23);
            IdUpdateText.TabIndex = 25;
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
            updateBtn.Location = new Point(19, 322);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(199, 39);
            updateBtn.TabIndex = 23;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // ServiceNameUpdateText
            // 
            ServiceNameUpdateText.Location = new Point(18, 107);
            ServiceNameUpdateText.Name = "ServiceNameUpdateText";
            ServiceNameUpdateText.Size = new Size(199, 23);
            ServiceNameUpdateText.TabIndex = 5;
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
            // AmountUpdateText
            // 
            AmountUpdateText.Location = new Point(18, 170);
            AmountUpdateText.Name = "AmountUpdateText";
            AmountUpdateText.Size = new Size(199, 23);
            AmountUpdateText.TabIndex = 13;
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
            // updateDueToDateTimPicker
            // 
            updateDueToDateTimPicker.Location = new Point(18, 293);
            updateDueToDateTimPicker.Name = "updateDueToDateTimPicker";
            updateDueToDateTimPicker.Size = new Size(200, 23);
            updateDueToDateTimPicker.TabIndex = 16;
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
            // updatingPanel
            // 
            updatingPanel.ForeColor = SystemColors.Desktop;
            updatingPanel.Location = new Point(286, 556);
            updatingPanel.Name = "updatingPanel";
            updatingPanel.Size = new Size(199, 39);
            updatingPanel.TabIndex = 21;
            updatingPanel.Text = "Update Bill";
            updatingPanel.UseVisualStyleBackColor = true;
            updatingPanel.Click += updatingPanel_Click;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.Desktop;
            button1.Location = new Point(373, 32);
            button1.Name = "button1";
            button1.Size = new Size(199, 39);
            button1.TabIndex = 22;
            button1.Text = "GetClientRecords";
            button1.UseVisualStyleBackColor = true;
            // 
            // deleteBillBtn
            // 
            deleteBillBtn.ForeColor = SystemColors.Desktop;
            deleteBillBtn.Location = new Point(588, 556);
            deleteBillBtn.Name = "deleteBillBtn";
            deleteBillBtn.Size = new Size(199, 39);
            deleteBillBtn.TabIndex = 23;
            deleteBillBtn.Text = "Delete Bill";
            deleteBillBtn.UseVisualStyleBackColor = true;
            deleteBillBtn.Click += deleteBillBtn_Click;
            // 
            // Accounting_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1553, 650);
            Controls.Add(deleteBillBtn);
            Controls.Add(button1);
            Controls.Add(UpdatePanel);
            Controls.Add(updatingPanel);
            Controls.Add(addingPanel);
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
        private Label ServiceNameAdd;
        private TextBox ServiceNameText;
        private TextBox AmountText;
        private Label AmountAdd;
        private DataGridView clientBillsTable;
        private DateTimePicker issueDateTimePicker;
        private Label IssueDateAdd;
        private Label DueToDateAdd;
        private DateTimePicker duetoDateTimePicker;
        private Button addingPanel;
        private Panel AddPanel;
        private Panel UpdatePanel;
        private TextBox ServiceNameUpdateText;
        private Label issueDateUpdate;
        private TextBox AmountUpdateText;
        private Label ServiceNameUpdate;
        private DateTimePicker updateIssueDateTimePicker;
        private DateTimePicker updateDueToDateTimPicker;
        private Label dueToDateUpdate;
        private Label Amountupdate;
        private Button updatingPanel;
        private Button addBtn;
        private Button updateBtn;
        private Button button1;
        private TextBox IdUpdateText;
        private Label IdUpdate;
        private Button deleteBillBtn;
    }
}
