namespace AbstructFactoryView
{
    partial class FormWareHouse
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_FIO = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ФИО ответственного";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(77, 6);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(404, 23);
            this.textBox_Name.TabIndex = 2;
            // 
            // textBox_FIO
            // 
            this.textBox_FIO.Location = new System.Drawing.Point(140, 48);
            this.textBox_FIO.Name = "textBox_FIO";
            this.textBox_FIO.Size = new System.Drawing.Size(341, 23);
            this.textBox_FIO.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(589, 346);
            this.dataGridView1.TabIndex = 4;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(713, 376);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Del
            // 
            this.button_Del.Location = new System.Drawing.Point(713, 415);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(75, 23);
            this.button_Del.TabIndex = 6;
            this.button_Del.Text = "Отмена";
            this.button_Del.UseVisualStyleBackColor = true;
            // 
            // FormWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_FIO);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormWareHouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWareHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox_Name;
        private TextBox textBox_FIO;
        private DataGridView dataGridView1;
        private Button button_Save;
        private Button button_Del;
    }
}