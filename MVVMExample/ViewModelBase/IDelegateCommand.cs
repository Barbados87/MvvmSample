using System.Windows.Input;

namespace MVVMExample.ViewModelBase
{
    public interface IDelegateCommand : ICommand
    {
        string Name { get; }

        bool Enabled { get; }
    }
}