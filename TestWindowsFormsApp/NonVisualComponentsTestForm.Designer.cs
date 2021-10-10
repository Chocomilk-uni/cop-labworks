
namespace TestWindowsFormsApp
{
    partial class NonVisualComponentsTestForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonGetDocWithImgs = new System.Windows.Forms.Button();
            this.contextComponent = new NonVisualComponentsLibrary.ContextComponent(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(36, 52);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(132, 22);
            this.textBoxTitle.TabIndex = 0;
            // 
            // buttonGetDocWithImgs
            // 
            this.buttonGetDocWithImgs.Location = new System.Drawing.Point(36, 82);
            this.buttonGetDocWithImgs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetDocWithImgs.Name = "buttonGetDocWithImgs";
            this.buttonGetDocWithImgs.Size = new System.Drawing.Size(132, 44);
            this.buttonGetDocWithImgs.TabIndex = 1;
            this.buttonGetDocWithImgs.Text = "Сгенерировать документ";
            this.buttonGetDocWithImgs.UseVisualStyleBackColor = true;
            this.buttonGetDocWithImgs.Click += new System.EventHandler(this.buttonGetDocWithImgs_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(33, 31);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(137, 17);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Введите заголовок:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTitle);
            this.groupBox1.Controls.Add(this.buttonGetDocWithImgs);
            this.groupBox1.Controls.Add(this.textBoxTitle);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 156);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Компонент 1";
            // 
            // NonVisualComponentsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 361);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NonVisualComponentsTestForm";
            this.Text = "NonVisualComponentsTestForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonGetDocWithImgs;
        private NonVisualComponentsLibrary.ContextComponent contextComponent;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}