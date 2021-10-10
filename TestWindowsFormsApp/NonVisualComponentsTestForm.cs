using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestWindowsFormsApp
{
    public partial class NonVisualComponentsTestForm : Form
    {
        private string path;
        List<Image> images = new List<Image>();

        public NonVisualComponentsTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            ofd.Multiselect = true;
            ofd.

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var imageFileName in ofd.FileNames)
                        {
                            images.Add(Image.FromFile(imageFileName));
                        }
                        contextComponent1.CreateDocument(dialog.FileName, "Test", images.ToArray());
                        images.Clear();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }

                
            }
        }
    }
}
