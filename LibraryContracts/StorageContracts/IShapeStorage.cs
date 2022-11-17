using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;

namespace LibraryContracts.StorageContracts
{
    public interface IShapeStorage
    {
        List<ShapeViewModel> GetFullList();
        List<ShapeViewModel> GetFilteredList(ShapeBindingModel model);
        ShapeViewModel GetElement(ShapeBindingModel model);

        void Insert(ShapeBindingModel model);
        void Update(ShapeBindingModel model);
        void Delete(ShapeBindingModel model);
    }
}
