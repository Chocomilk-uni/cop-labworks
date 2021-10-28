using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.BusinessLogic;
using LibraryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;
using WindowsFormsComponentLibrary.HelperModels;
using WindowsFormsControlLibrary;

namespace LibraryView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly BookLogic bookLogic;
        private readonly ReportLogic reportLogic;

        public FormMain(BookLogic bookLogic, ReportLogic reportLogic)
        {
            InitializeComponent();
            this.bookLogic = bookLogic;
            this.reportLogic = reportLogic;


            PropertyInfo[] properties = typeof(BookViewModel).GetProperties();

            userControlDataGridView.Configurate_DataGridView(new List<Column> 
            { 
                new Column() { Header = "Id", Width = 0, Visability = false, Property = properties[0] },
                new Column() { Header = "Название", Width = 120, Visability = true, Property = properties[1] },
                new Column() { Header = "Автор", Width = 115, Visability = true, Property = properties[3] },
                new Column() { Header = "Дата издания", Width = 110, Visability = true, Property = properties[4] }
            });

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            userControlDataGridView.DeleteRows_DataGRidView();

            try
            {
                var list = bookLogic.Read(null);

                foreach (var book in list)
                {
                    userControlDataGridView.Add_To_DataGridVew(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        {
                            AddBook(null, null);
                            break;
                        }
                    case Keys.U:
                        {
                            UpdateBook(null, null);
                            break;
                        }
                    case Keys.D:
                        {
                            DeleteBook(null, null);
                            break;
                        }
                    case Keys.S:
                        {
                            GetDocumentWithCovers(null, null);
                            break;
                        }
                    case Keys.T:
                        {
                            GetDocumentWithTable(null, null);
                            break;
                        }
                    case Keys.C:
                        {
                            GetDocumentWithChart(null, null);
                            break;
                        }
                    case Keys.O:
                        {
                            CallAuthorsForm(null, null);
                            break;
                        }
                }
            }
        }

        private void AddBook(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBook>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void UpdateBook(object sender, EventArgs e)
        {
            if (userControlDataGridView.Selected_Row_Index == -1)
            {
                MessageBox.Show("Книга не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedItem = (BookViewModel)userControlDataGridView.Get_Object_From_DataGridview(userControlDataGridView.Selected_Row_Index, new BookViewModel());

            var form = Container.Resolve<FormBook>();
            form.Id = selectedItem.Id;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            if (userControlDataGridView.Selected_Row_Index == -1)
            {
                MessageBox.Show("Книга не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedItem = (BookViewModel)userControlDataGridView.Get_Object_From_DataGridview
                            (userControlDataGridView.Selected_Row_Index, new BookViewModel());


            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = selectedItem.Id;
                try
                {
                    bookLogic.Delete(new BookBindingModel() { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void GetDocumentWithCovers(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "pdf file | *.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                    MessageBox.Show("Путь не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (contextComponent.CreateDocument(sfd.FileName, "Обложки книг", reportLogic.GetCovers()))
                {
                    MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(contextComponent.ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetDocumentWithTable(object sender, EventArgs e)
        {
            var headerList = new List<List<string>>();
            headerList.Add(new List<string>() { "Id" });
            headerList.Add(new List<string>() { "Книга", "Название", "Автор" });
            headerList.Add(new List<string>() { "Дата издания" });

            var sfd = new SaveFileDialog();
            sfd.Filter = "xls file | *.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    documentWithCustomTable.CreateFile(sfd.FileName, "Книги", headerList, reportLogic.GetBooks(), new double?[] { 10, 40, 40, 30 }.ToList());

                    MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetDocumentWithChart(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "docx file | *.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    componentWordCharts.CreateDiagram(sfd.FileName, "Отчёт", "Количество книг, написанных авторами",
                        "Author", "Count", Legend_Location.Bottom, reportLogic.GetBooksCount());
                    MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CallAuthorsForm(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthors>();
            form.ShowDialog();
        }
    }
}