using System.ComponentModel;

namespace MVVMExample.ViewModelBase
{
    public class ModelBase : IDataErrorInfo
    {
        protected DataErrorSupport DataErrorSupport;

        public ModelBase()
        {
            DataErrorSupport = new DataErrorSupport(this);
        }

        public T Clone<T>() where T : ModelBase
        {
            T model = (T)this.MemberwiseClone();
            model.DataErrorSupport = new DataErrorSupport(model);

            return model;
        }

        public DataErrorSupport AddValidationRule(string memberName, ValidationRuleDelegate validationRule)
        {
            return DataErrorSupport.AddValidationRule(memberName, validationRule);
        }

        #region IDataErrorInfo

        public string Error
        {
            get { return DataErrorSupport.Error; }
        }

        public string this[string memberName]
        {
            get { return DataErrorSupport[memberName]; }
        }

        #endregion IDataErrorInfo
    }
}