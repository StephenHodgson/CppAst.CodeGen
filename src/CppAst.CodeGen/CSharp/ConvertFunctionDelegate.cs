namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpElement ConvertFunctionDelegate(CSharpConverter converter, CppFunction cppFunction, CSharpElement context);
}