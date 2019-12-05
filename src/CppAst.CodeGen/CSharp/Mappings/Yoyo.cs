namespace CppAst.CodeGen.CSharp
{
    public static class Yoyo
    {
        public static void Tester()
        {
            var rules = new CppMappingRules
            {
                e => e.Map("name").Private(),
                e => e.Map("xxx").Name("test").Private(),
                e => e.MapAll<CppEnumItem>().CppAction((converter, element) => {}),
                e => e.MapMacroToConst("MACRO", "int"),
                e => e.MapType("int", "SharpDX.Int4"),
                e => e.MapArrayType("int", 4, "SharpDX.Int4")
            };
        }
    }
}