// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.
namespace CppAst.CodeGen.CSharp
{
    public interface ICSharpConverterPlugin
    {
        /// <summary>
        /// Register the converter plugin.
        /// </summary>
        /// <param name="converter"></param>
        /// <param name="pipeline"></param>
        void Register(CSharpConverter converter, CSharpConverterPipeline pipeline);
    }
}