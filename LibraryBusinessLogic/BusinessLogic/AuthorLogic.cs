using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.Interfaces;
using LibraryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace LibraryBusinessLogic.BusinessLogic
{
    public class AuthorLogic
    {
        private readonly IAuthorStorage authorStorage;

        public AuthorLogic(IAuthorStorage authorStorage)
        {
            this.authorStorage = authorStorage;
        }

        public List<AuthorViewModel> Read(AuthorBindingModel model)
        {
            if (model is null)
            {
                return authorStorage.GetFullList();
            }
            return new List<AuthorViewModel> { authorStorage.GetElement(model) };
        }

        public void CreateOrUpdate(AuthorBindingModel model)
        {
            var author = authorStorage.GetElement(new AuthorBindingModel
            {
                FullName = model.FullName
            });

            if (!(author is null) && !author.Id.Equals(model.Id))
            {
                throw new Exception("Уже есть автор с таким ФИО");
            }
            if (model.Id.HasValue)
            {
                authorStorage.Update(model);
            }
            else
            {
                authorStorage.Insert(model);
            }
        }

        public void Delete(AuthorBindingModel model)
        {
            var author = authorStorage.GetElement(new AuthorBindingModel
            {
                Id = model.Id
            });

            if (author is null)
            {
                throw new Exception("Автор не найден");
            }
            authorStorage.Delete(model);
        }
    }
}