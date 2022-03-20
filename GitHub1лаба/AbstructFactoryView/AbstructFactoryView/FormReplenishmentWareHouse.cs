using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.ViewModels;
using AbstractFactoryBusinessLogic.BusinessLogic;
using System;
using Unity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstructFactoryView
{
    public partial class FormReplenishmentWareHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int ComponentId
        {
            get { return Convert.ToInt32(comboBox_Comp.SelectedValue); }
            set { comboBox_Comp.SelectedValue = value; }
        }

        public int WareHouse
        {
            get { return Convert.ToInt32(comboBox_Comp.SelectedValue); }
            set { comboBox_Comp.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBox_Number.Text); }
            set
            {
                textBox_Number.Text = value.ToString();
            }
        }

        private readonly WareHouseLogic wareHouseLogic;
        public FormReplenishmentWareHouse(DetailLogic logicComponent, WareHouseLogic logicWareHouse)
        {
            InitializeComponent();
            wareHouseLogic = logicWareHouse;

            List<DetailViewModel> listComponent = logicComponent.Read(null);
            if (listComponent != null)
            {
                comboBox_Comp.DisplayMember = "Detail";
                comboBox_Comp.ValueMember = "Id";
                comboBox_Comp.DataSource = listComponent;
                comboBox_Comp.SelectedItem = null;
            }

            List<WareHouseViewModel> listWareHouses = logicWareHouse.Read(null);
            if (listWareHouses != null)
            {
                comboBox_WareHouse.DisplayMember = "WareHouseName";
                comboBox_WareHouse.ValueMember = "Id";
                comboBox_WareHouse.DataSource = listWareHouses;
                comboBox_WareHouse.SelectedItem = null;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Number.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_Comp.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBox_WareHouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            wareHouseLogic.Replenishment(new WareHouseReplenishmentBindingModel
            {
                ComponentId = Convert.ToInt32(comboBox_Comp.SelectedValue),
                WareHouseId = Convert.ToInt32(comboBox_WareHouse.SelectedValue),
                Count = Convert.ToInt32(textBox_Number.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
