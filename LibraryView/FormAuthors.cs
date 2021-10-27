using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace LibraryView
{
    public partial class FormAuthors : Form
    {
        [Dependency] 
        public new IUnityContainer Container { get; set; }
        private readonly AuthorLogic authorLogic;

        public FormAuthors(AuthorLogic authorLogic)
        {
            this.authorLogic = authorLogic;
            InitializeComponent();
        }

        private void FormOrganizationTypes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = authorLogic.Read(null);
                if (list == null) return;

                dataGridView.DataSource = list;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    {
                        int i = 0;
                        string fullName = "Новый автор";
                        try
                        {
                            while (!(authorLogic.Read(new AuthorBindingModel { FullName = fullName })[0] is null))
                            {
                                i++;
                                fullName = "Новый автор " + i;
                            }

                            authorLogic.CreateOrUpdate(new AuthorBindingModel { FullName = fullName });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LoadData();
                        break;
                    }
                case Keys.Delete:
                    {
                        if (dataGridView.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                                try
                                {
                                    authorLogic.Delete(new AuthorBindingModel { Id = id });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                LoadData();
                            }
                        }

                        break;
                    }
            }
        }

        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = dataGridView[e.ColumnIndex, e.RowIndex].Value as string;
            if (!string.IsNullOrEmpty(typeName))
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    try
                    {
                        var id = (int)dataGridView[0, e.RowIndex].Value;
                        authorLogic.CreateOrUpdate(new AuthorBindingModel { Id = id, FullName = typeName });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }));
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
    }
}