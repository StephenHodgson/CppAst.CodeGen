using System.Collections.Generic;

namespace CppAst.CodeGen.CSharp
{
    public delegate void CppElementModifierDelegate(CSharpConverter converter, CppElement cppElement, CSharpElement context, List<ICppElementMatch> matches);
}