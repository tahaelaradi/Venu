using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Venu.Events.API.Helpers
{
    public class FilterContainer<T>
    {
        private readonly List<LambdaExpression> _lambdaExpressions = new List<LambdaExpression>();

        public void AddFilterCondition(Expression<Func<T, bool>> lambdaExpression)
        {
            _lambdaExpressions.Add(lambdaExpression);
        }

        /// <summary>
        /// Combines all lambda expressions into one
        /// </summary>
        /// <returns></returns>
        public Expression<Func<T, bool>> GetFilter()
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            var parameterReplaceVisitor = new ParameterReplaceVisitor(parameter);

            Expression resultingExpressionBody = Expression.Constant(true);
            var expression = _lambdaExpressions
                .Select(lambdaExpression => parameterReplaceVisitor.Visit(lambdaExpression.Body))
                .Aggregate(resultingExpressionBody, Expression.AndAlso);

            return Expression.Lambda<Func<T, bool>>(expression, parameter);
        }
    }
}
