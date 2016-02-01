namespace MVVMExample.ViewModelBase
{
    public class StringWrapper
    {
        private string _data;

        public string Name
        {
            get { return _data; }
            set
            {
                _data = value;
            }
        }

        public StringWrapper(string s)
        {
            _data = s;
        }

        public static implicit operator string(StringWrapper w)
        {
            return w.Name;
        }

        public static implicit operator StringWrapper(string s)
        {
            return new StringWrapper(s);
        }
    }
}
