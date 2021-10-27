using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LibraryBusinessLogic.Interfaces
{
    public interface IBookStorage
    {
        List<BookViewModel> GetFullList();
        List<BookViewModel> GetFilteredList(BookBindingModel model);
        BookViewModel GetElement(BookBindingModel model);
        void Insert(BookBindingModel model);
        void Update(BookBindingModel model);
        void Delete(BookBindingModel model);
    }
}