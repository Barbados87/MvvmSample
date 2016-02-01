using System;
using System.Linq.Expressions;
using MVVMExample.Properties;

namespace MVVMExample.ViewModelBase
{
    public static class ExpressionHelper
    {
        public static string GetMemberName(Expression expression)
        {
            if (expression is LambdaExpression)
                expression = ((LambdaExpression) expression).Body;
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression) expression;
                    var supername = GetMemberName(memberExpression.Expression);
                    if (string.IsNullOrEmpty(supername))
                    {
                        return memberExpression.Member.Name;
                    }

                    return string.Concat(supername, '.', memberExpression.Member.Name);
                case ExpressionType.Call:
                    var callExpression = (MethodCallExpression) expression;
                    return callExpression.Method.Name;
                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression) expression;
                    return GetMemberName(unaryExpression.Operand);
                case ExpressionType.Parameter:
                case ExpressionType.Constant: 
                    return String.Empty;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
