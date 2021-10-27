
namespace LibraryView
{
    partial class FormBook
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonAddCover = new System.Windows.Forms.Button();
            this.labelCoverFileName = new System.Windows.Forms.Label();
            this.inputComponentDate = new Library_VisualComponents.InputComponent();
            this.inputComponent = new Library_VisualComponents.InputComponent();
            this.optionsUserControl = new VisualComponentsLibrary.OptionsUserControl();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(27, 22);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(216, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // buttonAddCover
            // 
            this.buttonAddCover.Location = new System.Drawing.Point(27, 59);
            this.buttonAddCover.Name = "buttonAddCover";
            this.buttonAddCover.Size = new System.Drawing.Size(104, 39);
            this.buttonAddCover.TabIndex = 1;
            this.buttonAddCover.Text = "Прикрепить обложку";
            this.buttonAddCover.UseVisualStyleBackColor = true;
            this.buttonAddCover.Click += new System.EventHandler(this.buttonAddCover_Click);
            // 
            // labelCoverFileName
            // 
            this.labelCoverFileName.AutoSize = true;
            this.labelCoverFileName.Location = new System.Drawing.Point(157, 72);
            this.labelCoverFileName.Name = "labelCoverFileName";
            this.labelCoverFileName.Size = new System.Drawing.Size(137, 13);
            this.labelCoverFileName.TabIndex = 2;
            this.labelCoverFileName.Text = "Обложка не прикреплена";
            // 
            // inputComponentDate
            // 
            this.inputComponentDate.Location = new System.Drawing.Point(27, 267);
            this.inputComponentDate.Name = "inputComponentDate";
            this.inputComponentDate.Pattern = null;
            this.inputComponentDate.Size = new System.Drawing.Size(183, 49);
            this.inputComponentDate.TabIndex = 4;
            this.inputComponentDate.Value = null;
            // 
            // inputComponent
            // 
            this.inputComponent.Location = new System.Drawing.Point(28, 320);
            this.inputComponent.Name = "inputComponent";
            this.inputComponent.Pattern = null;
            this.inputComponent.Size = new System.Drawing.Size(183, 49);
            this.inputComponent.TabIndex = 4;
            this.inputComponent.Value = null;
            // 
            // optionsUserControl
            // 
            this.optionsUserControl.CheckedItems = new string[0];
            this.optionsUserControl.Location = new System.Drawing.Point(27, 114);
            this.optionsUserControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.optionsUserControl.Name = "optionsUserControl";
            this.optionsUserControl.Size = new System.Drawing.Size(112, 122);
            this.optionsUserControl.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(44, 338);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 402);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.optionsUserControl);
            this.Controls.Add(this.inputComponentDate);
            this.Controls.Add(this.labelCoverFileName);
            this.Controls.Add(this.buttonAddCover);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "FormBook";
            this.Text = "Книга";
            this.Load += new System.EventHandler(this.FormBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonAddCover;
        private System.Windows.Forms.Label labelCoverFileName;
        private Library_VisualComponents.InputComponent inputComponentDate;
        private Library_VisualComponents.InputComponent inputComponent;
        private VisualComponentsLibrary.OptionsUserControl optionsUserControl;
        private System.Windows.Forms.Button buttonSave;
    }
}