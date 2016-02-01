using System;
using System.Windows.Forms;
using MVVMExample.Model;
using MVVMExample.ViewModel;

namespace MVVMExample.View
{
    public partial class BooksForm : Form
    {
        private BookViewModel _viewModel;

        public BooksForm()
        {
            InitializeComponent();
            _viewModel = new BookViewModel(new BookModel());

            gvBooks.Bind(g => g.DataSource, _viewModel, v => v.BookNames);
            _viewModel.PropertyChanged += (sender, args) => BindDataGridView();
        }

        private void BindDataGridView()
        {
            var binding = new BindingSource
            {
                DataSource = _viewModel.BookNames
            };

            gvBooks.DataSource = binding;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm(_viewModel);
            bookForm.FormClosing += (o, args) => bookForm.Dispose();
            bookForm.Show();
        }
    }
}
