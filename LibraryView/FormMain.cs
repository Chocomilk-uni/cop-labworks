using LibraryBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

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
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            
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
            
        }

        private void DeleteBook(object sender, EventArgs e)
        {

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
    }
}
