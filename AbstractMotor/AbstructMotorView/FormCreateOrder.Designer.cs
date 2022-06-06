namespace AbstructMotorView
{
    partial class FormCreateOrder
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxSum = new System.Windows.Forms.TextBox();
            this.TextBoxCount = new System.Windows.Forms.TextBox();
            this.ComboBoxEngine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(100, 12);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(189, 23);
            this.comboBoxClient.TabIndex = 19;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(22, 15);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(49, 15);
            this.labelClient.TabIndex = 18;
            this.labelClient.Text = "Клиент:";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(100, 158);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(88, 26);
            this.ButtonSave.TabIndex = 17;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(210, 158);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonCancel.Size = new System.Drawing.Size(79, 26);
            this.ButtonCancel.TabIndex = 16;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TextBoxSum
            // 
            this.TextBoxSum.Location = new System.Drawing.Point(100, 119);
            this.TextBoxSum.Name = "TextBoxSum";
            this.TextBoxSum.Size = new System.Drawing.Size(189, 23);
            this.TextBoxSum.TabIndex = 15;
            // 
            // TextBoxCount
            // 
            this.TextBoxCount.Location = new System.Drawing.Point(100, 82);
            this.TextBoxCount.Name = "TextBoxCount";
            this.TextBoxCount.Size = new System.Drawing.Size(189, 23);
            this.TextBoxCount.TabIndex = 14;
            this.TextBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // ComboBoxEngine
            // 
            this.ComboBoxEngine.FormattingEnabled = true;
            this.ComboBoxEngine.Location = new System.Drawing.Point(100, 47);
            this.ComboBoxEngine.Name = "ComboBoxEngine";
            this.ComboBoxEngine.Size = new System.Drawing.Size(189, 23);
            this.ComboBoxEngine.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Сумма:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Количество:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Изделие:";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 199);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.TextBoxCount);
            this.Controls.Add(this.ComboBoxEngine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateOrder";
            this.Text = "FormCreateOrder";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxSum;
        private System.Windows.Forms.TextBox TextBoxCount;
        private System.Windows.Forms.ComboBox ComboBoxEngine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}