namespace PassiveViewTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    public class Validator
    {
        public static bool Validate(Expression<Action> expression, Expression<Action> expectation)
        {
            MethodCallExpression methodExpression = expression.Body as MethodCallExpression;
            MethodCallExpression expectedExpression = expectation.Body as MethodCallExpression;
            if (methodExpression == null ||
                expectedExpression == null ||
                methodExpression.Method != expectedExpression.Method)
            {
                return false;
            }

            if (methodExpression.Arguments.Count == 0)
            {
                return true;
            }

            if (methodExpression.Arguments.Count != expectedExpression.Arguments.Count)
            {
                return false;
            }

            LambdaExpression method = Expression.Lambda(Expression.Convert(
                                    methodExpression.Arguments[0],
                                    methodExpression.Arguments[0].Type));

            LambdaExpression expectedMethod = Expression.Lambda(Expression.Convert(
                                    expectedExpression.Arguments[0],
                                    expectedExpression.Arguments[0].Type));

            return method.Compile().DynamicInvoke().Equals(expectedMethod.Compile().DynamicInvoke());
        }
    }
}
