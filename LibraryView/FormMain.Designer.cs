
namespace LibraryView
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.userControlDataGridView = new WindowsFormsControlLibrary.UserControlDataGridView();
            this.contextComponent = new NonVisualComponentsLibrary.ContextComponent(this.components);
            this.documentWithCustomTable = new Library_NotVisualComponents.DocumentWithCustomTable(this.components);
            this.componentWordCharts = new WindowsFormsComponentLibrary.ComponentWordCharts(this.components);
            this.SuspendLayout();
            // 
            // userControlDataGridView
            // 
            this.userControlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlDataGridView.AutoSize = true;
            this.userControlDataGridView.Location = new System.Drawing.Point(-2, -4);
            this.userControlDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.userControlDataGridView.Name = "userControlDataGridView";
            this.userControlDataGridView.Selected_Row_Index = -1;
            this.userControlDataGridView.Size = new System.Drawing.Size(491, 262);
            this.userControlDataGridView.TabIndex = 0;
            // 
            // contextComponent
            // 
            this.contextComponent.ErrorMessage = null;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 254);
            this.Controls.Add(this.userControlDataGridView);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Учёт книг в библиотеке";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsControlLibrary.UserControlDataGridView userControlDataGridView;
        private NonVisualComponentsLibrary.ContextComponent contextComponent;
        private Library_NotVisualComponents.DocumentWithCustomTable documentWithCustomTable;
        private WindowsFormsComponentLibrary.ComponentWordCharts componentWordCharts;
    }
}

