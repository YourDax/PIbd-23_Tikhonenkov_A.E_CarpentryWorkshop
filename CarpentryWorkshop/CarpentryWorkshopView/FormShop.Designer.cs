namespace CarpentryWorkshopView
{
    partial class FormShop
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
            DateTimePicker = new DateTimePicker();
            NameTextBox = new TextBox();
            AddressTextBox = new TextBox();
            NameLabel = new Label();
            AdressLabel = new Label();
            DateLabel = new Label();
            SaveButton = new Button();
            CancelButton = new Button();
            DataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Название = new DataGridViewTextBoxColumn();
            Цена = new DataGridViewTextBoxColumn();
            Количество = new DataGridViewTextBoxColumn();
            labelCapacity = new Label();
            numericUpWoodMaxCount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpWoodMaxCount).BeginInit();
            SuspendLayout();
            // 
            // DateTimePicker
            // 
            DateTimePicker.Location = new Point(98, 70);
            DateTimePicker.Name = "DateTimePicker";
            DateTimePicker.Size = new Size(305, 23);
            DateTimePicker.TabIndex = 0;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(98, 12);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(305, 23);
            NameTextBox.TabIndex = 1;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(98, 41);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(305, 23);
            AddressTextBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 15);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(59, 15);
            NameLabel.TabIndex = 3;
            NameLabel.Text = "Название";
            // 
            // AdressLabel
            // 
            AdressLabel.AutoSize = true;
            AdressLabel.Location = new Point(12, 44);
            AdressLabel.Name = "AdressLabel";
            AdressLabel.Size = new Size(40, 15);
            AdressLabel.TabIndex = 4;
            AdressLabel.Text = "Адрес";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(12, 76);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(32, 15);
            DateLabel.TabIndex = 5;
            DateLabel.Text = "Дата";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(248, 320);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(329, 320);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Название, Цена, Количество });
            DataGridView.Location = new Point(12, 139);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(391, 175);
            DataGridView.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // Название
            // 
            Название.HeaderText = "Название";
            Название.Name = "Название";
            Название.ReadOnly = true;
            Название.Width = 150;
            // 
            // Цена
            // 
            Цена.HeaderText = "Цена";
            Цена.Name = "Цена";
            Цена.ReadOnly = true;
            // 
            // Количество
            // 
            Количество.HeaderText = "Количество";
            Количество.Name = "Количество";
            Количество.ReadOnly = true;
            // 
            // labelCapacity
            // 
            labelCapacity.AutoSize = true;
            labelCapacity.Location = new Point(12, 103);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(80, 15);
            labelCapacity.TabIndex = 9;
            labelCapacity.Text = "Вместимость";
            // 
            // numericUpWoodMaxCount
            // 
            numericUpWoodMaxCount.Location = new Point(98, 101);
            numericUpWoodMaxCount.Margin = new Padding(3, 2, 3, 2);
            numericUpWoodMaxCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpWoodMaxCount.Name = "numericUpWoodMaxCount";
            numericUpWoodMaxCount.Size = new Size(305, 23);
            numericUpWoodMaxCount.TabIndex = 12;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 355);
            Controls.Add(numericUpWoodMaxCount);
            Controls.Add(labelCapacity);
            Controls.Add(DataGridView);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(DateLabel);
            Controls.Add(AdressLabel);
            Controls.Add(NameLabel);
            Controls.Add(AddressTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(DateTimePicker);
            Name = "FormShop";
            Text = "Редактор магазина";
            Load += ShopForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpWoodMaxCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker DateTimePicker;
        private TextBox NameTextBox;
        private TextBox AddressTextBox;
        private Label NameLabel;
        private Label AdressLabel;
        private Label DateLabel;
        private Button SaveButton;
        private Button CancelButton;
        private DataGridView DataGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Название;
        private DataGridViewTextBoxColumn Цена;
        private DataGridViewTextBoxColumn Количество;
        private Label labelCapacity;
        private NumericUpDown numericUpWoodMaxCount;
    }
}