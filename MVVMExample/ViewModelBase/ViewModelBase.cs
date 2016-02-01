using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MVVMExample.ViewModelBase
{
    public class ViewModelBase<T> : INotifyPropertyChanged, IDataErrorInfo where T : ModelBase
    {
        protected T _model;

        public ViewModelBase(T modelBase)
        {
            _model = modelBase;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged

        public string this[string columnName]
        {
            get
            {
                return _model[columnName];
            }
        }

        public string Error
        {
            get
            {
                return _model.Error;
            }
        }
        
        protected void OnPropertyChanged<TViewModel, TValue>(Expression<Func<TViewModel, TValue>> expression) where TViewModel : ViewModelBase<T>
        {
            string propertyName = ExpressionHelper.GetMemberName(expression);
            
            OnPropertyChanged(propertyName);
        }
    }
}