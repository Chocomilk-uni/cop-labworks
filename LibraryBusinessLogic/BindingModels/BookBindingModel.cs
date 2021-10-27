using System;
namespace LibraryBusinessLogic.BindingModels
{
    public class BookBindingModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}