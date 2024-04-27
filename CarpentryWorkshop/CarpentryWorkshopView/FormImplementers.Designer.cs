namespace CarpentryWorkshopView
{
	partial class FormImplementers
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
			dataGridViewImplementers = new DataGridView();
			buttonRef = new Button();
			buttonDel = new Button();
			buttonUpd = new Button();
			buttonAdd = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridViewImplementers).BeginInit();
			SuspendLayout();
			// 
			// dataGridViewImplementers
			// 
			dataGridViewImplementers.BackgroundColor = SystemColors.ControlLightLight;
			dataGridViewImplementers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewImplementers.Location = new Point(1, 1);
			dataGridViewImplementers.Name = "dataGridViewImplementers";
			dataGridViewImplementers.RowHeadersVisible = false;
			dataGridViewImplementers.RowHeadersWidth = 51;
			dataGridViewImplementers.RowTemplate.Height = 29;
			dataGridViewImplementers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewImplementers.Size = new Size(650, 402);
			dataGridViewImplementers.TabIndex = 0;
			// 
			// buttonRef
			// 
			buttonRef.Location = new Point(668, 117);
			buttonRef.Name = "buttonRef";
			buttonRef.Size = new Size(102, 29);
			buttonRef.TabIndex = 1;
			buttonRef.Text = "Обновить";
			buttonRef.UseVisualStyleBackColor = true;
			buttonRef.Click += ButtonRef_Click;
			// 
			// buttonDel
			// 
			buttonDel.Location = new Point(668, 82);
			buttonDel.Name = "buttonDel";
			buttonDel.Size = new Size(102, 29);
			buttonDel.TabIndex = 2;
			buttonDel.Text = "Удалить";
			buttonDel.UseVisualStyleBackColor = true;
			buttonDel.Click += ButtonDel_Click;
			// 
			// buttonUpd
			// 
			buttonUpd.Location = new Point(668, 47);
			buttonUpd.Name = "buttonUpd";
			buttonUpd.Size = new Size(102, 29);
			buttonUpd.TabIndex = 3;
			buttonUpd.Text = "Изменить";
			buttonUpd.UseVisualStyleBackColor = true;
			buttonUpd.Click += ButtonUpd_Click;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(668, 12);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(102, 29);
			buttonAdd.TabIndex = 4;
			buttonAdd.Text = "Добавить";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += ButtonAdd_Click;
			// 
			// FormImplementers
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(782, 403);
			Controls.Add(buttonAdd);
			Controls.Add(buttonUpd);
			Controls.Add(buttonDel);
			Controls.Add(buttonRef);
			Controls.Add(dataGridViewImplementers);
			Name = "FormImplementers";
			StartPosition = FormStartPosition.CenterParent;
			Text = "Исполнители";
			Load += FormImplementers_Load;
			((System.ComponentModel.ISupportInitialize)dataGridViewImplementers).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private DataGridView dataGridViewImplementers;
		private Button buttonRef;
		private Button buttonDel;
		private Button buttonUpd;
		private Button buttonAdd;
	}
}