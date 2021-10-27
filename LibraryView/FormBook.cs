using LibraryBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace LibraryView
{
    public partial class FormBook : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly BookLogic bookLogic;
        private readonly AuthorLogic authorLogic;

        public FormBook(BookLogic bookLogic, AuthorLogic authorLogic)
        {
            InitializeComponent();
            this.bookLogic = bookLogic;
            this.authorLogic = authorLogic;
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
           
        }
    }
}
