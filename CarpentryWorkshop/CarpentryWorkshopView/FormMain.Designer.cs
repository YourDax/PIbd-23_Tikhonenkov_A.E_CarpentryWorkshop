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
            отчетыToolStripMenuItem1 = new ToolStripMenuItem();
            отчетыToolStripMenuItem2 = new ToolStripMenuItem();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            списокИзделийToolStripMenuItem = new ToolStripMenuItem();
            списокКомпонентовПоИзделиямToolStripMenuItem = new ToolStripMenuItem();
            списокЗаказовToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            ButtonCreateOrder = new Button();
            ButtonTakeOrderInWork = new Button();
            ButtonOrderReady = new Button();
            ButtonIssuedOrder = new Button();
            ButtonRef = new Button();
            toolStripMenuItem1 = new ToolStripMenuItem();
            отчетыToolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            изделияToolStripMenuItem1 = new ToolStripMenuItem();
            магазинToolStripMenuItem = new ToolStripMenuItem();
            заказыToolStripMenuItem = new ToolStripMenuItem();
            списокИзделийToolStripMenuItem1 = new ToolStripMenuItem();
            изделияСКомпонентамиToolStripMenuItem = new ToolStripMenuItem();
            информацияToolStripMenuItem = new ToolStripMenuItem();
            загруженностьToolStripMenuItem = new ToolStripMenuItem();
            заказыToolStripMenuItem1 = new ToolStripMenuItem();
            заказыПоГруппамToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { справочникиToolStripMenuItem, toolStripMenuItem1, отчетыToolStripMenuItem3 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(896, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            справочникиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { КомпонентыToolStripMenuItem, ИзделияToolStripMenuItem, отчетыToolStripMenuItem1, отчетыToolStripMenuItem2 });
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
            // отчетыToolStripMenuItem1
            // 
            отчетыToolStripMenuItem1.Name = "отчетыToolStripMenuItem1";
            отчетыToolStripMenuItem1.Size = new Size(180, 22);
            отчетыToolStripMenuItem1.Text = "Магазины";
            отчетыToolStripMenuItem1.Click += магазиныToolStripMenuItem_Click;
            // 
            // отчетыToolStripMenuItem2
            // 
            отчетыToolStripMenuItem2.Name = "отчетыToolStripMenuItem2";
            отчетыToolStripMenuItem2.Size = new Size(180, 22);
            // 
            // отчетыToolStripMenuItem
            // 
            отчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { списокИзделийToolStripMenuItem, списокКомпонентовПоИзделиямToolStripMenuItem, списокЗаказовToolStripMenuItem });
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(60, 20);
            отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокИзделийToolStripMenuItem
            // 
            списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            списокИзделийToolStripMenuItem.Size = new Size(265, 22);
            списокИзделийToolStripMenuItem.Text = "Список изделий";
            списокИзделийToolStripMenuItem.Click += списокИзделийToolStripMenuItem_Click;
            // 
            // списокКомпонентовПоИзделиямToolStripMenuItem
            // 
            списокКомпонентовПоИзделиямToolStripMenuItem.Name = "списокКомпонентовПоИзделиямToolStripMenuItem";
            списокКомпонентовПоИзделиямToolStripMenuItem.Size = new Size(265, 22);
            списокКомпонентовПоИзделиямToolStripMenuItem.Text = "Список компонентов по изделиям";
            списокКомпонентовПоИзделиямToolStripMenuItem.Click += изделияПоКомпонентамToolStripMenuItem_Click;
            // 
            // списокЗаказовToolStripMenuItem
            // 
            списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            списокЗаказовToolStripMenuItem.Size = new Size(265, 22);
            списокЗаказовToolStripMenuItem.Text = "Список заказов";
            списокЗаказовToolStripMenuItem.Click += списокЗаказовToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(1, 32);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
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
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(75, 20);
            toolStripMenuItem1.Text = "Операции";
            // 
            // отчетыToolStripMenuItem3
            // 
            отчетыToolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { изделияToolStripMenuItem1, магазинToolStripMenuItem, заказыToolStripMenuItem });
            отчетыToolStripMenuItem3.Name = "отчетыToolStripMenuItem3";
            отчетыToolStripMenuItem3.Size = new Size(60, 20);
            отчетыToolStripMenuItem3.Text = "Отчеты";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "Поставка";
            toolStripMenuItem3.Click += поставкиToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(180, 22);
            toolStripMenuItem4.Text = "Продажа";
            toolStripMenuItem4.DropDownClosed += SellToolStripMenuItem_Click;
            // 
            // изделияToolStripMenuItem1
            // 
            изделияToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { списокИзделийToolStripMenuItem1, изделияСКомпонентамиToolStripMenuItem });
            изделияToolStripMenuItem1.Name = "изделияToolStripMenuItem1";
            изделияToolStripMenuItem1.Size = new Size(180, 22);
            изделияToolStripMenuItem1.Text = "Изделия";
            // 
            // магазинToolStripMenuItem
            // 
            магазинToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { информацияToolStripMenuItem, загруженностьToolStripMenuItem });
            магазинToolStripMenuItem.Name = "магазинToolStripMenuItem";
            магазинToolStripMenuItem.Size = new Size(180, 22);
            магазинToolStripMenuItem.Text = "Магазин";
            // 
            // заказыToolStripMenuItem
            // 
            заказыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заказыToolStripMenuItem1, заказыПоГруппамToolStripMenuItem });
            заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            заказыToolStripMenuItem.Size = new Size(180, 22);
            заказыToolStripMenuItem.Text = "Заказы";
            // 
            // списокИзделийToolStripMenuItem1
            // 
            списокИзделийToolStripMenuItem1.Name = "списокИзделийToolStripMenuItem1";
            списокИзделийToolStripMenuItem1.Size = new Size(215, 22);
            списокИзделийToolStripMenuItem1.Text = "Список изделий";
            списокИзделийToolStripMenuItem1.Click += списокИзделийToolStripMenuItem_Click;
            // 
            // изделияСКомпонентамиToolStripMenuItem
            // 
            изделияСКомпонентамиToolStripMenuItem.Name = "изделияСКомпонентамиToolStripMenuItem";
            изделияСКомпонентамиToolStripMenuItem.Size = new Size(215, 22);
            изделияСКомпонентамиToolStripMenuItem.Text = "Изделия с компонентами";
            изделияСКомпонентамиToolStripMenuItem.Click += изделияПоКомпонентамToolStripMenuItem_Click;
            // 
            // информацияToolStripMenuItem
            // 
            информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            информацияToolStripMenuItem.Size = new Size(180, 22);
            информацияToolStripMenuItem.Text = "Информация";
            информацияToolStripMenuItem.Click += InfoToolStripMenuItem_Click;
            // 
            // загруженностьToolStripMenuItem
            // 
            загруженностьToolStripMenuItem.Name = "загруженностьToolStripMenuItem";
            загруженностьToolStripMenuItem.Size = new Size(180, 22);
            загруженностьToolStripMenuItem.Text = "Загруженность";
            загруженностьToolStripMenuItem.Click += BusyShopsToolStripMenuItem_Click;
            // 
            // заказыToolStripMenuItem1
            // 
            заказыToolStripMenuItem1.Name = "заказыToolStripMenuItem1";
            заказыToolStripMenuItem1.Size = new Size(180, 22);
            заказыToolStripMenuItem1.Text = "Заказы";
            заказыToolStripMenuItem1.Click += списокЗаказовToolStripMenuItem_Click;
            // 
            // заказыПоГруппамToolStripMenuItem
            // 
            заказыПоГруппамToolStripMenuItem.Name = "заказыПоГруппамToolStripMenuItem";
            заказыПоГруппамToolStripMenuItem.Size = new Size(180, 22);
            заказыПоГруппамToolStripMenuItem.Text = "Заказы по группам";
            заказыПоГруппамToolStripMenuItem.Click += GroupOrdersToolStripMenuItem_Click;
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
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem операцииToolStripMenuItem;
        private ToolStripMenuItem поставкаToolStripMenuItem;
        private ToolStripMenuItem продажаToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem списокИзделийToolStripMenuItem;
        private ToolStripMenuItem списокКомпонентовПоИзделиямToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ИзделияToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem отчетыToolStripMenuItem3;
        private ToolStripMenuItem изделияToolStripMenuItem1;
        private ToolStripMenuItem списокИзделийToolStripMenuItem1;
        private ToolStripMenuItem изделияСКомпонентамиToolStripMenuItem;
        private ToolStripMenuItem магазинToolStripMenuItem;
        private ToolStripMenuItem информацияToolStripMenuItem;
        private ToolStripMenuItem загруженностьToolStripMenuItem;
        private ToolStripMenuItem заказыToolStripMenuItem;
        private ToolStripMenuItem заказыToolStripMenuItem1;
        private ToolStripMenuItem заказыПоГруппамToolStripMenuItem;
    }
}