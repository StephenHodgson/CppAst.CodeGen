using System.Linq;

namespace CppAst.CodeGen.CSharp
{
    public static class CSharpMethodExtensions
    {
        public static CSharpMethod Wrap(this CSharpMethod csMethod)
        {
            var dllImport = csMethod.Attributes.OfType<CSharpDllImportAttribute>().FirstOrDefault();

            // Create a new method
            var clonedMethod = new CSharpMethod
            {
                Name = csMethod.Name, 
                ReturnType = csMethod.ReturnType, 
                Modifiers = csMethod.Modifiers,
                Comment =  csMethod.Comment
            };
            
            // Remove the comment from the private method now
            for (int i = 0; i < csMethod.Parameters.Count; i++)
            {
                var fromParam = csMethod.Parameters[i];
                var clonedParam = fromParam.Clone();
                clonedParam.Parent = clonedMethod;
                clonedMethod.Parameters.Add(clonedParam);
            }

            // If original function has a DllImport, update its EntryPoint
            // as we are going to change its name after
            if (dllImport != null)
            {
                // Remove extern
                clonedMethod.Modifiers ^= CSharpModifiers.Extern;
                dllImport.EntryPoint = $"\"{clonedMethod.Name}\"";
            }

            // Remove the comment from the original method
            csMethod.Comment = null;
            // Rename it to avoid naming clash
            csMethod.Name = csMethod.Name + "__";
            // Make it private
            csMethod.Visibility = CSharpVisibility.Private;

            // Insert the new function right before
            var members = ((ICSharpContainer) csMethod.Parent).Members;
            int index = members.IndexOf(csMethod);
            members.Insert(index, clonedMethod);
            
            
            return clonedMethod;
        }
    }
}