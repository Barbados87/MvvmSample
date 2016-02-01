using System;
using System.ComponentModel;

namespace MVVMExample.ViewModelBase
{
    /// <summary>
    /// Generic binder for component
    /// </summary>
    /// <typeparam name="T">Component for command to</typeparam>
    public abstract class CommandBinder<T> : IDelegateCommandBinder where T : IComponent
    {
        /// <summary>
        /// Gets source type of the component
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public Type SourceType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// Binds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source.</param>
        public void Bind(IDelegateCommand command, object source)
        {
            Bind(command, (T)source);
        }

        /// <summary>
        /// Binds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source.</param>
        protected abstract void Bind(IDelegateCommand command, T source);
    }
}