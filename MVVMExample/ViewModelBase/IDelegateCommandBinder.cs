using System;

namespace MVVMExample.ViewModelBase
{
    /// <summary>
    /// Represents standard binder for delegate command and some source
    /// </summary>
    public interface IDelegateCommandBinder
    {
        /// <summary>
        /// Gets the type of the source.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        Type SourceType { get; }

        /// <summary>
        /// Binds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source.</param>
        void Bind(IDelegateCommand command, object source);
    }
}