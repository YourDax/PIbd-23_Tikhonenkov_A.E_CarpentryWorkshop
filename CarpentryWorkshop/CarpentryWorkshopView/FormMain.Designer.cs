namespace CarpentryWorkshopView
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            справочникиToolStripMenuItem = new ToolStripMenuItem();
            КомпонентыToolStripMenuItem = new ToolStripMenuItem();
            ИзделияToolStripMenuItem = new ToolStripMenuItem();
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            операцииToolStripMenuItem = new ToolStripMenuItem();
            поставкаToolStripMenuItem = new ToolStripMenuItem();
            продажаToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            ButtonCreateOrder = new Button();
            ButtonTakeOrderInWork = new Button();
            ButtonOrderReady = new Button();
            ButtonIssuedOrder = new Button();
            ButtonRef = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, операцииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(896, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { КомпонентыToolStripMenuItem, ИзделияToolStripMenuItem, магазиныToolStripMenuItem });
            справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            справочникиToolStripMenuItem.Size = new Size(94, 20);
            справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // КомпонентыToolStripMenuItem
            // 
            КомпонентыToolStripMenuItem.Name = "КомпонентыToolStripMenuItem";
            КомпонентыToolStripMenuItem.Size = new Size(180, 22);
            КомпонентыToolStripMenuItem.Text = "Компоненты";
            КомпонентыToolStripMenuItem.Click += КомпонентыToolStripMenuItem_Click;
            // 
            // ИзделияToolStripMenuItem
            // 
            ИзделияToolStripMenuItem.Name = "ИзделияToolStripMenuItem";
            ИзделияToolStripMenuItem.Size = new Size(180, 22);
            ИзделияToolStripMenuItem.Text = "Изделия";
            ИзделияToolStripMenuItem.Click += ИзделияToolStripMenuItem_Click;
            // 
            // магазиныToolStripMenuItem
            // 
            магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            магазиныToolStripMenuItem.Size = new Size(180, 22);
            магазиныToolStripMenuItem.Text = "Магазины";
            магазиныToolStripMenuItem.Click += магазиныToolStripMenuItem_Click;
            // 
            // операцииToolStripMenuItem
            // 
            операцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { поставкаToolStripMenuItem, продажаToolStripMenuItem });
            операцииToolStripMenuItem.Name = "операцииToolStripMenuItem";
            операцииToolStripMenuItem.Size = new Size(75, 20);
            операцииToolStripMenuItem.Text = "Операции";
            // 
            // поставкаToolStripMenuItem
            // 
            поставкаToolStripMenuItem.Name = "поставкаToolStripMenuItem";
            поставкаToolStripMenuItem.Size = new Size(180, 22);
            поставкаToolStripMenuItem.Text = "Поставка";
            поставкаToolStripMenuItem.Click += поставкиToolStripMenuItem_Click;
            // 
            // продажаToolStripMenuItem
            // 
            продажаToolStripMenuItem.Name = "продажаToolStripMenuItem";
            продажаToolStripMenuItem.Size = new Size(180, 22);
            продажаToolStripMenuItem.Text = "Продажа";
            продажаToolStripMenuItem.Click += SellToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(1, 32);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(755, 243);
            dataGridView.TabIndex = 1;
            // 
            // ButtonCreateOrder
            // 
            ButtonCreateOrder.Location = new Point(762, 44);
            ButtonCreateOrder.Name = "ButtonCreateOrder";
            ButtonCreateOrder.Size = new Size(122, 23);
            ButtonCreateOrder.TabIndex = 2;
            ButtonCreateOrder.Text = "Создать заказ";
            ButtonCreateOrder.UseVisualStyleBackColor = true;
            ButtonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // ButtonTakeOrderInWork
            // 
            ButtonTakeOrderInWork.Location = new Point(762, 73);
            ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
            ButtonTakeOrderInWork.Size = new Size(122, 42);
            ButtonTakeOrderInWork.TabIndex = 3;
            ButtonTakeOrderInWork.Text = "Отдать на выполнение";
            ButtonTakeOrderInWork.UseVisualStyleBackColor = true;
            ButtonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // ButtonOrderReady
            // 
            ButtonOrderReady.Location = new Point(762, 121);
            ButtonOrderReady.Name = "ButtonOrderReady";
            ButtonOrderReady.Size = new Size(122, 23);
            ButtonOrderReady.TabIndex = 4;
            ButtonOrderReady.Text = "Заказ готов";
            ButtonOrderReady.UseVisualStyleBackColor = true;
            ButtonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // ButtonIssuedOrder
            // 
            ButtonIssuedOrder.Location = new Point(762, 150);
            ButtonIssuedOrder.Name = "ButtonIssuedOrder";
            ButtonIssuedOrder.Size = new Size(122, 23);
            ButtonIssuedOrder.TabIndex = 5;
            ButtonIssuedOrder.Text = "Заказ выдан";
            ButtonIssuedOrder.UseVisualStyleBackColor = true;
            ButtonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.Location = new Point(762, 179);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(122, 23);
            ButtonRef.TabIndex = 6;
            ButtonRef.Text = "Обновить список";
            ButtonRef.UseVisualStyleBackColor = true;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 280);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonIssuedOrder);
            Controls.Add(ButtonOrderReady);
            Controls.Add(ButtonTakeOrderInWork);
            Controls.Add(ButtonCreateOrder);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Сборка Набора";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonTakeOrderInWork;
        private System.Windows.Forms.Button ButtonOrderReady;
        private System.Windows.Forms.Button ButtonIssuedOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem КомпонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ИзделияToolStripMenuItem;
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem поставкаToolStripMenuItem;
        private ToolStripMenuItem продажаToolStripMenuItem;
    }
}