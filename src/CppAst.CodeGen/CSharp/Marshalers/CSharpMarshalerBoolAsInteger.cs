using System;
using CppAst.CodeGen.Common;

namespace CppAst.CodeGen.CSharp.Marshalers
{
    public class CSharpMarshalerBoolAsInteger : CSharpMarshalerUnmanagedNoCleanupBase
    {
        private readonly CSharpPrimitiveType _nativeType;

        public CSharpMarshalerBoolAsInteger(CSharpPrimitiveType nativeType)
        {
            _nativeType = nativeType ?? throw new ArgumentNullException(nameof(nativeType));
        }

        public override CSharpType GetNativeType(CppType cppType, CSharpType csType)
        {
            return _nativeType;
        }
        
        public override void NativeToUser(CSharpConverter converter, CodeWriter writer, string variableName)
        {
            writer.Write($"{variableName} != 0");
        }
        
        public override void UserToNative(CSharpConverter converter,CodeWriter writer, string variableName)
        {
            writer.Write($"{variableName} ? 1 : 0");
        }
    }
}