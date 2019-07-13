using CppAst.CodeGen.Common;

namespace CppAst.CodeGen.CSharp.Marshalers
{
    public abstract class CSharpMarshaler
    {
        public abstract CSharpType GetNativeType(CppType cppType, CSharpType csType);

        public abstract bool RequiresCleanupUserToNative { get; }

        public abstract bool RequiresCleanupNativeToUser { get; }
        
        public abstract bool IsUserReferenceType { get; }

        public abstract void CreateSharedCode(CSharpConverter converter);

        public abstract void NativeToUser(CSharpConverter converter, CodeWriter writer, string nativeVariable);

        public abstract void UserToNative(CSharpConverter converter, CodeWriter writer, string userVariable);
       
        public abstract void CleanupNativeToUser(CSharpConverter converter, CodeWriter writer, string nativeVariable);

        public abstract void CleanupUserToNative(CSharpConverter converter, CodeWriter writer, string nativeVariable);
    }
}