using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisualComponentsLibrary
{
    public partial class InputUserControl : UserControl
    {
        public int maxLength = 50;
        public int minLength = 10;

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
                if (textBox.TextLength >= minLength && textBox.TextLength <= maxLength)
                {
                    return textBox.Text;
                }
                else throw new ArgumentException();
            }
        }
    }
}