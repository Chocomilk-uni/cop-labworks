using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.Interfaces;
using LibraryBusinessLogic.ViewModels;
using LibraryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDatabaseImplement.Implementations
{
    public class BookStorage : IBookStorage
    {
        public List<BookViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Books.Select(rec => new BookViewModel
                {
                    Id = rec.Id,
                    Title = rec.Title,
                    Cover = rec.Cover,
                    Author = rec.Author,
                    PublicationDate = rec.PublicationDate
                })
                .ToList();
            }
        }

        public List<BookViewModel> GetFilteredList(BookBindingModel model)
        {
            if (model is null)
            {
                return null;
            }
            
            using (var context = new LibraryDatabase())
            {
                return context.Books
                .Where(rec => rec.Author.Equals(model.Author))
                .Select(rec => new BookViewModel
                {
                                        Id = rec.Id,
                    Title = rec.Title,
                    Cover = rec.Cover,
                    Author = rec.Author,
                    PublicationDate = rec.PublicationDate
                })
                .ToList();
            }
        }

        public BookViewModel GetElement(BookBindingModel model)
        {
            if (model is null)
            {
                return null;
            }

            using (var context = new LibraryDatabase())
            {
                var book = context.Books
                .FirstOrDefault(rec => rec.Title == model.Title || rec.Id == model.Id);
                return book is null ? null :
                new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Cover = book.Cover,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate
                };
            }
        }

        public void Insert(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                context.Books.Add(CreateModel(model, new Book()));
                context.SaveChanges();
            }
        }

        public void Update(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);

                if (book is null)
                {
                    throw new Exception("Книга не найдена");
                }

                CreateModel(model, book);
                context.SaveChanges();
            }
        }

        public void Delete(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var book = context.Books.FirstOrDefault(rec => rec.Id == model.Id);

                if (book is null)
                {
                    throw new Exception("Книга не найдена");
                }

                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        private Book CreateModel(BookBindingModel model, Book book)
        {
            book.Title = model.Title;
            book.Cover = model.Cover;
            book.Author = model.Author;
            book.PublicationDate = model.PublicationDate;
            return book;
        }
    }
}