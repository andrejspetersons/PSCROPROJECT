namespace P_K_accounting
{
    partial class CompanyService_Form
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
            companyserviceTable = new DataGridView();
            deleteBtn = new Button();
            addingPanel = new Panel();
            addBtn = new Button();
            ServiceNameAddText = new TextBox();
            ServiceNameAdd = new Label();
            updatePanelBtn = new Button();
            addPanelBtn = new Button();
            updatingPanel = new Panel();
            updateBtn = new Button();
            ServiceNameUpdateText = new TextBox();
            ServiceNameUpdate = new Label();
            ServiceIdUpdate = new TextBox();
            serviceId = new Label();
            ((System.ComponentModel.ISupportInitialize)companyserviceTable).BeginInit();
            addingPanel.SuspendLayout();
            updatingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // companyserviceTable
            // 
            companyserviceTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            companyserviceTable.Location = new Point(354, 75);
            companyserviceTable.Name = "companyserviceTable";
            companyserviceTable.ReadOnly = true;
            companyserviceTable.RowTemplate.Height = 25;
            companyserviceTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            companyserviceTable.Size = new Size(700, 250);
            companyserviceTable.TabIndex = 0;
            companyserviceTable.CellClick += companyserviceTable_CellClick;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(354, 364);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(199, 39);
            deleteBtn.TabIndex = 1;
            deleteBtn.Text = "Delete Service";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteServiceBtn_Click;
            // 
            // addingPanel
            // 
            addingPanel.Controls.Add(addBtn);
            addingPanel.Controls.Add(ServiceNameAddText);
            addingPanel.Controls.Add(ServiceNameAdd);
            addingPanel.Location = new Point(32, 75);
            addingPanel.Name = "addingPanel";
            addingPanel.Size = new Size(244, 166);
            addingPanel.TabIndex = 2;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(17, 109);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(199, 39);
            addBtn.TabIndex = 32;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addServiceBtn_Click;
            // 
            // ServiceNameAddText
            // 
            ServiceNameAddText.Location = new Point(17, 59);
            ServiceNameAddText.Name = "ServiceNameAddText";
            ServiceNameAddText.Size = new Size(199, 23);
            ServiceNameAddText.TabIndex = 30;
            // 
            // ServiceNameAdd
            // 
            ServiceNameAdd.AutoSize = true;
            ServiceNameAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ServiceNameAdd.ForeColor = SystemColors.Desktop;
            ServiceNameAdd.Location = new Point(17, 35);
            ServiceNameAdd.Name = "ServiceNameAdd";
            ServiceNameAdd.Size = new Size(102, 21);
            ServiceNameAdd.TabIndex = 29;
            ServiceNameAdd.Text = "ServiceName";
            // 
            // updatePanelBtn
            // 
            updatePanelBtn.Location = new Point(30, 516);
            updatePanelBtn.Name = "updatePanelBtn";
            updatePanelBtn.Size = new Size(199, 39);
            updatePanelBtn.TabIndex = 3;
            updatePanelBtn.Text = "Update Service";
            updatePanelBtn.UseVisualStyleBackColor = true;
            updatePanelBtn.Click += updatePanelBtn_Click;
            // 
            // addPanelBtn
            // 
            addPanelBtn.Location = new Point(30, 468);
            addPanelBtn.Name = "addPanelBtn";
            addPanelBtn.Size = new Size(199, 39);
            addPanelBtn.TabIndex = 4;
            addPanelBtn.Text = "Add Service";
            addPanelBtn.UseVisualStyleBackColor = true;
            addPanelBtn.Click += addPanelBtn_Click;
            // 
            // updatingPanel
            // 
            updatingPanel.Controls.Add(updateBtn);
            updatingPanel.Controls.Add(ServiceNameUpdateText);
            updatingPanel.Controls.Add(ServiceNameUpdate);
            updatingPanel.Controls.Add(ServiceIdUpdate);
            updatingPanel.Controls.Add(serviceId);
            updatingPanel.Location = new Point(1093, 134);
            updatingPanel.Name = "updatingPanel";
            updatingPanel.Size = new Size(244, 206);
            updatingPanel.TabIndex = 31;
            updatingPanel.Visible = false;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(17, 151);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(199, 39);
            updateBtn.TabIndex = 33;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateServiceBtn_Click;
            // 
            // ServiceNameUpdateText
            // 
            ServiceNameUpdateText.Location = new Point(17, 110);
            ServiceNameUpdateText.Name = "ServiceNameUpdateText";
            ServiceNameUpdateText.Size = new Size(199, 23);
            ServiceNameUpdateText.TabIndex = 32;
            // 
            // ServiceNameUpdate
            // 
            ServiceNameUpdate.AutoSize = true;
            ServiceNameUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ServiceNameUpdate.ForeColor = SystemColors.Desktop;
            ServiceNameUpdate.Location = new Point(17, 86);
            ServiceNameUpdate.Name = "ServiceNameUpdate";
            ServiceNameUpdate.Size = new Size(102, 21);
            ServiceNameUpdate.TabIndex = 31;
            ServiceNameUpdate.Text = "ServiceName";
            // 
            // ServiceIdUpdate
            // 
            ServiceIdUpdate.Location = new Point(17, 59);
            ServiceIdUpdate.Name = "ServiceIdUpdate";
            ServiceIdUpdate.ReadOnly = true;
            ServiceIdUpdate.Size = new Size(199, 23);
            ServiceIdUpdate.TabIndex = 30;
            ServiceIdUpdate.Text = "0";
            // 
            // serviceId
            // 
            serviceId.AutoSize = true;
            serviceId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            serviceId.ForeColor = SystemColors.Desktop;
            serviceId.Location = new Point(17, 35);
            serviceId.Name = "serviceId";
            serviceId.Size = new Size(73, 21);
            serviceId.TabIndex = 29;
            serviceId.Text = "ServiceId";
            // 
            // CompanyService_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1441, 571);
            Controls.Add(updatingPanel);
            Controls.Add(addPanelBtn);
            Controls.Add(updatePanelBtn);
            Controls.Add(addingPanel);
            Controls.Add(deleteBtn);
            Controls.Add(companyserviceTable);
            Name = "CompanyService_Form";
            Text = "CompanyService_Form";
            Load += CompanyService_Form_Load;
            ((System.ComponentModel.ISupportInitialize)companyserviceTable).EndInit();
            addingPanel.ResumeLayout(false);
            addingPanel.PerformLayout();
            updatingPanel.ResumeLayout(false);
            updatingPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView companyserviceTable;
        private Button deleteBtn;
        private Panel addingPanel;
        private TextBox ServiceNameAddText;
        private Label ServiceNameAdd;
        private Button updatePanelBtn;
        private Button addPanelBtn;
        private Panel updatingPanel;
        private TextBox ServiceNameUpdateText;
        private Label ServiceNameUpdate;
        private TextBox ServiceIdUpdate;
        private Label serviceId;
        private Button addBtn;
        private Button updateBtn;
    }
}