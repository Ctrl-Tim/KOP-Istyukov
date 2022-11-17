using System.ComponentModel.DataAnnotations;

namespace LibraryDatabaseImplement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Shape { get; set; }

        [Required]
        public string Annotation { get; set; }

        public string Reader1 { get; set; }
        public string Reader2 { get; set; }
        public string Reader3 { get; set; }
        public string Reader4 { get; set; }
        public string Reader5 { get; set; }
        public string Reader6 { get; set; }
    }
}
