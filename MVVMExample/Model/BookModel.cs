using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using MVVMExample.ViewModelBase;

namespace MVVMExample.Model
{
    public class BookModel : ModelBase
    {
        /// <summary>
        /// Gets or sets the book names.
        /// </summary>
        /// <value>
        /// The book names.
        /// </value>
        public ObservableCollection<StringWrapper> BookNames { get; set; }
        
        [MinLength(5)]
        [Required]
        public string Name { get; set; }

        public BookModel()
        {
            BookNames = new ObservableCollection<StringWrapper>();
        }
    }
}
