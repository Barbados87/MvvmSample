using System.Windows.Forms;

namespace MVVMExample.ViewModelBase
{
    /// <summary>
    /// Binder for command and control
    /// </summary>
    public class ControlBinder : CommandBinder<Control>
    {
        /// <summary>
        /// Binds the specified command for any UI control.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="source">The source.</param>
        protected override void Bind(IDelegateCommand command, Control source)
        {
            source.DataBindings.Add("Enabled", command, "Enabled");

            if (command.Name != null)
                source.DataBindings.Add("Text", command, "Name");

            source.Click += (o, e) => command.Execute(source.Tag);

            command.CanExecuteChanged += (o, e) => source.Enabled = command.Enabled;
        }
    }
}