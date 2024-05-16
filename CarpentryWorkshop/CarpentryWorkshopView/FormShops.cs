using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;

namespace CarpentryWorkshopView
{
    public partial class FormShops : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _logic;
        public FormShops(ILogger<FormShops> logger, IShopLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void LoadData()
        {
            try
            {
                var list = _logic.ReadList(null);
                if (list != null)
                {
                    DataGridView.DataSource = list;
                    DataGridView.Columns["Id"].Visible = false;
                    DataGridView.Columns["ShopName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DataGridView.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DataGridView.Columns["DateOpen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DataGridView.Columns["ShopWoods"].Visible = false;
                }
                _logger.LogInformation("Загрузка магазинов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки магазинов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShopsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormShop));
            if (service is FormShop form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormShop));
                if (service is FormShop form)
                {
                    var tmp = Convert.ToInt32(DataGridView.SelectedRows[0].Cells["Id"].Value);
                    form._id = Convert.ToInt32(DataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DataGridView.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление магазина");
                    try
                    {
                        if (!_logic.Delete(new ShopBindingModel
                        {
                            Id = id
                        }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления магазина");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
