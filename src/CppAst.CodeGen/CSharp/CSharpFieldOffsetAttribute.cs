namespace CppAst.CodeGen.CSharp
{
    public class CSharpFieldOffsetAttribute : CSharpAttribute
    {
        public CSharpFieldOffsetAttribute(int offset = 0, int fieldSize = 0)
        {
            Offset = offset;
            FieldSize = fieldSize;
        }

        public int Offset { get; }

        public int FieldSize { get; }

        public override string ToText()
        {
            return $"FieldOffset({Offset})";
        }
    }
}