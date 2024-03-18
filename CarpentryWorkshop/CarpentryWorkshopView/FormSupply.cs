using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
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
    public partial class FormSupply : Form
    {
        private readonly List<WoodViewModel>? _woodList;
        private readonly List<ShopViewModel>? _shopsList;
        IShopLogic _shopLogic;
        IWoodLogic _woodLogic;
        public int ShopId
        {
            get
            {
                return
       Convert.ToInt32(ShopComboBox.SelectedValue);
            }
            set
            {
                ShopComboBox.SelectedValue = value;
            }
        }
        public int WoodId
        {
            get
            {
                return
       Convert.ToInt32(WoodComboBox.SelectedValue);
            }
            set
            {
                WoodComboBox.SelectedValue = value;
            }
        }

        public IWoodModel? WoodModel
        {
            get
            {
                if (_woodList == null)
                {
                    return null;
                }
                foreach (var elem in _woodList)
                {
                    if (elem.Id == WoodId)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }


        public int Count
        {
            get { return Convert.ToInt32(CountTextBox.Text); }
            set
            { CountTextBox.Text = value.ToString(); }
        }
        public FormSupply(IWoodLogic woodLogic, IShopLogic shopLogic)
        {
            InitializeComponent();
            _shopLogic = shopLogic;
            _woodLogic = woodLogic;
            _woodList = woodLogic.ReadList(null);
            _shopsList = shopLogic.ReadList(null);
            if (_woodList != null)
            {
                WoodComboBox.DisplayMember = "WoodName";
                WoodComboBox.ValueMember = "Id";
                WoodComboBox.DataSource = _woodList;
                WoodComboBox.SelectedItem = null;
            }
            if (_shopsList != null)
            {
                ShopComboBox.DisplayMember = "ShopName";
                ShopComboBox.ValueMember = "Id";
                ShopComboBox.DataSource = _shopsList;
                ShopComboBox.SelectedItem = null;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CountTextBox.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (WoodComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ShopComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int count = Convert.ToInt32(CountTextBox.Text);

                bool res = _shopLogic.MakeSupply(new SupplyBindingModel
                {
                    ShopId = Convert.ToInt32(ShopComboBox.SelectedValue),
                    WoodId = Convert.ToInt32(WoodComboBox.SelectedValue),
                    Count = Convert.ToInt32(CountTextBox.Text)
                });

                if (!res)
                {
                    throw new Exception("Ошибка при пополнении. Дополнительная информация в логах");
                }

                MessageBox.Show("Пополнение прошло успешно");
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка пополнения");
                return;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
