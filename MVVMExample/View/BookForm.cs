using System.Windows.Forms;
using MVVMExample.ViewModel;
using MVVMExample.ViewModelBase;

namespace MVVMExample.View
{
    public partial class BookForm : Form
    {
        private readonly CommandManager _commandManager = new CommandManager();

        private BookViewModel _viewModel;

        public BookForm(BookViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            tbName.Bind(tb => tb.Text, _viewModel, v => v.Name);
            errName.DataSource = _viewModel;

            var command = new DelegateCommand(d => AddToBookList(), c => !string.IsNullOrEmpty(_viewModel.Name));
            _commandManager.Bind(command, btnAdd);
        }

        private void AddToBookList()
        {
            _viewModel.BookNames.Add(new StringWrapper(_viewModel.Name));
            tbName.Text = string.Empty;
            tbName.Focus();
        }
    }
}
