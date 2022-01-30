using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BikeShop.Core.Tests.TestInfrastructure;

public static class FixtureFactory
{
    public static Func<T> FactoryFunc<T>()
    {
        var ctor = typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null);

        var body = Expression.New(ctor);
        var lambda = Expression.Lambda<Func<T>>(body);

        return lambda.Compile();
    }
}