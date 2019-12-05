namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpElement ConvertParameterDelegate(CSharpConverter converter, CppParameter cppParameter, int index, CSharpElement context);
}