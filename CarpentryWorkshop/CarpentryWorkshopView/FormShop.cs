using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopDataModels.Models;
using Microsoft.Extensions.Logging;

namespace CarpentryWorkshopView
{
    public partial class FormShop : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _logic;
        public int? _id;
        private Dictionary<int, (IWoodModel, int)> _woods;
        public FormShop(ILogger<FormShop> logger, IShopLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка магазина");
                try
                {
                    var shop = _logic.ReadElement(new ShopSearchModel { Id = _id });
                    if (shop != null)
                    {
                        NameTextBox.Text = shop.ShopName;
                        AddressTextBox.Text = shop.Address;
                        DateTimePicker.Text = shop.DateOpen.ToString();
                        _woods = shop.ShopWoods;
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки магазина");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            _logger.LogInformation("Загрузка товаров магазина");
            try
            {
                if (_woods != null)
                {
                    foreach (var wood in _woods)
                    {
                        DataGridView.Rows.Add(new object[] { wood.Key, wood.Value.Item1.WoodName, wood.Value.Item1.Price, wood.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки изделий магазина");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                MessageBox.Show("Заполните адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение магазина");
            try
            {
                var model = new ShopBindingModel
                {
                    Id = _id ?? 0,
                    ShopName = NameTextBox.Text,
                    Address = AddressTextBox.Text,
                    DateOpen = DateTimePicker.Value.Date,
                    ShopWoods = _woods
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения магазина");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
