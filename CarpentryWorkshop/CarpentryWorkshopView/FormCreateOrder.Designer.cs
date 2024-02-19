namespace CarpentryWorkshopView
{
    partial class FormCreateOrder
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
            labelWood = new Label();
            labelCount = new Label();
            labelSum = new Label();
            comboBoxWood = new ComboBox();
            textBoxCount = new TextBox();
            textBoxSum = new TextBox();
            ButtonSave = new Button();
            ButtonCancel = new Button();
            SuspendLayout();
            // 
            // labelWood
            // 
            labelWood.AutoSize = true;
            labelWood.Location = new Point(12, 8);
            labelWood.Name = "labelWood";
            labelWood.Size = new Size(53, 15);
            labelWood.TabIndex = 0;
            labelWood.Text = "Изделие";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(12, 37);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(72, 15);
            labelCount.TabIndex = 1;
            labelCount.Text = "Количество";
            // 
            // labelSum
            // 
            labelSum.AutoSize = true;
            labelSum.Location = new Point(12, 66);
            labelSum.Name = "labelSum";
            labelSum.Size = new Size(45, 15);
            labelSum.TabIndex = 2;
            labelSum.Text = "Сумма";
            // 
            // comboBoxWood
            // 
            comboBoxWood.FormattingEnabled = true;
            comboBoxWood.Location = new Point(121, 5);
            comboBoxWood.Name = "comboBoxWood";
            comboBoxWood.Size = new Size(292, 23);
            comboBoxWood.TabIndex = 3;
            comboBoxWood.SelectedIndexChanged += comboBoxWood_SelectedIndexChanged;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(121, 34);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(292, 23);
            textBoxCount.TabIndex = 4;
            textBoxCount.TextChanged += textBoxCount_TextChanged;
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(121, 63);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.Size = new Size(292, 23);
            textBoxSum.TabIndex = 5;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(257, 92);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(75, 23);
            ButtonSave.TabIndex = 6;
            ButtonSave.Text = "Сохранить";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(338, 92);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 7;
            ButtonCancel.Text = "Отмена";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // FormCreateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 126);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonSave);
            Controls.Add(textBoxSum);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxWood);
            Controls.Add(labelSum);
            Controls.Add(labelCount);
            Controls.Add(labelWood);
            Name = "FormCreateOrder";
            Text = "Заказ";
            Load += FormCreateOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelWood;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.ComboBox comboBoxWood;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
    }
}