using LibraryBusinessLogic.PluginLogic.Enums;
using LibraryBusinessLogic.PluginLogic.HelperModels;
using LibraryBusinessLogic.PluginLogic.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace LibraryView
{
    public partial class FormReportPlugin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private ReportPluginManager _manager;

        public FormReportPlugin(ReportPluginManager manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void buttonGetReport_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var sfd = new SaveFileDialog { Filter = "pdf|*.pdf" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrEmpty(sfd.FileName))
                                MessageBox.Show("Путь не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            try
                            {
                                if (CreateTestDocument(sfd.FileName, ofd.FileName))
                                {
                                    MessageBox.Show("Файл был успешно создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка при создании файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private bool CreateTestDocument(string filePath, string imagePath)
        {
            var reportPlugin = _manager.plugins[comboBoxAvailablePlugins.Text];
            if (!reportPlugin.AddParagraph(new ParagraphConfigModel()
            {
                Text = "Абзац №1. Добавление первого абзаца с жирным, курсивным и подчеркнытым шрифтом размером 25",
                Bold = true,
                Italic = true,
                TextSize = 25,
                Underline = true,
                SpaceAfterCm = 1
            })) return false;
            if (!reportPlugin.AddParagraph(new ParagraphConfigModel()
            {
                Text = "Абзац №2. Добавление второго абзаца с жирным, курсивным шрифтом",
                Bold = true,
                Italic = true,
                SpaceAfterCm = 2
            })) return false;
            if (!reportPlugin.AddTable(new TableConfigModel()
            {
                Headers = new List<string> { "Колонка 1", "Колонка 2", "Колонка 3" },
                ColumnWidth = new List<double> { 3, 4, 5 },
                Data = new List<string[]>
                {
                    new [] {"Ячейка 11","Ячейка 12","Ячейка 13"},
                    new [] {"Ячейка 21","Ячейка 22"},
                    new [] {"Ячейка 31","Ячейка 32","Ячейка 33" }
                },
                SpaceAfterCm = 3
            })) return false;
            if (!reportPlugin.AddChart(new ChartConfigModel
            {
                Header = "Диаграмма тест",
                Type = ChartType.Area2D,
                XAxisValues = new[] { "1", "2", "3", "4", "5", "6" },
                Series = new List<Series>
                {
                    new Series()
                    {
                        Name = "Серия 1",
                        YAxisValues = new double []{45,34,19,21,10,6}
                    },
                    new Series()
                    {
                        Name = "Серия 2",
                        YAxisValues = new double[] { 10, 15, 17, 25, 30,45 }
                    },
                    new Series()
                    {
                        Name = "Серия 3",
                        YAxisValues = new double[] { 25, 2, 7, 15, 23 }
                    }
                },
                Width = 16,
                Height = 10,
                SpaceAfterCm = 2.5
            })) return false;
            if (!reportPlugin.AddChart(new ChartConfigModel
            {
                Header = "Диаграмма тест",
                Type = ChartType.Bar2D,
                XAxisValues = new[] { "1", "2", "3", "4", "5", "6" },
                Series = new List<Series>
                {
                    new Series()
                    {
                        Name = "Серия 1",
                        YAxisValues = new double []{45,34,19,21,10,6}
                    },
                    new Series()
                    {
                        Name = "Серия 2",
                        YAxisValues = new double[] { 10, 15, 17, 25, 30,45 }
                    },
                    new Series()
                    {
                        Name = "Серия 3",
                        YAxisValues = new double[] { 25, 2, 7, 15, 23 }
                    }
                },
                Width = 16,
                Height = 10
            })) return false;
            if (!reportPlugin.AddImage(new ImageConfigModel()
            {
                ImagePath = imagePath,
                Width = 16,
                Height = 12
            })) return false;
            return reportPlugin.SaveDocument(filePath);
        }

        private void FormReportPlugin_Load(object sender, EventArgs e)
        {
            if (_manager.Headers is null || _manager.Headers.Count.Equals(0)) return;
            comboBoxAvailablePlugins.Items.AddRange(_manager.Headers.ToArray());
            comboBoxAvailablePlugins.Text = comboBoxAvailablePlugins.Items[0].ToString();
        }
    }
}
