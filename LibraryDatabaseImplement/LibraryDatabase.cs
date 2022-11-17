using Microsoft.EntityFrameworkCore;
using LibraryDatabaseImplement.Models;

namespace LibraryDatabaseImplement
{
    public class LibraryDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=Istyuk-PC\SQLEXPRESS;Initial Catalog=DatabasePizzeria;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Book> Books { set; get; }

        public virtual DbSet<Shape> Shapes { set; get; }
    }
}
