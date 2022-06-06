namespace AbstructMotorView
{
    partial class FormReport
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
            this.panel = new System.Windows.Forms.Panel();
            this.button_ToPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Forming = new System.Windows.Forms.Button();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button_ToPdf);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.button_Forming);
            this.panel.Controls.Add(this.dateTimePicker_Start);
            this.panel.Controls.Add(this.dateTimePicker_End);
            this.panel.Controls.Add(this.label2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(809, 41);
            this.panel.TabIndex = 7;
            // 
            // button_ToPdf
            // 
            this.button_ToPdf.Location = new System.Drawing.Point(701, 7);
            this.button_ToPdf.Name = "button_ToPdf";
            this.button_ToPdf.Size = new System.Drawing.Size(75, 23);
            this.button_ToPdf.TabIndex = 5;
            this.button_ToPdf.Text = "в Pdf";
            this.button_ToPdf.UseVisualStyleBackColor = true;
            this.button_ToPdf.Click += new System.EventHandler(this.button_ToPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "С";
            // 
            // button_Forming
            // 
            this.button_Forming.Location = new System.Drawing.Point(485, 9);
            this.button_Forming.Name = "button_Forming";
            this.button_Forming.Size = new System.Drawing.Size(104, 23);
            this.button_Forming.TabIndex = 4;
            this.button_Forming.Text = "Сформировать";
            this.button_Forming.UseVisualStyleBackColor = true;
            this.button_Forming.Click += new System.EventHandler(this.button_Forming_Click);
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(33, 7);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_Start.TabIndex = 1;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(265, 9);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "до";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 474);
            this.Controls.Add(this.panel);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button_ToPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Forming;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Label label2;
    }
}