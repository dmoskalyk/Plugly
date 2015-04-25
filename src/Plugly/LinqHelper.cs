using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    class LinqHelper
    {
        Type from;
        Type to;

        Dictionary<Expression, Expression> map;

        private LinqHelper(Type from, Type to)
        {
            this.from = from;
            this.to = to;
            this.map = new Dictionary<Expression, Expression>();
        }

        public static Delegate RemapCalls(Type from, Type to, LambdaExpression expr)
        {
            var helper = new LinqHelper(from, to);
            var newExpr = (LambdaExpression)helper.Convert(expr);
            return newExpr.Compile();
        }

        T Process<T>(T expr)
            where T : Expression
        {
            if (expr == null)
                return null;

            Expression existing;
            if (map.TryGetValue(expr, out existing))
                return (T)existing;
            
            var result = (T)DoProcess(expr);
            map.Add(expr, result);
            return result;
        }

        Expression DoProcess(Expression expr)
        {
            if (expr is LambdaExpression)
                return Convert(expr as LambdaExpression);
            else if (expr is BinaryExpression)
                return Convert(expr as BinaryExpression);
            else if (expr is BlockExpression)
                return Convert(expr as BlockExpression);
            else if (expr is ConditionalExpression)
                return Convert(expr as ConditionalExpression);
            else if (expr is DefaultExpression)
                return Convert(expr as DefaultExpression);
            else if (expr is IndexExpression)
                return Convert(expr as IndexExpression);
            else if (expr is InvocationExpression)
                return Convert(expr as InvocationExpression);
            else if (expr is ListInitExpression)
                return Convert(expr as ListInitExpression);
            else if (expr is LoopExpression)
                return Convert(expr as LoopExpression);
            else if (expr is MemberExpression)
                return Convert(expr as MemberExpression);
            else if (expr is MemberInitExpression)
                return Convert(expr as MemberInitExpression);
            else if (expr is MethodCallExpression)
                return Convert(expr as MethodCallExpression);
            else if (expr is NewArrayExpression)
                return Convert(expr as NewArrayExpression);
            else if (expr is NewExpression)
                return Convert(expr as NewExpression);
            else if (expr is ParameterExpression)
                return Convert(expr as ParameterExpression);
            else if (expr is RuntimeVariablesExpression)
                return Convert(expr as RuntimeVariablesExpression);
            else if (expr is SwitchExpression)
                return Convert(expr as SwitchExpression);
            else if (expr is TryExpression)
                return Convert(expr as TryExpression);
            else if (expr is TypeBinaryExpression)
                return Convert(expr as TypeBinaryExpression);
            else if (expr is UnaryExpression)
                return Convert(expr as UnaryExpression);
            else
                return expr;
        }

        IEnumerable<T> Process<T>(System.Collections.ObjectModel.ReadOnlyCollection<T> collection)
            where T : Expression
        {
            return collection.Select(Process);
        }

        IEnumerable<T> Process<T>(IEnumerable<T> collection)
            where T : Expression
        {
            return collection.Select(Process);
        }

        LambdaExpression Convert(LambdaExpression expr)
        {
            Type delegateType = expr.Type;
            if (delegateType.IsGenericType)
            {
                var genericParameters = delegateType.GetGenericArguments();
                if (genericParameters.Contains(from))
                {
                    genericParameters = genericParameters.Select(p => p == from ? to : p).ToArray();
                    delegateType = delegateType.GetGenericTypeDefinition().MakeGenericType(genericParameters);
                }
            }
            return Expression.Lambda(delegateType, Process(expr.Body), expr.Name, expr.TailCall, Process(expr.Parameters));
        }

        ParameterExpression Convert(ParameterExpression expr)
        {
            if (expr.Type == from)
                return Expression.Parameter(to, expr.Name);
            else
                return expr;
        }

        BinaryExpression Convert(BinaryExpression expr)
        {
            return expr.Update(Process(expr.Left), Process(expr.Conversion), Process(expr.Right));
        }

        BlockExpression Convert(BlockExpression expr)
        {
            return expr.Update(Process(expr.Variables), Process(expr.Expressions));
        }

        ConditionalExpression Convert(ConditionalExpression expr)
        {
            return expr.Update(Process(expr.Test), Process(expr.IfTrue), Process(expr.IfFalse));
        }

        IndexExpression Convert(IndexExpression expr)
        {
            return expr.Update(Process(expr.Object), Process(expr.Arguments));
        }

        InvocationExpression Convert(InvocationExpression expr)
        {
            return expr.Update(Process(expr.Expression), Process(expr.Arguments));
        }

        ListInitExpression Convert(ListInitExpression expr)
        {
            return expr.Update(Process(expr.NewExpression), expr.Initializers.Select(i => i.Update(Process(i.Arguments))));
        }

        LoopExpression Convert(LoopExpression expr)
        {
            return expr.Update(expr.BreakLabel, expr.ContinueLabel, Process(expr.Body));
        }

        MemberExpression Convert(MemberExpression expr)
        {
            return expr.Update(Process(expr.Expression)); // member
        }

        MemberInitExpression Convert(MemberInitExpression expr)
        {
            return expr.Update(Process(expr.NewExpression), expr.Bindings); // bindings: list, ...
        }

        MethodCallExpression Convert(MethodCallExpression expr)
        {
            return expr.Update(Process(expr.Object), Process(expr.Arguments)); // method
        }

        NewArrayExpression Convert(NewArrayExpression expr)
        {
            return expr.Update(Process(expr.Expressions));
        }

        NewExpression Convert(NewExpression expr)
        {
            return expr.Update(Process(expr.Arguments));
        }

        RuntimeVariablesExpression Convert(RuntimeVariablesExpression expr)
        {
            return expr.Update(Process(expr.Variables));
        }

        SwitchExpression Convert(SwitchExpression expr)
        {
            var cases = expr.Cases.Select(c => c.Update(Process(c.TestValues), Process(c.Body)));
            return expr.Update(Process(expr.SwitchValue), cases, Process(expr.DefaultBody));
        }

        TryExpression Convert(TryExpression expr)
        {
            var handlers = expr.Handlers.Select(h => h.Update(Process(h.Variable), Process(h.Filter), Process(h.Body)));
            return expr.Update(Process(expr.Body), handlers, Process(expr.Finally), Process(expr.Fault));
        }

        TypeBinaryExpression Convert(TypeBinaryExpression expr)
        {
            return expr.Update(Process(expr.Expression)); // TypeOperand
        }

        UnaryExpression Convert(UnaryExpression expr)
        {
            return expr.Update(Process(expr.Operand));
        }

        DefaultExpression Convert(DefaultExpression expr)
        {
            if (expr.Type == from)
                return Expression.Default(to);
            else
                return expr;
        }
    }
}
