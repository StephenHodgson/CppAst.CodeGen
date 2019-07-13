using CppAst.CodeGen.Common;

namespace CppAst.CodeGen.CSharp.Marshalers
{
    public class CSharpMarshalerUTF8String : CSharpMarshaler
    {
        public CSharpMarshalerUTF8String(bool requiresCleanupNative)
        {
            RequiresCleanupNativeToUser = requiresCleanupNative;
        }

        public override CSharpType GetNativeType(CppType cppType, CSharpType csType)
        {
            throw new System.NotImplementedException();
        }

        public override bool RequiresCleanupUserToNative => true;

        public override bool RequiresCleanupNativeToUser { get; }
        

        public override bool IsUserReferenceType => true;

        public override void CreateSharedCode(CSharpConverter converter)
        {
            
        }

        public override void NativeToUser(CSharpConverter converter, CodeWriter writer, string nativeVariable)
        {
            throw new System.NotImplementedException();
        }

        public override void UserToNative(CSharpConverter converter, CodeWriter writer, string userVariable)
        {
            throw new System.NotImplementedException();
        }

        public override void CleanupNativeToUser(CSharpConverter converter, CodeWriter writer, string nativeVariable)
        {
            throw new System.NotImplementedException();
        }

        public override void CleanupUserToNative(CSharpConverter converter, CodeWriter writer, string nativeVariable)
        {
            throw new System.NotImplementedException();
        }
    }
}