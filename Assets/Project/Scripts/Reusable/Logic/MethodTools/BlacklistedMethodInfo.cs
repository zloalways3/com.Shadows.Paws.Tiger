public readonly struct BlacklistedMethodInfo
{
    public readonly string MethodName;
    public readonly string ClassName;

    internal BlacklistedMethodInfo(string methodName, string className)
    {
        MethodName = methodName;
        ClassName = className;
    }
}