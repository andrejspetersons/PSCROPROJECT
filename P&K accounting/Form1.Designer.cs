namespace P_K_accounting
{
    partial class Form1
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
            clientDropDown = new ComboBox();
            client = new Label();
            service = new Label();
            serviceDropDown = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            issueDatePicker = new DateTimePicker();
            payToDatePicker = new DateTimePicker();
            submitbill = new Button();
            amount = new Label();
            amountTextBox = new TextBox();
            SuspendLayout();
            // 
            // clientDropDown
            // 
            clientDropDown.FormattingEnabled = true;
            clientDropDown.Items.AddRange(new object[] { "Test3", "Test4" });
            clientDropDown.Location = new Point(88, 39);
            clientDropDown.Name = "clientDropDown";
            clientDropDown.Size = new Size(231, 23);
            clientDropDown.TabIndex = 1;
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
            // service
            // 
            service.AutoSize = true;
            service.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            service.ForeColor = SystemColors.Desktop;
            service.Location = new Point(22, 70);
            service.Name = "service";
            service.Size = new Size(60, 21);
            service.TabIndex = 4;
            service.Text = "Service";
            // 
            // serviceDropDown
            // 
            serviceDropDown.FormattingEnabled = true;
            serviceDropDown.Items.AddRange(new object[] { "Test", "Test2" });
            serviceDropDown.Location = new Point(88, 68);
            serviceDropDown.Name = "serviceDropDown";
            serviceDropDown.Size = new Size(231, 23);
            serviceDropDown.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(5, 218);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 6;
            label3.Text = "PayToDate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(5, 187);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 5;
            label4.Text = "IssueDate";
            // 
            // issueDatePicker
            // 
            issueDatePicker.CalendarMonthBackground = SystemColors.InfoText;
            issueDatePicker.CustomFormat = "dd.MM.yyyy";
            issueDatePicker.Format = DateTimePickerFormat.Custom;
            issueDatePicker.Location = new Point(88, 185);
            issueDatePicker.Name = "issueDatePicker";
            issueDatePicker.Size = new Size(200, 23);
            issueDatePicker.TabIndex = 7;
            // 
            // payToDatePicker
            // 
            payToDatePicker.CalendarMonthBackground = SystemColors.InfoText;
            payToDatePicker.CustomFormat = "dd.MM.yyyy";
            payToDatePicker.Format = DateTimePickerFormat.Custom;
            payToDatePicker.Location = new Point(88, 218);
            payToDatePicker.Name = "payToDatePicker";
            payToDatePicker.Size = new Size(200, 23);
            payToDatePicker.TabIndex = 8;
            // 
            // submitbill
            // 
            submitbill.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            submitbill.ForeColor = SystemColors.InfoText;
            submitbill.Location = new Point(639, 278);
            submitbill.Name = "submitbill";
            submitbill.Size = new Size(149, 46);
            submitbill.TabIndex = 0;
            submitbill.Text = "SUBMIT BILL";
            submitbill.UseVisualStyleBackColor = true;
            submitbill.Click += submitbill_Click;
            // 
            // amount
            // 
            amount.AutoSize = true;
            amount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            amount.ForeColor = SystemColors.Desktop;
            amount.Location = new Point(16, 99);
            amount.Name = "amount";
            amount.Size = new Size(66, 21);
            amount.TabIndex = 11;
            amount.Text = "Amount";
            // 
            // amountTextBox
            // 
            amountTextBox.Location = new Point(88, 97);
            amountTextBox.Name = "amountTextBox";
            amountTextBox.Size = new Size(231, 23);
            amountTextBox.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(amountTextBox);
            Controls.Add(amount);
            Controls.Add(payToDatePicker);
            Controls.Add(issueDatePicker);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(service);
            Controls.Add(serviceDropDown);
            Controls.Add(client);
            Controls.Add(clientDropDown);
            Controls.Add(submitbill);
            ForeColor = SystemColors.HighlightText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox clientDropDown;
        private Label client;
        private Label service;
        private ComboBox serviceDropDown;
        private Label label3;
        private Label label4;
        private DateTimePicker issueDatePicker;
        private DateTimePicker payToDatePicker;
        private Button submitbill;
        private Label amount;
        private TextBox amountTextBox;
    }
}
