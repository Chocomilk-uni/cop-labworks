
namespace TestWindowsFormsApp
{
    partial class TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.inputUserControl = new VisualComponentsLibrary.InputUserControl();
            this.optionsUserControl = new VisualComponentsLibrary.OptionsUserControl();
            this.outputUserControl = new VisualComponentsLibrary.OutputUserControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить элементы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonAddItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Вывести выделенные";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonGetCheckedItems_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(37, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "Выделить элементы \"Книга 1\" и\"Книга 2\"";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonSetCheckedItems_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(37, 275);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 35);
            this.button4.TabIndex = 6;
            this.button4.Text = "Очистить список";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(221, 145);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 32);
            this.button5.TabIndex = 7;
            this.button5.Text = "Вывести текст";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonGetText_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(221, 183);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 67);
            this.button6.TabIndex = 8;
            this.button6.Text = "Поменять введённое значение на \"Новый текст\"";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonSetText_Clic);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(413, 237);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(246, 32);
            this.button7.TabIndex = 9;
            this.button7.Text = "Добавить объекты";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonAddObject_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(413, 278);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(246, 32);
            this.button8.TabIndex = 10;
            this.button8.Text = "Выделить узел";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonSelectNode_Click);
            // 
            // inputUserControl
            // 
            this.inputUserControl.Location = new System.Drawing.Point(230, 65);
            this.inputUserControl.Name = "inputUserControl";
            this.inputUserControl.Size = new System.Drawing.Size(141, 35);
            this.inputUserControl.TabIndex = 1;
            // 
            // optionsUserControl
            // 
            this.optionsUserControl.CheckedItems = new string[0];
            this.optionsUserControl.Location = new System.Drawing.Point(37, 40);
            this.optionsUserControl.Name = "optionsUserControl";
            this.optionsUserControl.Size = new System.Drawing.Size(150, 99);
            this.optionsUserControl.TabIndex = 0;
            // 
            // outputUserControl
            // 
            this.outputUserControl.Location = new System.Drawing.Point(413, 18);
            this.outputUserControl.Name = "outputUserControl";
            this.outputUserControl.Size = new System.Drawing.Size(246, 200);
            this.outputUserControl.TabIndex = 11;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 349);
            this.Controls.Add(this.outputUserControl);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputUserControl);
            this.Controls.Add(this.optionsUserControl);
            this.Name = "TestForm";
            this.Text = "Тестовое приложение";
            this.ResumeLayout(false);

        }

        #endregion

        private VisualComponentsLibrary.OptionsUserControl optionsUserControl;
        private VisualComponentsLibrary.InputUserControl inputUserControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private VisualComponentsLibrary.OutputUserControl outputUserControl;
    }
}

