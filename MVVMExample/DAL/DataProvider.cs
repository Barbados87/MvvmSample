using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MVVMExample.ViewModelBase;

namespace MVVMExample.DAL
{
    public class DataProvider
    {
        private int _bookNumber;

        private static ObservableCollection<StringWrapper> _allBooks = new ObservableCollection<StringWrapper>();

        private readonly List<string> _books;

        public DataProvider()
        {
            _books = new List<string>{ "Marry Poppins", "Chipollino", "Cindirella" };
        }

        public ObservableCollection<StringWrapper> Get()
        {
            var result = new ObservableCollection<StringWrapper>();

            foreach (var book in _allBooks)
            {
                result.Add(book);
            }

            return result;
        }

        public void Update(ObservableCollection<StringWrapper> data)
        {
            _allBooks = new ObservableCollection<StringWrapper>();

            foreach (var s in data)
            {
                _allBooks.Add(s);
            }

            for (var i = 0; i < new Random().Next(0, 2); i++)
            {
                _allBooks.Add(new StringWrapper(_books[_bookNumber]));
                _bookNumber = _bookNumber >= _books.Count() ? 0 : _bookNumber + 1;
            }

            if (DatabaseUpdated != null)
                DatabaseUpdated(_allBooks);
        }

        public delegate void UpdateHandler(ObservableCollection<StringWrapper> list);
        public UpdateHandler DatabaseUpdated;
    }
}
