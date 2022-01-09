
namespace PdfPluginImplementation
{
    partial class FormReport
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGetReport
            // 
            this.buttonGetReport.Location = new System.Drawing.Point(62, 41);
            this.buttonGetReport.Name = "buttonGetReport";
            this.buttonGetReport.Size = new System.Drawing.Size(265, 42);
            this.buttonGetReport.TabIndex = 0;
            this.buttonGetReport.Text = "Получить отчёт";
            this.buttonGetReport.UseVisualStyleBackColor = true;
            this.buttonGetReport.Click += new System.EventHandler(this.buttonGetReport_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 128);
            this.Controls.Add(this.buttonGetReport);
            this.Name = "FormReport";
            this.Text = "Отчёт";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGetReport;
    }
}

