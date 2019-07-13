using CppAst.CodeGen.Common;

namespace CppAst.CodeGen.CSharp.Marshalers
{
    public abstract class CSharpMarshalerUnmanagedNoCleanupBase : CSharpMarshaler
    {
        public override bool RequiresCleanupUserToNative => false;

        public override bool RequiresCleanupNativeToUser => false;

        public override bool IsUserReferenceType => false;

        public override void CreateSharedCode(CSharpConverter converter)
        {
        }

        public override void CleanupNativeToUser(CSharpConverter converter, CodeWriter writer, string nativeVariable)
        {
        }

        public override void CleanupUserToNative(CSharpConverter converter, CodeWriter writer, string nativeVariable)
        {
        }
    }
}