using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using MVVMExample.ViewModelBase;

namespace MVVMExample
{
    public static class ControlExtensions
    {
        public static TControl Bind<TControl, TSource, TTargetType, TSourceType>(
            this TControl control,
            Expression<Func<TControl, TTargetType>> controlExpression,
            TSource source,
            Expression<Func<TSource, TSourceType>> sourceExpression,
            bool formattingEnabled = true,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            Func<TSourceType, TTargetType> converter = null,
            Func<TTargetType, TSourceType> backConverter = null)
            where TControl : Control
        {
            Binding binding = new Binding(ExpressionHelper.GetMemberName(controlExpression), source,
                ExpressionHelper.GetMemberName(sourceExpression), formattingEnabled, dataSourceUpdateMode);

            if (converter != null)
            {
                binding.FormattingEnabled = true;
                binding.Format += (sender, convertEventArgs) => BindingOnFormat(sender, convertEventArgs, converter);
            }

            if (backConverter != null)
            {
                binding.FormattingEnabled = true;
                binding.Parse += (sender, convertEventArgs) => BindingOnParse(sender, convertEventArgs, backConverter);
            }

            control.DataBindings.Add(binding);

            return control;
        }

        private static void BindingOnFormat<TSourceType, TTargetType>(object sender, ConvertEventArgs convertEventArgs, Func<TSourceType, TTargetType> converter)
        {
            convertEventArgs.Value = converter((TSourceType)convertEventArgs.Value);
        }

        private static void BindingOnParse<TTargetType, TSourceType>(object sender, ConvertEventArgs convertEventArgs, Func<TTargetType, TSourceType> converter)
        {
            convertEventArgs.Value = converter((TTargetType)convertEventArgs.Value);
        }

        public static T FindControl<T>(this Control control) where T : Control
        {
            var findedControl = control.Parent;

            if (findedControl == null)
            {
                return null;
            }

            if (findedControl.GetType() != typeof(T))
            {
                return FindControl<T>(findedControl);
            }

            return (T)findedControl;
        }
    }
}
