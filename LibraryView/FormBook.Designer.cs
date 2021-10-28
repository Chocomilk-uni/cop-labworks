
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(30, 50);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(272, 22);
            this.textBoxTitle.TabIndex = 0;
            // 
            // buttonAddCover
            // 
            this.buttonAddCover.Location = new System.Drawing.Point(231, 115);
            this.buttonAddCover.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddCover.Name = "buttonAddCover";
            this.buttonAddCover.Size = new System.Drawing.Size(121, 33);
            this.buttonAddCover.TabIndex = 1;
            this.buttonAddCover.Text = "Прикрепить";
            this.buttonAddCover.UseVisualStyleBackColor = true;
            this.buttonAddCover.Click += new System.EventHandler(this.buttonAddCover_Click);
            // 
            // labelCoverFileName
            // 
            this.labelCoverFileName.AutoSize = true;
            this.labelCoverFileName.Location = new System.Drawing.Point(27, 123);
            this.labelCoverFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCoverFileName.MaximumSize = new System.Drawing.Size(190, 20);
            this.labelCoverFileName.Name = "labelCoverFileName";
            this.labelCoverFileName.Size = new System.Drawing.Size(178, 17);
            this.labelCoverFileName.TabIndex = 2;
            this.labelCoverFileName.Text = "Обложка не прикреплена";
            // 
            // inputComponentDate
            // 
            this.inputComponentDate.Location = new System.Drawing.Point(409, 192);
            this.inputComponentDate.Margin = new System.Windows.Forms.Padding(5);
            this.inputComponentDate.Name = "inputComponentDate";
            this.inputComponentDate.Pattern = null;
            this.inputComponentDate.Size = new System.Drawing.Size(188, 34);
            this.inputComponentDate.TabIndex = 4;
            this.inputComponentDate.Value = null;
            // 
            // inputComponent
            // 
            this.inputComponent.Location = new System.Drawing.Point(28, 320);
            this.inputComponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputComponent.Name = "inputComponent";
            this.inputComponent.Pattern = null;
            this.inputComponent.Size = new System.Drawing.Size(183, 49);
            this.inputComponent.TabIndex = 4;
            this.inputComponent.Value = null;
            // 
            // optionsUserControl
            // 
            this.optionsUserControl.CheckedItems = new string[0];
            this.optionsUserControl.Location = new System.Drawing.Point(370, 50);
            this.optionsUserControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optionsUserControl.Name = "optionsUserControl";
            this.optionsUserControl.Size = new System.Drawing.Size(192, 96);
            this.optionsUserControl.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(157, 480);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(145, 40);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(329, 480);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(145, 40);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.Exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(406, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Автор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Обложка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(406, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дата издания:";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(90, 174);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(194, 261);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            // 
            // FormBook
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(654, 533);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.optionsUserControl);
            this.Controls.Add(this.inputComponentDate);
            this.Controls.Add(this.labelCoverFileName);
            this.Controls.Add(this.buttonAddCover);
            this.Controls.Add(this.textBoxTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBook";
            this.Text = "Книга";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBook_FormClosing);
            this.Load += new System.EventHandler(this.FormBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}