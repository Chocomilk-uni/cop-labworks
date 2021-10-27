using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LibraryBusinessLogic.Interfaces
{
    public interface IAuthorStorage
    {
        List<AuthorViewModel> GetFullList();
        AuthorViewModel GetElement(AuthorBindingModel model);
        void Insert(AuthorBindingModel model);
        void Update(AuthorBindingModel model);
        void Delete(AuthorBindingModel model);
    }
}