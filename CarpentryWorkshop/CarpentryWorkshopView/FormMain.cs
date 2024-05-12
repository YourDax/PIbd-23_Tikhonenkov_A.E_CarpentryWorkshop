using CarpentryWorkshopBusinessLogic.BusinessLogics;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.DI;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpentryWorkshopView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcess;
        private readonly IBackUpLogic _backUpLogic;
        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess, IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _logger = logger;
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
            _backUpLogic = backUpLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка заказов");
            // прописать логику
            try
            {
                dataGridView.FillAndConfigGrid(_orderLogic.ReadList(null));
                _logger.LogInformation("Загрузка продуктов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки продуктов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void КомпонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormComponents>();
            form.ShowDialog();
        }
        private void ИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormWoods>();
            form.ShowDialog();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'В работе'", id);
                try
                {
                    var operationResult = _orderLogic.TakeOrderInWork(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка передачи заказа в работу");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Готов'", id);
                try
                {
                    var operationResult = _orderLogic.FinishOrder(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о готовности заказа"); MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);
                try
                {
                    var operationResult = _orderLogic.DeliveryOrder(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _logger.LogInformation("Заказ №{id} выдан", id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void списокИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveComponentsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void изделияПоКомпонентамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportWoodComponents>();
            form.ShowDialog();
        }

        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormClients>();
            form.ShowDialog();
        }
        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcess.DoWork(DependencyManager.Instance.Resolve<IImplementerLogic>(), _orderLogic);
            MessageBox.Show("Процесс обработки запущен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormImplementers>();
            form.ShowDialog();
        }
        private void письмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormMail>();
            form.ShowDialog();
        }
        private void createBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new BackUpSaveBinidngModel
                        {
                            FolderName = fbd.SelectedPath
                        });
                        MessageBox.Show("Бэкап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка создания бэкапа", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
