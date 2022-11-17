using System.ComponentModel;

namespace LibraryContracts.ViewModels
{
    public class BookViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Форма")]
        public string Shape { get; set; }

        [DisplayName("Аннотация")]
        public string Annotation { get; set; }

        [DisplayName("Читатель 1")]
        public string Reader1 { get; set; }
        [DisplayName("Читатель 2")]
        public string Reader2 { get; set; }
        [DisplayName("Читатель 3")]
        public string Reader3 { get; set; }
        [DisplayName("Читатель 4")]
        public string Reader4 { get; set; }
        [DisplayName("Читатель 5")]
        public string Reader5 { get; set; }
        [DisplayName("Читатель 6")]
        public string Reader6 { get; set; }
    }
}
