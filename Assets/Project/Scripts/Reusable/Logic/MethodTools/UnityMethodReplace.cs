using System;

public class UnityMethodReplace
{
    private readonly BlacklistedMethod _methodBlacklist;
    private readonly RecursiveMethodCall _recurciveMethodCall;

    private readonly string[] _oldMethodNames;
    private readonly string _newMethodName;

    public UnityMethodReplace(Type type, string newName, params string[] oldNames)
    {
        _newMethodName = newName;
        _oldMethodNames = oldNames;

        _methodBlacklist = new BlacklistedMethod(type, _oldMethodNames);
        _recurciveMethodCall = new RecursiveMethodCall(type, _newMethodName);
    }

    public void CheckOldMethods(object sender)
    {
        if (!_methodBlacklist.Check(sender, out var findedMethods)) return;

        foreach (var method in findedMethods)
        {
            var methodName = method.MethodName;
            var className = method.ClassName;
            ThrowException(methodName, className);
        }
    }

    public void InvokeAll(object sender) => _recurciveMethodCall.InvokeAll(sender);
    public void ReversedInvokeAll(object sender) => _recurciveMethodCall.ReversedInvokeAll(sender);

    private void ThrowException(string oldMethodName, string className)
    {
        throw new Exception($"Method \"{oldMethodName}\" in class \"{className}\" cannot be declared because it is in the black list. Use method \"{_newMethodName}\" instead of methods \"{string.Join(", ", _oldMethodNames)}\"");
    }
}