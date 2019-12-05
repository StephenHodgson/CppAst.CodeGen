namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpElement ConvertTypedefDelegate(CSharpConverter converter, CppTypedef cppTypedef, CSharpElement context);
}