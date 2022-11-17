using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;

namespace LibraryContracts.BusinessLogicsContracts
{
    public interface IBookLogic
    {
        List<BookViewModel> Read(BookBindingModel model);
        void CreateOrUpdate(BookBindingModel model);
        void Delete(BookBindingModel model);
    }
}
