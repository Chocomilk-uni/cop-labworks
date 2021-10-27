using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryDatabaseImplement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }
    }
}