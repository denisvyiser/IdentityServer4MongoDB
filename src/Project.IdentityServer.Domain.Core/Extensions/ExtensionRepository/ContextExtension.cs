﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Project.identityserver.Domain.Core.Extensions
{
    public class RepositoryExtension
    {
        public static Expression<Func<T, bool>> LambdaInsertGeneration<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            Expression<Func<T, bool>> func = null;

            var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

            if (ListProperties.Any())
            {

                ParameterExpression tpe = Expression.Parameter(typeof(T), "e"); //ex: Album

                Expression body = tpe;

                Expression left = null;

                for (int i = 0; i < ListProperties.Count(); i++)
                {

                    var valor = Expression.Constant(ListProperties[i].GetValue(obj, null));

                    Expression right = Expression.Property(body, ListProperties[i].Name);

                    right = Expression.Equal(right, valor);

                    if (i > 0 && i < ListProperties.Count())
                    {
                        right = Expression.And(left, right);
                    }

                    left = right;

                    //Expression right = Expression.Convert(body, body.Type);

                }

                func = Expression.Lambda<Func<T, bool>>(left, tpe);
            }

            return func;
        }

        public static Expression<Func<T, bool>> LambdaInsertGenerationOU<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            Expression<Func<T, bool>> func = null;

            var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

            if (ListProperties.Any())
            {

                ParameterExpression tpe = Expression.Parameter(typeof(T), "e"); //ex: Album

                Expression body = tpe;

                Expression left = null;

                for (int i = 0; i < ListProperties.Count(); i++)
                {

                    var valor = Expression.Constant(ListProperties[i].GetValue(obj, null));

                    Expression right = Expression.Property(body, ListProperties[i].Name);

                    right = Expression.Equal(right, valor);

                    if (i > 0 && i < ListProperties.Count())
                    {
                        right = Expression.Or(left, right);
                    }

                    left = right;

                    //Expression right = Expression.Convert(body, body.Type);

                }

                func = Expression.Lambda<Func<T, bool>>(left, tpe);
            }

            return func;
        }

        public static Expression<Func<T, bool>> LambdaUpdateGeneration<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            Expression<Func<T, bool>> func = null;

            var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

            if (ListProperties.Any())
            {

                var Pk = properties.FirstOrDefault(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(KeyAttribute)));

                ParameterExpression tpe = Expression.Parameter(typeof(T), "e"); //ex: Album

                Expression body = tpe;

                Expression left = null;

                Expression right = null;

                if (Pk != null)
                {
                    var valorPk = Expression.Constant(Pk.GetValue(obj, null));

                    right = Expression.Property(body, Pk.Name);

                    right = Expression.NotEqual(right, valorPk);

                    left = right;
                }

                for (int i = 0; i < ListProperties.Count(); i++)
                {
                    var valor = Expression.Constant(ListProperties[i].GetValue(obj, null));

                    right = Expression.Property(body, ListProperties[i].Name);

                    right = Expression.Equal(right, valor);

                    if (left != null)
                    {
                        right = Expression.And(left, right);

                        left = right;
                    }
                    else
                    {
                        left = right;
                    }

                }


                func = Expression.Lambda<Func<T, bool>>(left, tpe);
            }

            return func;
        }

        public static Expression<Func<T, bool>> LambdaUpdateGenerationOr<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            Expression<Func<T, bool>> func = null;

            var ListProperties = properties.Where(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(PropertyValidationAttribute))).ToList();

            if (ListProperties.Any())
            {

                var Pk = properties.FirstOrDefault(c => c.GetCustomAttributes(false).Any(a => a.GetType() == typeof(KeyAttribute)));

                ParameterExpression tpe = Expression.Parameter(typeof(T), "e"); //ex: Album

                Expression body = tpe;

                Expression left = null;

                Expression right = null;

                if (Pk != null)
                {
                    var valorPk = Expression.Constant(Pk.GetValue(obj, null));

                    right = Expression.Property(body, Pk.Name);

                    right = Expression.NotEqual(right, valorPk);

                    left = right;
                }

                for (int i = 0; i < ListProperties.Count(); i++)
                {
                    var valor = Expression.Constant(ListProperties[i].GetValue(obj, null));

                    right = Expression.Property(body, ListProperties[i].Name);

                    right = Expression.Equal(right, valor);

                    if (left != null)
                    {
                        right = Expression.Or(left, right);

                        left = right;
                    }
                    else
                    {
                        left = right;
                    }

                }


                func = Expression.Lambda<Func<T, bool>>(left, tpe);
            }

            return func;
        }

    }
}
