namespace CppAst.CodeGen.CSharp
{
    public class CSharpBitField : CSharpField
    {
        public CSharpBitField(string name) : base(name)
        {
        }

        internal int CurrentBitWidth { get; set; }

        internal int MaxBitWidth { get; set; }
    }
}