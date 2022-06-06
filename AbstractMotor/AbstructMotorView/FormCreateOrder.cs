using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstructMotorView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IEngineLogic _logicE;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _logicС;
        public FormCreateOrder(IEngineLogic logicE, IOrderLogic logicO, IClientLogic logicС)
        {
            InitializeComponent();
            _logicE = logicE;
            _logicO = logicO;
            _logicС = logicС;
        }
        private void CalcSum()
        {
            if (ComboBoxEngine.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(ComboBoxEngine.SelectedValue);
                    EngineViewModel canned = _logicE.Read(new EngineBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxSum.Text = (count * canned?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var listC = _logicС.Read(null);
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "ClientFIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
                var list = _logicE.Read(null);
                foreach (var component in list)
                {
                    ComboBoxEngine.DisplayMember = "Engine";
                    ComboBoxEngine.ValueMember = "Id";
                    ComboBoxEngine.DataSource = list;
                    ComboBoxEngine.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ComboBoxEngine.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    ProductId = Convert.ToInt32(ComboBoxEngine.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text),
                    Sum = Convert.ToDecimal(TextBoxSum.Text),
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
