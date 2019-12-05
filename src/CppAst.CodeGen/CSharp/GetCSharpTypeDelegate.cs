namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpType GetCSharpTypeDelegate(CSharpConverter converter, CppType cppType, CSharpElement context, bool nested);
}