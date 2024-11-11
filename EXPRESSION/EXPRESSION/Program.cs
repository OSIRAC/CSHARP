using System;
using System.Linq.Expressions;

namespace EXPRESSION

{
    class Program
    {
        static void Main(string[] args)
        {

            Expression<Func<int, bool>> exp = i => i > 5;

            BinaryExpression binary = (BinaryExpression)exp.Body;

            Console.WriteLine(binary.Type);
            Console.WriteLine(binary.Right);
            Console.WriteLine(binary.Left);
            Console.WriteLine(binary.NodeType);

            ConstantExpression constExp = Expression.Constant(5, typeof(int));

            Console.WriteLine(constExp.Value);
            Console.WriteLine(constExp.NodeType);
            Console.WriteLine(constExp.Type);

           ParameterExpression iParam = Expression.Parameter(typeof(int),"i");

            Console.WriteLine(iParam.Name);
            Console.WriteLine(iParam.NodeType);
            Console.WriteLine(iParam.Type);

            BinaryExpression body = Expression.GreaterThan(constExp, iParam);

            Expression<Func<int, bool>> exp1 = Expression.Lambda<Func<int, bool>>(body, iParam);

            Func<int, bool> test = exp1.Compile();

            Console.WriteLine(test(2));
        }
    }
}
