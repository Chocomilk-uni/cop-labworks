using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.BusinessLogic;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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
        public int Id { set { id = value; } }
        private int? id;
        private string coverFileName;
        private CheckDataChange _checkDataChange;
        private bool Save { get; set; } = false;

        public FormBook(BookLogic bookLogic, AuthorLogic authorLogic)
        {
            InitializeComponent();
            this.bookLogic = bookLogic;
            this.authorLogic = authorLogic;
            _checkDataChange = new CheckDataChange();
            inputComponentDate.Pattern = @"^\d{2}\.\d{2}\.\d{1,4}$";
            inputComponentDate.SetToolTip("11.05.1432");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            var list = authorLogic.Read(null);
            var listString = list.Select(x => x.FullName);

            foreach (var author in listString)
            {
                optionsUserControl.AddItem(author);
            }

            if (id.HasValue)
            {
                try
                {
                    var item = bookLogic.Read(new BookBindingModel { Id = id })?[0];
                    if (item is null) return;

                    textBoxTitle.Text = item.Title;
                    labelCoverFileName.Text = Path.GetFileName(item.Cover);
                    optionsUserControl.CheckedItems = new string[] { item.Author };
                    inputComponentDate.Value = item.PublicationDate.ToString("dd.MM.yyyy", CultureInfo.CreateSpecificCulture("de-DE"));
                    pictureBox.Image = Image.FromFile(Path.GetFullPath(item.Cover));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _checkDataChange.Title = textBoxTitle.Text;
            _checkDataChange.Cover = labelCoverFileName.Text;
            if (optionsUserControl.CheckedItems.Count() > 0) 
            {
                _checkDataChange.Author = optionsUserControl.CheckedItems[0];
            }
            else _checkDataChange.Author = null;
            if (!string.IsNullOrEmpty(inputComponentDate.Value))
            {
                _checkDataChange.PublicationDate = inputComponentDate.Value;
            }
            else _checkDataChange.PublicationDate = null;
        }

        private void buttonAddCover_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    coverFileName = ofd.FileName;
                    pictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }

            if (!string.IsNullOrEmpty(coverFileName))
            {
                labelCoverFileName.Text = coverFileName;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var title = textBoxTitle.Text;
            var cover = labelCoverFileName.Text;
            string author;
            string date;

            if (optionsUserControl.CheckedItems.Count() > 0)
            {
                author = optionsUserControl.CheckedItems[0];
            }
            else author = null;

            try
            {
                if (!string.IsNullOrEmpty(inputComponentDate.Value))
                {
                    date = inputComponentDate.Value;
                }
                else date = null;
            }
            catch (Exception ex)
            {
                date = null;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cover == "Обложка не прикреплена")
            {
                MessageBox.Show("Прикрепите обложку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Выберите автора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(date))
            {
                MessageBox.Show("Заполните дату издания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_checkDataChange.CheckData(title, cover, author, date))
            {
                Close();
                return;
            }

            try
            {
                bookLogic.CreateOrUpdate(new BookBindingModel
                {
                    Id = id,
                    Title = title,
                    Cover = cover,
                    Author = author,
                    PublicationDate = DateTime.Parse(date)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Save = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private bool CloseWindow()
        {
            bool result = true;
            if (Save) return result;
            var title = textBoxTitle.Text;
            var cover = labelCoverFileName.Text;
            string author;
            string date;

            if (optionsUserControl.CheckedItems.Count() > 0)
            {
                author = optionsUserControl.CheckedItems[0];
            }
            else author = null;

            try
            {
                if (!string.IsNullOrEmpty(inputComponentDate.Value))
                {
                    date = inputComponentDate.Value;
                }
                else date = null;
            }
            catch (Exception ex)
            {
                date = null;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!_checkDataChange.CheckData(title, cover, author, date))
            {
                if (MessageBox.Show("Данные не сохранены", "Выйти?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    result = false;
                }
            }
            return result;
        }

        private void FormBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseWindow())
            {
                e.Cancel = true;
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        public class CheckDataChange
        {
            public string Title { get; set; }
            public string Cover { get; set; }
            public string Author { get; set; }
            public string PublicationDate { get; set; }

            public bool CheckData(string title, string cover, string author, string date)
            {
                return title.Equals(Title)
                    && cover.Equals(Cover)
                    && author.Equals(Author)
                    && date.Equals(PublicationDate);
            }
        }
    }
}