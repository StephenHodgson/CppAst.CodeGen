// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using CppAst.CodeGen.Common;

namespace CppAst.CodeGen.CSharp
{
    public abstract class CSharpAttribute : CSharpElement
    {
        public CSharpAttributeScope Scope { get; set; }

        public abstract string ToText();

        public CSharpAttribute Clone()
        {
            return (CSharpAttribute)MemberwiseClone();
        }

        public override void DumpTo(CodeWriter writer)
        {
            DumpTo(writer, Scope);
        }

        public void DumpTo(CodeWriter writer, CSharpAttributeScope scopeOverride)
        {
            if (scopeOverride != CSharpAttributeScope.None)
            {
                writer.Write(scopeOverride == CSharpAttributeScope.Return ? "return: " : "assembly: ");
            }

            writer.Write(ToText());
        }
    }
}