namespace AbstructFactoryView
{
    partial class FormComponentToEngine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_SaveToExcel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_SaveToExcel
            // 
            this.Button_SaveToExcel.Location = new System.Drawing.Point(12, 12);
            this.Button_SaveToExcel.Name = "Button_SaveToExcel";
            this.Button_SaveToExcel.Size = new System.Drawing.Size(143, 23);
            this.Button_SaveToExcel.TabIndex = 0;
            this.Button_SaveToExcel.Text = "Сохранить в Excel";
            this.Button_SaveToExcel.UseVisualStyleBackColor = true;
            this.Button_SaveToExcel.Click += new System.EventHandler(this.Button_SaveToExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Component,
            this.Column_Product,
            this.Column_Num});
            this.dataGridView.Location = new System.Drawing.Point(12, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(644, 397);
            this.dataGridView.TabIndex = 1;
            // 
            // Column_Component
            // 
            this.Column_Component.HeaderText = "Компенент";
            this.Column_Component.Name = "Column_Component";
            this.Column_Component.Width = 200;
            // 
            // Column_Product
            // 
            this.Column_Product.HeaderText = "Изделие";
            this.Column_Product.Name = "Column_Product";
            this.Column_Product.Width = 200;
            // 
            // Column_Num
            // 
            this.Column_Num.HeaderText = "Количество";
            this.Column_Num.Name = "Column_Num";
            this.Column_Num.Width = 200;
            // 
            // FormComponentToEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Button_SaveToExcel);
            this.Name = "FormComponentToEngine";
            this.Text = "FormComponentToEngine";
            this.Load += new System.EventHandler(this.FormComponentToEngine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Button_SaveToExcel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Column_Component;
        private DataGridViewTextBoxColumn Column_Product;
        private DataGridViewTextBoxColumn Column_Num;
    }
}