
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
            this.textBoxTitleComp1 = new System.Windows.Forms.TextBox();
            this.buttonGetDocWithImgs = new System.Windows.Forms.Button();
            this.labelTitleComp1 = new System.Windows.Forms.Label();
            this.groupBoxComp1 = new System.Windows.Forms.GroupBox();
            this.groupBoxComp2 = new System.Windows.Forms.GroupBox();
            this.labelTitleComp2 = new System.Windows.Forms.Label();
            this.buttonGetDocWithTable = new System.Windows.Forms.Button();
            this.textBoxTitleComp2 = new System.Windows.Forms.TextBox();
            this.contextComponent = new NonVisualComponentsLibrary.ContextComponent(this.components);
            this.tableComponent = new NonVisualComponentsLibrary.TableComponent(this.components);
            this.groupBoxComp3 = new System.Windows.Forms.GroupBox();
            this.labelChartName = new System.Windows.Forms.Label();
            this.textBoxChartName = new System.Windows.Forms.TextBox();
            this.labelTitleComp3 = new System.Windows.Forms.Label();
            this.buttonGetDocWithChart = new System.Windows.Forms.Button();
            this.textBoxTitleComp3 = new System.Windows.Forms.TextBox();
            this.chartComponent = new NonVisualComponentsLibrary.ChartComponent(this.components);
            this.groupBoxComp1.SuspendLayout();
            this.groupBoxComp2.SuspendLayout();
            this.groupBoxComp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTitleComp1
            // 
            this.textBoxTitleComp1.Location = new System.Drawing.Point(36, 52);
            this.textBoxTitleComp1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitleComp1.Name = "textBoxTitleComp1";
            this.textBoxTitleComp1.Size = new System.Drawing.Size(132, 22);
            this.textBoxTitleComp1.TabIndex = 0;
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
            // labelTitleComp1
            // 
            this.labelTitleComp1.AutoSize = true;
            this.labelTitleComp1.Location = new System.Drawing.Point(33, 31);
            this.labelTitleComp1.Name = "labelTitleComp1";
            this.labelTitleComp1.Size = new System.Drawing.Size(137, 17);
            this.labelTitleComp1.TabIndex = 2;
            this.labelTitleComp1.Text = "Введите заголовок:";
            // 
            // groupBoxComp1
            // 
            this.groupBoxComp1.Controls.Add(this.labelTitleComp1);
            this.groupBoxComp1.Controls.Add(this.buttonGetDocWithImgs);
            this.groupBoxComp1.Controls.Add(this.textBoxTitleComp1);
            this.groupBoxComp1.Location = new System.Drawing.Point(12, 24);
            this.groupBoxComp1.Name = "groupBoxComp1";
            this.groupBoxComp1.Size = new System.Drawing.Size(206, 156);
            this.groupBoxComp1.TabIndex = 3;
            this.groupBoxComp1.TabStop = false;
            this.groupBoxComp1.Text = "Компонент 1";
            // 
            // groupBoxComp2
            // 
            this.groupBoxComp2.Controls.Add(this.labelTitleComp2);
            this.groupBoxComp2.Controls.Add(this.buttonGetDocWithTable);
            this.groupBoxComp2.Controls.Add(this.textBoxTitleComp2);
            this.groupBoxComp2.Location = new System.Drawing.Point(255, 24);
            this.groupBoxComp2.Name = "groupBoxComp2";
            this.groupBoxComp2.Size = new System.Drawing.Size(206, 156);
            this.groupBoxComp2.TabIndex = 4;
            this.groupBoxComp2.TabStop = false;
            this.groupBoxComp2.Text = "Компонент 2";
            // 
            // labelTitleComp2
            // 
            this.labelTitleComp2.AutoSize = true;
            this.labelTitleComp2.Location = new System.Drawing.Point(33, 31);
            this.labelTitleComp2.Name = "labelTitleComp2";
            this.labelTitleComp2.Size = new System.Drawing.Size(137, 17);
            this.labelTitleComp2.TabIndex = 2;
            this.labelTitleComp2.Text = "Введите заголовок:";
            // 
            // buttonGetDocWithTable
            // 
            this.buttonGetDocWithTable.Location = new System.Drawing.Point(36, 82);
            this.buttonGetDocWithTable.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetDocWithTable.Name = "buttonGetDocWithTable";
            this.buttonGetDocWithTable.Size = new System.Drawing.Size(132, 44);
            this.buttonGetDocWithTable.TabIndex = 1;
            this.buttonGetDocWithTable.Text = "Сгенерировать документ";
            this.buttonGetDocWithTable.UseVisualStyleBackColor = true;
            this.buttonGetDocWithTable.Click += new System.EventHandler(this.buttonGetDocWithTable_Click);
            // 
            // textBoxTitleComp2
            // 
            this.textBoxTitleComp2.Location = new System.Drawing.Point(36, 52);
            this.textBoxTitleComp2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitleComp2.Name = "textBoxTitleComp2";
            this.textBoxTitleComp2.Size = new System.Drawing.Size(132, 22);
            this.textBoxTitleComp2.TabIndex = 0;
            // 
            // contextComponent
            // 
            this.contextComponent.ErrorMessage = null;
            // 
            // tableComponent
            // 
            this.tableComponent.ErrorMessage = null;
            // 
            // groupBoxComp3
            // 
            this.groupBoxComp3.Controls.Add(this.labelChartName);
            this.groupBoxComp3.Controls.Add(this.textBoxChartName);
            this.groupBoxComp3.Controls.Add(this.labelTitleComp3);
            this.groupBoxComp3.Controls.Add(this.buttonGetDocWithChart);
            this.groupBoxComp3.Controls.Add(this.textBoxTitleComp3);
            this.groupBoxComp3.Location = new System.Drawing.Point(488, 24);
            this.groupBoxComp3.Name = "groupBoxComp3";
            this.groupBoxComp3.Size = new System.Drawing.Size(219, 212);
            this.groupBoxComp3.TabIndex = 5;
            this.groupBoxComp3.TabStop = false;
            this.groupBoxComp3.Text = "Компонент 3";
            // 
            // labelChartName
            // 
            this.labelChartName.AutoSize = true;
            this.labelChartName.Location = new System.Drawing.Point(6, 81);
            this.labelChartName.Name = "labelChartName";
            this.labelChartName.Size = new System.Drawing.Size(210, 17);
            this.labelChartName.TabIndex = 4;
            this.labelChartName.Text = "Введите название диаграммы:";
            // 
            // textBoxChartName
            // 
            this.textBoxChartName.Location = new System.Drawing.Point(11, 104);
            this.textBoxChartName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxChartName.Name = "textBoxChartName";
            this.textBoxChartName.Size = new System.Drawing.Size(201, 22);
            this.textBoxChartName.TabIndex = 3;
            // 
            // labelTitleComp3
            // 
            this.labelTitleComp3.AutoSize = true;
            this.labelTitleComp3.Location = new System.Drawing.Point(6, 31);
            this.labelTitleComp3.Name = "labelTitleComp3";
            this.labelTitleComp3.Size = new System.Drawing.Size(137, 17);
            this.labelTitleComp3.TabIndex = 2;
            this.labelTitleComp3.Text = "Введите заголовок:";
            // 
            // buttonGetDocWithChart
            // 
            this.buttonGetDocWithChart.Location = new System.Drawing.Point(11, 149);
            this.buttonGetDocWithChart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetDocWithChart.Name = "buttonGetDocWithChart";
            this.buttonGetDocWithChart.Size = new System.Drawing.Size(201, 44);
            this.buttonGetDocWithChart.TabIndex = 1;
            this.buttonGetDocWithChart.Text = "Сгенерировать документ";
            this.buttonGetDocWithChart.UseVisualStyleBackColor = true;
            this.buttonGetDocWithChart.Click += new System.EventHandler(this.buttonGetDocWithChart_Click);
            // 
            // textBoxTitleComp3
            // 
            this.textBoxTitleComp3.Location = new System.Drawing.Point(11, 52);
            this.textBoxTitleComp3.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitleComp3.Name = "textBoxTitleComp3";
            this.textBoxTitleComp3.Size = new System.Drawing.Size(201, 22);
            this.textBoxTitleComp3.TabIndex = 0;
            // 
            // chartComponent
            // 
            this.chartComponent.ErrorMessage = null;
            // 
            // NonVisualComponentsTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 263);
            this.Controls.Add(this.groupBoxComp3);
            this.Controls.Add(this.groupBoxComp2);
            this.Controls.Add(this.groupBoxComp1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NonVisualComponentsTestForm";
            this.Text = "NonVisualComponentsTestForm";
            this.groupBoxComp1.ResumeLayout(false);
            this.groupBoxComp1.PerformLayout();
            this.groupBoxComp2.ResumeLayout(false);
            this.groupBoxComp2.PerformLayout();
            this.groupBoxComp3.ResumeLayout(false);
            this.groupBoxComp3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitleComp1;
        private System.Windows.Forms.Button buttonGetDocWithImgs;
        private NonVisualComponentsLibrary.ContextComponent contextComponent;
        private System.Windows.Forms.Label labelTitleComp1;
        private System.Windows.Forms.GroupBox groupBoxComp1;
        private System.Windows.Forms.GroupBox groupBoxComp2;
        private System.Windows.Forms.Label labelTitleComp2;
        private System.Windows.Forms.Button buttonGetDocWithTable;
        private System.Windows.Forms.TextBox textBoxTitleComp2;
        private NonVisualComponentsLibrary.TableComponent tableComponent;
        private System.Windows.Forms.GroupBox groupBoxComp3;
        private System.Windows.Forms.Label labelTitleComp3;
        private System.Windows.Forms.Button buttonGetDocWithChart;
        private System.Windows.Forms.TextBox textBoxTitleComp3;
        private System.Windows.Forms.Label labelChartName;
        private System.Windows.Forms.TextBox textBoxChartName;
        private NonVisualComponentsLibrary.ChartComponent chartComponent;
    }
}