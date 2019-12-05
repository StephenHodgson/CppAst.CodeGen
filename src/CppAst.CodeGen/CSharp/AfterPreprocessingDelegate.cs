using System.Text;

namespace CppAst.CodeGen.CSharp
{
    public delegate void AfterPreprocessingDelegate(CSharpConverter converter, CppCompilation cppCompilation, StringBuilder additionalHeaders);
}