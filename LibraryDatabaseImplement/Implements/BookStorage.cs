using LibraryContracts.StorageContracts;
using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Net;
using System.Xml.Linq;

namespace LibraryDatabaseImplement.Implements
{
    public class BookStorage : IBookStorage
    {
        public List<BookViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Books
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public List<BookViewModel> GetFilteredList(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            return context.Books
                .Where(book => book.Title.Contains(model.Title) && book.Shape.Contains(model.Shape))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public BookViewModel GetElement(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();
            var book = context.Books
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id);
            return book != null ? CreateModel(book) : null;
        }

        public void Insert(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Books.Add(CreateModel(model, new Book()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
                if (book == null)
                {
                    throw new Exception("Книга не найдена");
                }
                CreateModel(model, book);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void Delete(BookBindingModel model)
        {
            var context = new LibraryDatabase();
            var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Книга не найдена");
            }
        }

        private static Book CreateModel(BookBindingModel model, Book book)
        {
            book.Title = model.Title;
            book.Shape = model.Shape;
            book.Annotation = model.Annotation;
            book.Reader1 = model.Reader1;
            book.Reader2 = model.Reader2;
            book.Reader3 = model.Reader3;
            book.Reader4 = model.Reader4;
            book.Reader5 = model.Reader5;
            book.Reader6 = model.Reader6;
            return book;
        }

        private BookViewModel CreateModel(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Shape = book.Shape,
                Annotation = book.Annotation,
                Reader1 = book.Reader1,
                Reader2 = book.Reader2,
                Reader3 = book.Reader3,
                Reader4 = book.Reader4,
                Reader5 = book.Reader5,
                Reader6 = book.Reader6
            };
        }
    }
}
