using System;
using System.Collections.Generic;
using System.Reflection;

public class BlacklistedMethod
{
    private readonly Type _type;
    private readonly string[] _methodNames;

    public BlacklistedMethod(Type type, params string[] methodNames)
    {
        _type = type;
        _methodNames = methodNames;
    }

    public bool Check(object sender, out IEnumerable<BlacklistedMethodInfo> findedMethods)
    {
        var type = sender.GetType();

        var methods = new List<BlacklistedMethodInfo>();

        while (type != _type)
        {
            foreach (var name in _methodNames)
            {
                var method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (method == null) continue;

                var methodInfo = new BlacklistedMethodInfo(method.Name, type.Name);
                methods.Add(methodInfo);
            }

            type = type.BaseType;
        }

        findedMethods = methods;

        return methods.Count > 0;
    }
}