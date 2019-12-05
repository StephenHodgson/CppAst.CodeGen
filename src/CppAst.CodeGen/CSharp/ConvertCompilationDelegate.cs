namespace CppAst.CodeGen.CSharp
{
    public delegate CSharpCompilation ConvertCompilationDelegate(CSharpConverter converter, CppCompilation cppCompilation, CSharpElement context);
}