namespace AbstructFactoryView
{
    partial class FormEngines
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(604, 449);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(684, 50);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(104, 37);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(684, 230);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(104, 37);
            this.buttonUpd.TabIndex = 3;
            this.buttonUpd.Text = "Обновить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(684, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // FormEngines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonUpd);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormEngines";
            this.Text = "FormEngines";
            this.Load += new System.EventHandler(this.FormEngines_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonUpd;
        private Button button2;
        private Button button3;
    }
}