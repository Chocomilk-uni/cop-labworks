using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.BusinessLogic;
using LibraryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Unity;
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
                new Column() { Header = "Id", Width = 50, Visability = false, Property = properties[0] },
                new Column() { Header = "Название", Width = 150, Visability = true, Property = properties[1] },
                new Column() { Header = "Автор", Width = 100, Visability = true, Property = properties[3] },
                new Column() { Header = "Дата издания", Width = 100, Visability = true, Property = properties[4] }
            });
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
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
            var selectedItem = (BookViewModel)userControlDataGridView.Get_Object_From_DataGridview
                (userControlDataGridView.Selected_Row_Index, new BookViewModel());

            if (selectedItem is null) return;

            var form = Container.Resolve<FormBook>();
            form.Id = selectedItem.Id;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            var selectedItem = (BookViewModel)userControlDataGridView.Get_Object_From_DataGridview
                            (userControlDataGridView.Selected_Row_Index, new BookViewModel());

            if (selectedItem is null) return;

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
        }

        private void GetDocumentWithTable(object sender, EventArgs e)
        {
        }

        private void GetDocumentWithChart(object sender, EventArgs e)
        {
        }

        private void CallAuthorsForm(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthors>();
            form.ShowDialog();
        }
    }
}