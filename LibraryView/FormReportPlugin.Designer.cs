
namespace LibraryView
{
    partial class FormReportPlugin
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
            this.buttonGetReport = new System.Windows.Forms.Button();
            this.labelAvailablePlugins = new System.Windows.Forms.Label();
            this.comboBoxAvailablePlugins = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonGetReport
            // 
            this.buttonGetReport.Location = new System.Drawing.Point(47, 91);
            this.buttonGetReport.Name = "buttonGetReport";
            this.buttonGetReport.Size = new System.Drawing.Size(265, 42);
            this.buttonGetReport.TabIndex = 1;
            this.buttonGetReport.Text = "Получить отчёт";
            this.buttonGetReport.UseVisualStyleBackColor = true;
            this.buttonGetReport.Click += new System.EventHandler(this.buttonGetReport_Click);
            // 
            // labelAvailablePlugins
            // 
            this.labelAvailablePlugins.AutoSize = true;
            this.labelAvailablePlugins.Location = new System.Drawing.Point(44, 24);
            this.labelAvailablePlugins.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailablePlugins.Name = "labelAvailablePlugins";
            this.labelAvailablePlugins.Size = new System.Drawing.Size(145, 17);
            this.labelAvailablePlugins.TabIndex = 3;
            this.labelAvailablePlugins.Text = "Доступные плагины:";
            // 
            // comboBoxAvailablePlugins
            // 
            this.comboBoxAvailablePlugins.FormattingEnabled = true;
            this.comboBoxAvailablePlugins.Location = new System.Drawing.Point(48, 44);
            this.comboBoxAvailablePlugins.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAvailablePlugins.Name = "comboBoxAvailablePlugins";
            this.comboBoxAvailablePlugins.Size = new System.Drawing.Size(264, 24);
            this.comboBoxAvailablePlugins.TabIndex = 2;
            // 
            // FormReportPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 162);
            this.Controls.Add(this.labelAvailablePlugins);
            this.Controls.Add(this.comboBoxAvailablePlugins);
            this.Controls.Add(this.buttonGetReport);
            this.Name = "FormReportPlugin";
            this.Text = "Отчёт";
            this.Load += new System.EventHandler(this.FormReportPlugin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetReport;
        private System.Windows.Forms.Label labelAvailablePlugins;
        private System.Windows.Forms.ComboBox comboBoxAvailablePlugins;
    }
}