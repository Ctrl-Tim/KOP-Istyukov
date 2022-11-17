using System.ComponentModel.DataAnnotations;


namespace LibraryDatabaseImplement.Models
{
    public class Shape
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
