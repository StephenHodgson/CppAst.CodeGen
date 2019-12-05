using System.Collections.Generic;

namespace CppAst.CodeGen.CSharp
{
    public delegate void CSharpElementModifierDelegate(CSharpConverter converter, CSharpElement csElement, List<ICppElementMatch> matches);
}