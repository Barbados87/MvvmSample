using System;

namespace MVVMExample.ViewModelBase
{
    public class DelegateCommand : IDelegateCommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        private bool _enabled;

        public string Name { get; private set; }

        public DelegateCommand(Action<object> execute)
            : this(null, execute, null)
        {
        }

        public DelegateCommand(string name, Action<object> execute)
            : this(name, execute, null)
        {
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
            : this(null, execute, canExecute)
        {
        }

        public DelegateCommand(string name, Action<object> execute, Predicate<object> canExecute)
        {
            if (name != null)
                Name = name;
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                _enabled = true;
                return _enabled;
            }

            bool newState = _canExecute(parameter);
            if (newState != _enabled)
            {
                _enabled = newState;
                OnCanExecuteChanged();
            }

            return _enabled;
        }

        /// <summary>
        /// Gets a value indicating whether this command can execute.
        /// </summary>
        /// <returns>
        ///   <see langword="true"/> if the command can execute, otherwise <see langword="false"/>.
        ///   </returns>
        /// <remarks>
        /// If there is no delegate to determine whether the command can execute, this method will return <see langword="true"/>. If a delegate was provided, this
        /// method will invoke that delegate.
        /// </remarks>
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <remarks>
        /// This method invokes the provided delegate to execute the command.
        /// </remarks>
        /// <param name="parameter">
        /// The command parameter.
        /// </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Fires <see cref="CanExecuteChanged"/>.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}