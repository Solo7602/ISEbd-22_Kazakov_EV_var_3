using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicContracts;
using System;
using System.Windows.Forms;

namespace AbstructFactoryView
{
    public partial class DetailForm : Form
    {
        public int Id { set { id = value; } }
        private readonly IDetailLogic _logic;
        private int? id;
        public DetailForm(IDetailLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new DetailBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxDetail.Text = view.Detail;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDetail.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new DetailBindingModel
                {
                    Id = id,
                    Detail = textBoxDetail.Text
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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}