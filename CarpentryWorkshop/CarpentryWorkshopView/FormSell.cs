using Microsoft.Extensions.Logging;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
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
    public partial class FormSell : Form
    {
        private readonly ILogger _logger;
        private readonly IWoodLogic _logicP;
        private readonly IShopLogic _logicS;
        private List<WoodViewModel> _woodList = new List<WoodViewModel>();

        public FormSell(ILogger<FormSell> logger, IWoodLogic logicP, IShopLogic logicS)
        {
            InitializeComponent();
            _logger = logger;
            _logicP = logicP;
            _logicS = logicS;
        }

        private void FormSellingWood_Load(object sender, EventArgs e)
        {
            _woodList = _logicP.ReadList(null);
            if (_woodList != null)
            {
                comboBoxWood.DisplayMember = "WoodName";
                comboBoxWood.ValueMember = "Id";
                comboBoxWood.DataSource = _woodList;
                comboBoxWood.SelectedItem = null;
                _logger.LogInformation("Загрузка изделий для продажи");
            }
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            if (comboBoxWood.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Создание покупки");
            try
            {
                bool resout = _logicS.Sale(new SupplySearchModel
                {
                    WoodId = Convert.ToInt32(comboBoxWood.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
                if (resout)
                {
                    _logger.LogInformation("Проверка пройдена, продажа  проведена");
                    MessageBox.Show("Продажа проведена", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    _logger.LogInformation("Проверка не пройдена");
                    MessageBox.Show("Продажа не может быть создана.", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания покупки");
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