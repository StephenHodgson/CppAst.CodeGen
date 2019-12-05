namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpElement ConvertNamespaceDelegate(CSharpConverter converter, CppNamespace cppNamespace, CSharpElement context);
}