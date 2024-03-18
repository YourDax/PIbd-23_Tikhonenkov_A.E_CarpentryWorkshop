namespace CarpentryWorkshopView
{
    partial class FormSupply
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
            ShopComboBox = new ComboBox();
            WoodComboBox = new ComboBox();
            CountTextBox = new TextBox();
            SaveButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // ShopComboBox
            // 
            ShopComboBox.FormattingEnabled = true;
            ShopComboBox.Location = new Point(12, 12);
            ShopComboBox.Name = "ShopComboBox";
            ShopComboBox.Size = new Size(331, 23);
            ShopComboBox.TabIndex = 0;
            ShopComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ShopComboBox.FormattingEnabled = true;
            // 
            // WoodComboBox
            // 
            WoodComboBox.FormattingEnabled = true;
            WoodComboBox.Location = new Point(12, 41);
            WoodComboBox.Name = "WoodComboBox";
            WoodComboBox.Size = new Size(331, 23);
            WoodComboBox.TabIndex = 1;
            WoodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            WoodComboBox.FormattingEnabled = true;
            // 
            // CountTextBox
            // 
            CountTextBox.Location = new Point(12, 70);
            CountTextBox.Name = "CountTextBox";
            CountTextBox.Size = new Size(331, 23);
            CountTextBox.TabIndex = 2;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(187, 99);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(268, 99);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // FormSupply
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 136);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(CountTextBox);
            Controls.Add(WoodComboBox);
            Controls.Add(ShopComboBox);
            Name = "FormSupply";
            Text = "SupplyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ShopComboBox;
        private ComboBox WoodComboBox;
        private TextBox CountTextBox;
        private Button SaveButton;
        private Button CancelButton;
    }
}