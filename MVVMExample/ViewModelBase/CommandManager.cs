using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MVVMExample.ViewModelBase
{
    /// <summary>
    /// Represent Command Manager for emulate Commands binding in Windows Forms
    /// </summary>
    public class CommandManager : Component
    {
        private List<IDelegateCommand> Commands { get; set; }

        private List<IDelegateCommandBinder> Binders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandManager"/> class.
        /// </summary>
        public CommandManager()
        {
            Commands = new List<IDelegateCommand>();

            Binders = new List<IDelegateCommandBinder>
                          {
                              new ControlBinder()
                          };

            Application.Idle += UpdateCommandState;
        }

        /// <summary>
        /// Binds the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        public CommandManager Bind(IDelegateCommand command, IComponent component)
        {
            if (!Commands.Contains(command))
                Commands.Add(command);

            FindBinder(component).Bind(command, component);
            return this;
        }

        /// <summary>
        /// Finds the binder for specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        protected IDelegateCommandBinder FindBinder(IComponent component)
        {
            var binder = GetBinderFor(component);

            if (binder == null)
                throw new Exception(string.Format("No binding found for component of type {0}", component.GetType().Name));

            return binder;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Application.Idle -= UpdateCommandState;

            base.Dispose(disposing);
        }

        /// <summary>
        /// Updates the state of the command.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UpdateCommandState(object sender, EventArgs e)
        {
            Commands.ForEach(c => c.CanExecute(this));
        }

        /// <summary>
        /// Gets the binder for specified component.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns></returns>
        private IDelegateCommandBinder GetBinderFor(IComponent component)
        {
            var type = component.GetType();
            while (type != null)
            {
                var binder = Binders.FirstOrDefault(x => x.SourceType == type);
                if (binder != null)
                    return binder;

                type = type.BaseType;
            }

            return null;
        }
    }
}
