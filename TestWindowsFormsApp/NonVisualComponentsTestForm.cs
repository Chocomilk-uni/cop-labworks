using System;
using System.Windows.Forms;

namespace TestWindowsFormsApp
{
    public partial class NonVisualComponentsTestForm : Form
    {
        public NonVisualComponentsTestForm()
        {
            InitializeComponent();
        }

        private void buttonGetDocWithImgs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Введите заголовок", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var ofd = new OpenFileDialog { Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*", Multiselect = true }) 
            { 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var sfd = new SaveFileDialog { Filter = "pdf|*.pdf" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            /*foreach (var imageFileName in ofd.FileNames)
                            {
                                images.Add(Image.FromFile(imageFileName));
                            }*/

                            Array.Sort(ofd.FileNames);

                            if (contextComponent.CreateDocument(sfd.FileName, textBoxTitle.Text, ofd.FileNames))
                            {
                                MessageBox.Show("Документ сохранён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(contextComponent.ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            textBoxTitle.Clear();
        }
    }
}