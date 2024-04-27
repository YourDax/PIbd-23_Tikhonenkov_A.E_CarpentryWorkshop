namespace CarpentryWorkshopView
{
	partial class FormImplementer
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
			labelFIO = new Label();
			labelPassword = new Label();
			labelWorkExperience = new Label();
			labelQualification = new Label();
			textBoxPassword = new TextBox();
			textBoxFIO = new TextBox();
			textBoxWorkExperience = new TextBox();
			textBoxQualification = new TextBox();
			buttonSave = new Button();
			buttonCancel = new Button();
			SuspendLayout();
			// 
			// labelFIO
			// 
			labelFIO.AutoSize = true;
			labelFIO.Location = new Point(10, 11);
			labelFIO.Name = "labelFIO";
			labelFIO.Size = new Size(34, 15);
			labelFIO.TabIndex = 0;
			labelFIO.Text = "ФИО";
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(10, 36);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(49, 15);
			labelPassword.TabIndex = 1;
			labelPassword.Text = "Пароль";
			// 
			// labelWorkExperience
			// 
			labelWorkExperience.AutoSize = true;
			labelWorkExperience.Location = new Point(10, 61);
			labelWorkExperience.Name = "labelWorkExperience";
			labelWorkExperience.Size = new Size(79, 15);
			labelWorkExperience.TabIndex = 2;
			labelWorkExperience.Text = "Стаж работы";
			// 
			// labelQualification
			// 
			labelQualification.AutoSize = true;
			labelQualification.Location = new Point(10, 86);
			labelQualification.Name = "labelQualification";
			labelQualification.Size = new Size(88, 15);
			labelQualification.TabIndex = 3;
			labelQualification.Text = "Квалификация";
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(113, 34);
			textBoxPassword.Margin = new Padding(3, 2, 3, 2);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(211, 23);
			textBoxPassword.TabIndex = 4;
			// 
			// textBoxFIO
			// 
			textBoxFIO.Location = new Point(113, 9);
			textBoxFIO.Margin = new Padding(3, 2, 3, 2);
			textBoxFIO.Name = "textBoxFIO";
			textBoxFIO.Size = new Size(211, 23);
			textBoxFIO.TabIndex = 5;
			// 
			// textBoxWorkExperience
			// 
			textBoxWorkExperience.Location = new Point(113, 58);
			textBoxWorkExperience.Margin = new Padding(3, 2, 3, 2);
			textBoxWorkExperience.Name = "textBoxWorkExperience";
			textBoxWorkExperience.Size = new Size(211, 23);
			textBoxWorkExperience.TabIndex = 6;
			// 
			// textBoxQualification
			// 
			textBoxQualification.Location = new Point(113, 83);
			textBoxQualification.Margin = new Padding(3, 2, 3, 2);
			textBoxQualification.Name = "textBoxQualification";
			textBoxQualification.Size = new Size(209, 23);
			textBoxQualification.TabIndex = 7;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(147, 110);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(89, 22);
			buttonSave.TabIndex = 8;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(242, 110);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(82, 22);
			buttonCancel.TabIndex = 9;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// FormImplementer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(334, 140);
			Controls.Add(buttonCancel);
			Controls.Add(buttonSave);
			Controls.Add(textBoxQualification);
			Controls.Add(textBoxWorkExperience);
			Controls.Add(textBoxFIO);
			Controls.Add(textBoxPassword);
			Controls.Add(labelQualification);
			Controls.Add(labelWorkExperience);
			Controls.Add(labelPassword);
			Controls.Add(labelFIO);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormImplementer";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Исполнитель";
			Load += FormImplementer_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label labelFIO;
		private Label labelPassword;
		private Label labelWorkExperience;
		private Label labelQualification;
		private TextBox textBoxPassword;
		private TextBox textBoxFIO;
		private TextBox textBoxWorkExperience;
		private TextBox textBoxQualification;
		private Button buttonSave;
		private Button buttonCancel;
	}
}