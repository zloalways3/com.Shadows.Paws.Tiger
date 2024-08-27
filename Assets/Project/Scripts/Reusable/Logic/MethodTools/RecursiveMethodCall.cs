using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class RecursiveMethodCall
{
    private readonly Type _type;
    private readonly string _methodName;

    public RecursiveMethodCall(Type type, string methodName)
    {
        _type = type;
        _methodName = methodName;
    }

    public void InvokeAll(object sender)
    {
        var methods = FindMethods(sender);

        for(int i = 0; i < methods.Count; i++)
        {
            var method = methods.ElementAt(i);
            method?.Invoke(sender, null);
        }
    }

    public void ReversedInvokeAll(object sender)
    {
        var methods = FindMethods(sender);

        for (int i = methods.Count - 1; i >= 0; i--)
        {
            var method = methods.ElementAt(i);
            method?.Invoke(sender, null);
        }
    }

    private IReadOnlyCollection<MethodInfo> FindMethods(object sender)
    {
        var methods = new List<MethodInfo>();

        var type = sender.GetType();
        while (type != _type)
        {
            var method = type.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (method != null) methods.Add(method);
            type = type.BaseType;
        }

        return methods;
    }
}