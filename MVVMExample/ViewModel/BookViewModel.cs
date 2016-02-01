using System.Collections.ObjectModel;
using MVVMExample.DAL;
using MVVMExample.Model;
using MVVMExample.ViewModelBase;

namespace MVVMExample.ViewModel
{
    public class BookViewModel : ViewModelBase<BookModel>
    {
        private readonly DataProvider _dataProvider = new DataProvider();

        public ObservableCollection<StringWrapper> BookNames
        {
            get { return _model.BookNames; }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                if (Name != value)
                {
                    _model.Name = value;
                    OnPropertyChanged<BookViewModel, string>(v => v.Name);
                }
            }
        }

        public BookViewModel(BookModel model) : base(model)
        {
            _model.BookNames = _dataProvider.Get();
            BookNames.CollectionChanged += ListCollectionChanged;
            _dataProvider.DatabaseUpdated += UpdateFromDb;
        }

        private void UpdateFromDb(ObservableCollection<StringWrapper> books)
        {
            _model.BookNames = books;
            BookNames.CollectionChanged += ListCollectionChanged;
            OnPropertyChanged<BookViewModel, ObservableCollection<StringWrapper>>(v => v.BookNames);
        }

        private void ListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _dataProvider.Update(BookNames);
        }
    }
}
