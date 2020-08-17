using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Project.identityserver.Domain.Core.Utils
{
    public static class InstanceCreator
    {
        static public object Create<TArg, TClass>(TArg arg)
        {
            var constructor = typeof(TClass).GetConstructor(new Type[] { typeof(TArg) });
            var parameter = Expression.Parameter(typeof(TArg), "p");
            var creatorExpression = Expression.Lambda<Func<TArg, TClass>>(
                Expression.New(constructor, new Expression[] { parameter }), parameter);
            var func = creatorExpression.Compile();

            var creator = func;

            return creator(arg);
        }

        public delegate T Creator<T>(params object[] args);

        public static Creator<T> GetCreator<T>(params object[] args)
        {
            // Get constructor information?
            ConstructorInfo[] constructors = typeof(T).GetConstructors();

            // Is there at least 1?
            if (constructors.Length >= 0)
            {
                // Get our one constructor.
                ConstructorInfo constructor = constructors.Where(c => c.GetParameters().Length == args.Length).FirstOrDefault();

                // Yes, does this constructor take some parameters?
                ParameterInfo[] paramsInfo = constructor.GetParameters();

                if (paramsInfo.Length > 0)
                {
                    // Create a single param of type object[].
                    ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

                    // Pick each arg from the params array and create a typed expression of them.
                    Expression[] argsExpressions = new Expression[paramsInfo.Length];

                    for (int i = 0; i < paramsInfo.Length; i++)
                    {
                        Expression index = Expression.Constant(i);
                        Type paramType = paramsInfo[i].ParameterType;
                        Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                        Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                        argsExpressions[i] = paramCastExp;
                    }

                    // Make a NewExpression that calls the constructor with the args we just created.
                    NewExpression newExpression = Expression.New(constructor, argsExpressions);

                    // Create a lambda with the NewExpression as body and our param object[] as arg.
                    LambdaExpression lambda = Expression.Lambda(typeof(Creator<T>), newExpression, param);

                    // Compile it
                    Creator<T> compiled = (Creator<T>)lambda.Compile();

                    // Success
                    return compiled;
                }
            }

            return null;
        }

        public static T CreateInstanceUsingLamdaExpression<T>(params object[] args)
        {
            Creator<T> createdActivator = GetCreator<T>(args);
            return createdActivator(args);
        }

    }
}




