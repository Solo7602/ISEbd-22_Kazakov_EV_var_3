using AbstructFactoryContracts.BindingModels;
using AbstructFactoryContracts.BusinessLogicsContracts;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstructMotorView
{
    public partial class FormReport : Form
    {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic _logic;

        public FormReport(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            reportViewer.LocalReport.LoadReportDefinition(new
           FileStream("../../../ReportOrder.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            Controls.Add(panel);
        }

        private void button_Forming_Click(object sender, EventArgs e)
        {
            if (dateTimePicker_Start.Value.Date >= dateTimePicker_End.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = _logic.GetOrders(new ReportBindingModel
                {
                    DateFrom = dateTimePicker_Start.Value,
                    DateTo = dateTimePicker_End.Value
                });
                var source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                var parameters = new[] { new ReportParameter("ReportParameterPeriod",
 "c " +
dateTimePicker_Start.Value.ToShortDateString() +
 " по " +
dateTimePicker_End.Value.ToShortDateString()) };
                reportViewer.LocalReport.SetParameters(parameters);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void button_ToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePicker_Start.Value.Date >= dateTimePicker_End.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveOrdersToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = dateTimePicker_Start.Value,
                        DateTo = dateTimePicker_End.Value
                    });
                    MessageBox.Show("Выполнено", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
