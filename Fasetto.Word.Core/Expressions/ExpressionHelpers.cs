using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A helper for a expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">the type of return value</typeparam>
        /// <param name="lamba"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying properties value to given value
        /// from an expression that contains property
        /// </summary>
        /// <typeparam name="T">the type of value to set</typeparam>
        /// <param name="lamba">the expression</param>
        /// <param name="value">the value to set to property</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba, T value)
        {
            // Converts a lambda => some.property, to some.property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            // Get a property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
