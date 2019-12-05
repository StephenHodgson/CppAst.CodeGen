using System.Collections.Generic;

namespace CppAst.CodeGen.CSharp
{
    public interface ICSharpAttributesProvider
    {
        IEnumerable<CSharpAttribute> GetAttributes();
    }
}