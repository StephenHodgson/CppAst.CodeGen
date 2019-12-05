using System;

namespace CppAst.CodeGen.CSharp
{
    public class CSharpFreeAttribute : CSharpAttribute
    {
        public CSharpFreeAttribute(string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public CSharpFreeAttribute(CSharpAttributeScope scope, string text)
        {
            Scope = scope;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public string Text { get; set; }

        /// <inheritdoc />
        public override string ToText() => Text;
    }
}