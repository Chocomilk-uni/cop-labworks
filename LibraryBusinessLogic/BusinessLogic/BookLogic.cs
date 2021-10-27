using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.Interfaces;
using LibraryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace LibraryBusinessLogic.BusinessLogic
{
    public class BookLogic
    {
        private readonly IBookStorage bookStorage;

        public BookLogic(IBookStorage bookStorage)
        {
            this.bookStorage = bookStorage;
        }

        public List<BookViewModel> Read(BookBindingModel model)
        {
            if (model is null)
            {
                return bookStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BookViewModel> { bookStorage.GetElement(model) };
            }

            return bookStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(BookBindingModel model)
        {
            var book = bookStorage.GetElement(new BookBindingModel
            {
                Title = model.Title
            });

            if (!(book is null) && !book.Id.Equals(model.Id))
            {
                throw new Exception("Уже есть книга с таким названием");
            }
            if (model.Id.HasValue)
            {
                bookStorage.Update(model);
            }
            else
            {
                bookStorage.Insert(model);
            }
        }

        public void Delete(BookBindingModel model)
        {
            var book = bookStorage.GetElement(new BookBindingModel
            {
                Id = model.Id
            });

            if (book is null)
            {
                throw new Exception("Книга не найдена");
            }
            bookStorage.Delete(model);
        }
    }
}