namespace AbstructFactoryView
{
    partial class FormReplenishmentWareHouse
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Number = new System.Windows.Forms.TextBox();
            this.comboBox_WareHouse = new System.Windows.Forms.ComboBox();
            this.comboBox_Comp = new System.Windows.Forms.ComboBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Склад";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Компонент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество";
            // 
            // textBox_Number
            // 
            this.textBox_Number.Location = new System.Drawing.Point(90, 68);
            this.textBox_Number.Name = "textBox_Number";
            this.textBox_Number.Size = new System.Drawing.Size(297, 23);
            this.textBox_Number.TabIndex = 3;
            // 
            // comboBox_WareHouse
            // 
            this.comboBox_WareHouse.FormattingEnabled = true;
            this.comboBox_WareHouse.Location = new System.Drawing.Point(58, 6);
            this.comboBox_WareHouse.Name = "comboBox_WareHouse";
            this.comboBox_WareHouse.Size = new System.Drawing.Size(329, 23);
            this.comboBox_WareHouse.TabIndex = 4;
            // 
            // comboBox_Comp
            // 
            this.comboBox_Comp.FormattingEnabled = true;
            this.comboBox_Comp.Location = new System.Drawing.Point(90, 35);
            this.comboBox_Comp.Name = "comboBox_Comp";
            this.comboBox_Comp.Size = new System.Drawing.Size(297, 23);
            this.comboBox_Comp.TabIndex = 5;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(340, 206);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Del
            // 
            this.button_Del.Location = new System.Drawing.Point(421, 206);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(75, 23);
            this.button_Del.TabIndex = 7;
            this.button_Del.Text = "Отмена";
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // FormReplenishmentWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 241);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.comboBox_Comp);
            this.Controls.Add(this.comboBox_WareHouse);
            this.Controls.Add(this.textBox_Number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReplenishmentWareHouse";
            this.Text = "Склад";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_Number;
        private ComboBox comboBox_WareHouse;
        private ComboBox comboBox_Comp;
        private Button button_Save;
        private Button button_Del;
    }
}