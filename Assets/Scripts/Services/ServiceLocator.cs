using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

    public static void RegisterService<T>(T service)
    {
        var type = typeof(T);
        if (Services.ContainsKey(type))
        {
            throw new InvalidOperationException($"Service of type {type} is already registered.");
        }

        Services[type] = service;
    }

    public static T GetService<T>()
    {
        var type = typeof(T);
        if (Services.TryGetValue(type, out var service))
        {
            return (T)service;
        }

        throw new InvalidOperationException($"Service of type {type} is not registered.");
    }

    public static void Clear() => Services.Clear();
}