﻿using System.Linq.Expressions;

 namespace Venu.Events.API.Infrastructure.Helpers
{
    internal class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression _replace;

        public ParameterReplaceVisitor(Expression replace)
        {
            _replace = replace;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _replace;
        }
    }
}
