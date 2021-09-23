using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisualComponentsLibrary
{
    public partial class InputUserControl : UserControl
    {
        public int? maxLength;
        public int? minLength;

        public InputUserControl()
        {
            InitializeComponent();
        }

        [Category("Пользовательская категория"), Description("Введённое значение")]
        public string InputText
        {
            set => textBox.Text = value;
            get
            {
                if (minLength.HasValue && maxLength.HasValue)
                {
                    if (textBox.TextLength >= minLength && textBox.TextLength <= maxLength)
                    {
                        return textBox.Text;
                    }

                    else throw new ArgumentException("Строка не входит в границы диапазона");
                }

                else throw new ArgumentException("Границы диапазона не установлены");
            }
        }
    }
}