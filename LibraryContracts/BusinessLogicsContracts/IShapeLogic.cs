using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;

namespace LibraryContracts.BusinessLogicsContracts
{
    public interface IShapeLogic
    {
        List<ShapeViewModel> Read(ShapeBindingModel model);
        void CreateOrUpdate(ShapeBindingModel model);
        void Delete(ShapeBindingModel model);
    }
}
