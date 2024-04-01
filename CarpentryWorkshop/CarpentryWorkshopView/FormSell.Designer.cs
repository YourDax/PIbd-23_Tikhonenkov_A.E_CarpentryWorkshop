namespace CarpentryWorkshopView
{
    partial class FormSell
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
            comboBoxWood = new ComboBox();
            labelCount = new Label();
            textBoxCount = new TextBox();
            buttonSell = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelWood
            // 
            labelWood.AutoSize = true;
            labelWood.Location = new Point(10, 10);
            labelWood.Name = "labelWood";
            labelWood.Size = new Size(59, 15);
            labelWood.TabIndex = 0;
            labelWood.Text = "Изделие: ";
            // 
            // comboBoxWood
            // 
            comboBoxWood.FormattingEnabled = true;
            comboBoxWood.Location = new Point(101, 8);
            comboBoxWood.Margin = new Padding(3, 2, 3, 2);
            comboBoxWood.Name = "comboBoxWood";
            comboBoxWood.Size = new Size(210, 23);
            comboBoxWood.TabIndex = 1;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(10, 41);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(78, 15);
            labelCount.TabIndex = 2;
            labelCount.Text = "Количество: ";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(101, 39);
            textBoxCount.Margin = new Padding(3, 2, 3, 2);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(210, 23);
            textBoxCount.TabIndex = 3;
            // 
            // buttonSell
            // 
            buttonSell.Location = new Point(112, 74);
            buttonSell.Margin = new Padding(3, 2, 3, 2);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(82, 22);
            buttonSell.TabIndex = 4;
            buttonSell.Text = "Продать";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += ButtonSell_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(212, 74);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormSell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 105);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSell);
            Controls.Add(textBoxCount);
            Controls.Add(labelCount);
            Controls.Add(comboBoxWood);
            Controls.Add(labelWood);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSell";
            Text = "Продажа изделий";
            Load += FormSellingPizza_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWood;
        private ComboBox comboBoxWood;
        private Label labelCount;
        private TextBox textBoxCount;
        private Button buttonSell;
        private Button buttonCancel;
    }
}