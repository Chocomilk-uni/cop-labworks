using LibraryBusinessLogic.BindingModels;
using LibraryBusinessLogic.BusinessLogic.HelperModels;
using LibraryBusinessLogic.Interfaces;
using LibraryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IBookStorage bookStorage;
        private readonly IAuthorStorage authorStorage;

        public ReportLogic(IBookStorage bookStorage, IAuthorStorage authorStorage)
        {
            this.bookStorage = bookStorage;
            this.authorStorage = authorStorage;
        }

        public string[] GetCovers()
        {
            var booksList = bookStorage.GetFullList();
            var coversList = new List<string>();

            foreach (var book in booksList)
            {
                coversList.Add(book.Cover);
            }

            return coversList.ToArray();
        }

        public List<BooksTableData> GetBooks()
        {
            var booksList = bookStorage.GetFullList();
            var result = new List<BooksTableData>();

            foreach (var book in booksList)
            {
                result.Add(new BooksTableData()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationDate = book.PublicationDate.ToString("dd.MM.yyyy", CultureInfo.CreateSpecificCulture("de-DE"))
                });
            }

            return result;
        }

        public List<BooksCountChartData> GetBooksCount()
        {
            var authorsList = authorStorage.GetFullList();

            var result = new List<BooksCountChartData>();

            foreach (var author in authorsList)
            {
                var booksCount = bookStorage.GetFilteredList(new BookBindingModel
                {
                    Author = author.FullName
                }).Count();

                result.Add(new BooksCountChartData()
                {
                    Author = author.FullName,
                    Count = booksCount
                });
            }
            return result;
        }
    }
}