using System.Collections.Generic;

namespace CppAst.CodeGen.CSharp
{
    public interface ICSharpContextualAttributesProvider
    {
        IEnumerable<CSharpAttribute> GetContextualAttributes();
    }
}