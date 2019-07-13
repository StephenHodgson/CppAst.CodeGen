using System;

namespace CppAst.CodeGen.CSharp.Marshalers
{
    public abstract class CSharpMarshalerMatch
    {
        public abstract bool Match(CppType type);


        public static CSharpMarshalerMatchByName ByName(string name) => new CSharpMarshalerMatchByName(name);

        public static CSharpMarshalerMatchByCppType ByCppType(CppType type) => new CSharpMarshalerMatchByCppType(type);
        
        public static CSharpMarshalerMatchByQuery ByQuery(Func<CppType, bool> query) => new CSharpMarshalerMatchByQuery(query);
    }
    
    public sealed class CSharpMarshalerMatchByName : CSharpMarshalerMatch
    {
        public CSharpMarshalerMatchByName(string matchAsName)
        {
            Name = matchAsName ?? throw new ArgumentNullException(nameof(matchAsName));
        }

        public string Name { get; }
        
        public override bool Match(CppType type)
        {
            return type is ICppMember member && member.Name == Name;
        }
    }

    public sealed class CSharpMarshalerMatchByCppType: CSharpMarshalerMatch
    {
        public CSharpMarshalerMatchByCppType(CppType matchAsType)
        {
            CppType = matchAsType ?? throw new ArgumentNullException(nameof(matchAsType));
        }

        public CppType CppType { get; }

        public override bool Match(CppType type)
        {
            return type.Equals(CppType);
        }
    }

    public sealed class CSharpMarshalerMatchByQuery: CSharpMarshalerMatch
    {
        public CSharpMarshalerMatchByQuery(Func<CppType, bool> matchQuery)
        {
            Query = matchQuery ?? throw new ArgumentNullException(nameof(matchQuery));
        }

        public Func<CppType, bool> Query { get; }
        
        public override bool Match(CppType type)
        {
            return Query(type);
        }
    }
}