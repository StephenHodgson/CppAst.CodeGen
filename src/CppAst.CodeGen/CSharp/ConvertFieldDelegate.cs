namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpElement ConvertFieldDelegate(CSharpConverter converter, CppField cppField, CSharpElement context);
}