using System.ComponentModel.DataAnnotations;

namespace LibraryDatabaseImplement.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}