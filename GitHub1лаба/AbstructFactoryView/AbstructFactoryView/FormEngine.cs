using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using AbstructFactoryContracts.ViewModels;
using Unity;
using System;
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
    public partial class FormEngine : Form
    {
        public int Id { set { id = value; } }
        private readonly IEngineLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> engineDetails;
        public FormEngine(IEngineLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    EngineViewModel view = _logic.Read(new EngineBindingModel{ Id = id.Value})?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Engine;
                        textBoxPrice.Text = view.Price.ToString();
                        engineDetails = view.EngineDetails;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                engineDetails = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (engineDetails != null)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var eng in engineDetails)
                    {
                        dataGridView1.Rows.Add(new object[] { eng.Key, eng.Value.Item1,
eng.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormProductDetail>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (engineDetails.ContainsKey(form.Id))
                {
                    engineDetails[form.Id] = (form.DetailName, form.Count);
                }
                else
                {
                    engineDetails.Add(form.Id, (form.DetailName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormProductDetail>();
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = engineDetails[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    engineDetails[form.Id] = (form.DetailName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        engineDetails.Remove(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (engineDetails == null || engineDetails.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new EngineBindingModel
                {
                    Id = id,
                    Engine = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    EngineDetails = engineDetails
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
