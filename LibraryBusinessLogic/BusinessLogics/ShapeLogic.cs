using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.StorageContracts;
using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;

namespace LibraryBusinessLogic.BusinessLogics
{
    public class ShapeLogic : IShapeLogic
    {
        private readonly IShapeStorage _shapeStorage;

        public ShapeLogic(IShapeStorage shapeStorage)
        {
            _shapeStorage = shapeStorage;
        }

        public List<ShapeViewModel> Read(ShapeBindingModel model)
        {
            if (model == null)
            {
                return _shapeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ShapeViewModel> { _shapeStorage.GetElement(model) };
            }
            return _shapeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ShapeBindingModel model)
        {
            var element = _shapeStorage.GetElement(
                new ShapeBindingModel
                {
                    Name = model.Name
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такая форма уже существует");
            }
            if (model.Id.HasValue)
            {
                _shapeStorage.Update(model);
            }
            else
            {
                _shapeStorage.Insert(model);
            }
        }

        public void Delete(ShapeBindingModel model)
        {
            var element = _shapeStorage.GetElement(new ShapeBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Форма не найдена");
            }
            _shapeStorage.Delete(model);
        }
    }
}
