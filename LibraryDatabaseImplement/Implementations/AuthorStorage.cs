using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.Interfaces;
using LibraryBusinessLogic.ViewModels;
using LibraryDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryDatabaseImplement.Implementations
{
    public class AuthorStorage : IAuthorStorage
    {
        public List<AuthorViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Authors.Select(rec => new AuthorViewModel
                {
                    Id = rec.Id,
                    FullName = rec.FullName
                })
                .ToList();
            }
        }

        public AuthorViewModel GetElement(AuthorBindingModel model)
        {
            if (model is null)
            {
                return null;
            }

            using (var context = new LibraryDatabase())
            {
                var author = context.Authors
                .FirstOrDefault(rec => rec.FullName == model.FullName || rec.Id == model.Id);
                return author is null ? null :
                new AuthorViewModel
                {
                    Id = author.Id,
                    FullName = author.FullName
                };
            }
        }

        public void Insert(AuthorBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                Author newAuthor = new Author
                {
                    FullName = model.FullName
                };

                context.Authors.Add(newAuthor);
                context.SaveChanges();
            }
        }

        public void Update(AuthorBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var author = context.Authors.FirstOrDefault(rec => rec.Id == model.Id);

                if (author is null)
                {
                    throw new Exception("Автор не найден");
                }
                author.FullName = model.FullName;
                context.SaveChanges();
            }
        }

        public void Delete(AuthorBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var author = context.Authors.FirstOrDefault(rec => rec.Id == model.Id);
                if (author is null)
                {
                    throw new Exception("Автор не найден");
                }
                else
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
            }
        }
    }
}