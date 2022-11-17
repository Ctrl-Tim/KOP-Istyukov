using LibraryContracts.StorageContracts;
using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using LibraryDatabaseImplement.Models;
using System.Xml.Linq;

namespace LibraryDatabaseImplement.Implements
{
    public class ShapeStorage : IShapeStorage
    {
        public List<ShapeViewModel> GetFullList()
        {
            using var context = new LibraryDatabase();
            return context.Shapes
                .Select(CreateModel)
                .ToList();
        }

        public List<ShapeViewModel> GetFilteredList(ShapeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();
            return context.Shapes
                .Where(rec => rec.Name.Contains(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public ShapeViewModel GetElement(ShapeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();

            var shape = context.Shapes
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
            return shape != null ? CreateModel(shape) : null;

        }

        public void Insert(ShapeBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Shapes.Add(CreateModel(model, new Shape()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(ShapeBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var shape = context.Shapes.FirstOrDefault(rec => rec.Id == model.Id);
                if (shape == null)
                {
                    throw new Exception("Форма не найдена");
                }
                CreateModel(model, shape);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void Delete(ShapeBindingModel model)
        {
            var context = new LibraryDatabase();
            var shape = context.Shapes.FirstOrDefault(rec => rec.Id == model.Id);
            if (shape != null)
            {
                context.Shapes.Remove(shape);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Форма не найдена");
            }
        }

        private static Shape CreateModel(ShapeBindingModel model, Shape shape)
        {
            shape.Name = model.Name;
            return shape;
        }

        private static ShapeViewModel CreateModel(Shape shape)
        {
            return new ShapeViewModel
            {
                Id = shape.Id,
                Name = shape.Name
            };
        }
    }
}
