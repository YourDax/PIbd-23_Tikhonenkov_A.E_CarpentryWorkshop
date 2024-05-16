namespace CarpentryWorkshopView
{
    partial class FormShops
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
            DataGridView = new DataGridView();
            AddButton = new Button();
            UpdateButton = new Button();
            RefreshButton = new Button();
            DeleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            SuspendLayout();
            // 
            // DataGridView
            // 
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Location = new Point(12, 12);
            DataGridView.Name = "DataGridView";
            DataGridView.Size = new Size(393, 374);
            DataGridView.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(411, 12);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(114, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(411, 41);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(114, 23);
            UpdateButton.TabIndex = 2;
            UpdateButton.Text = "Изменить";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(411, 70);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(114, 23);
            RefreshButton.TabIndex = 3;
            RefreshButton.Text = "Обновить";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(411, 99);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(114, 23);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // FormShops
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 403);
            Controls.Add(DeleteButton);
            Controls.Add(RefreshButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Controls.Add(DataGridView);
            Name = "FormShops";
            Text = "Магазины";
            Load += ShopsForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridView;
        private Button AddButton;
        private Button UpdateButton;
        private Button RefreshButton;
        private Button DeleteButton;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}