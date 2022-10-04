using System.Linq.Expressions;

namespace SMS.Submissions.CrossCutting.Extensions;


public static class PredicateExpressionExtensions
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {
        var parameter = a.Parameters[0];
        var visitor = new SubstExpressionVisitor();
        visitor.subst[b.Parameters[0]] = parameter;
        var body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Func<T, bool>>(body, parameter);

    }

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    {
        var parameter = a.Parameters[0];
        var visitor = new SubstExpressionVisitor();
        visitor.subst[b.Parameters[0]] = parameter;
        var body = Expression.Or(a.Body, visitor.Visit(b.Body));
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

internal class SubstExpressionVisitor : ExpressionVisitor
{
    public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

    protected override Expression VisitParameter(ParameterExpression node)
        => subst.TryGetValue(node, out var newValue) ? newValue : node;
}