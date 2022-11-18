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

        [Required]
        public string Reader1 { get; set; }
        [Required]
        public string Reader2 { get; set; }
        [Required]
        public string Reader3 { get; set; }
        [Required]
        public string Reader4 { get; set; }
        [Required]
        public string Reader5 { get; set; }
        [Required]
        public string Reader6 { get; set; }
    }
}
