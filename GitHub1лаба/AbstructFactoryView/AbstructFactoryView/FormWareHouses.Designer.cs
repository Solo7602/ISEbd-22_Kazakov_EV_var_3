namespace AbstructFactoryView
{
    partial class FormWareHouses
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Change = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Ref = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(433, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(468, 128);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "Добавить";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Change
            // 
            this.button_Change.Location = new System.Drawing.Point(468, 169);
            this.button_Change.Name = "button_Change";
            this.button_Change.Size = new System.Drawing.Size(75, 23);
            this.button_Change.TabIndex = 2;
            this.button_Change.Text = "Изменить";
            this.button_Change.UseVisualStyleBackColor = true;
            this.button_Change.Click += new System.EventHandler(this.button_Change_Click);
            // 
            // button_Del
            // 
            this.button_Del.Location = new System.Drawing.Point(468, 219);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(75, 23);
            this.button_Del.TabIndex = 3;
            this.button_Del.Text = "Удалить";
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Ref
            // 
            this.button_Ref.Location = new System.Drawing.Point(468, 266);
            this.button_Ref.Name = "button_Ref";
            this.button_Ref.Size = new System.Drawing.Size(75, 23);
            this.button_Ref.TabIndex = 4;
            this.button_Ref.Text = "Обновить";
            this.button_Ref.UseVisualStyleBackColor = true;
            this.button_Ref.Click += new System.EventHandler(this.button_Ref_Click);
            // 
            // FormWareHouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.button_Ref);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Change);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormWareHouses";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWareHouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button_Add;
        private Button button_Change;
        private Button button_Del;
        private Button button_Ref;
    }
}