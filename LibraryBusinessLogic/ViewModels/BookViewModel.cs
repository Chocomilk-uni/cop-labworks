using System;

namespace LibraryBusinessLogic.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}