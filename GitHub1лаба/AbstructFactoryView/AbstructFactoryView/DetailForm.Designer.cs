namespace AbstructFactoryView
{
    partial class DetailForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDetail = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
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
            // textBoxDetail
            // 
            this.textBoxDetail.Location = new System.Drawing.Point(77, 6);
            this.textBoxDetail.Name = "textBoxDetail";
            this.textBoxDetail.Size = new System.Drawing.Size(217, 23);
            this.textBoxDetail.TabIndex = 1;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(219, 35);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Отмена";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(138, 35);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 71);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBoxDetail);
            this.Controls.Add(this.label1);
            this.Name = "DetailForm";
            this.Text = "Детали";
            this.Load += new System.EventHandler(this.FormComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxDetail;
        private Button buttonStop;
        private Button buttonSave;
    }
}