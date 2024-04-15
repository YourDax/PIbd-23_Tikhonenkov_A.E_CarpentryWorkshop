using CarpentryWorkshopBusinessLogic.BusinessLogics;
using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
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
    public partial class FormCreateOrder : Form
    {
        private readonly ILogger _logger;
        private readonly IWoodLogic _logicP;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _clientLogic;
        public FormCreateOrder(ILogger<FormCreateOrder> logger, IWoodLogic logicP, IOrderLogic logicO, IClientLogic clientLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logicP = logicP;
            _logicO = logicO;
            _clientLogic = clientLogic;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка изделий для заказа");
            // прописать логику
            List<WoodViewModel> list = _logicP.ReadList(null);
            if (list != null)
            {
                comboBoxWood.DisplayMember = "WoodName";
                comboBoxWood.ValueMember = "Id";
                comboBoxWood.DataSource = list;
                comboBoxWood.SelectedItem = null;
            }
            var clients = _clientLogic.ReadList(null);
            if (clients != null)
            {
                comboBoxClient.DisplayMember = "ClientFIO";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = clients;
                comboBoxClient.SelectedItem = null;
            }
        }
        private void CalcSum()
        {
            if (comboBoxWood.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxWood.SelectedValue);
                    var wood = _logicP.ReadElement(new WoodSearchModel { Id = id });
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = Math.Round(count * (wood?.Price ?? 0), 2).ToString();
                    _logger.LogInformation("Расчет суммы заказа");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка расчета суммы заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void comboBoxWood_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWood.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Создание заказа");
            try
            {
                var operationResult = _logicO.CreateOrder(new OrderBindingModel
                {
                    WoodId = Convert.ToInt32(comboBoxWood.SelectedValue),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    WoodName = comboBoxWood.Text,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDouble(textBoxSum.Text)
                });
                if (!operationResult)
                {
                    throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
