// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Collections.Generic;
using System.IO;
using Zio;

namespace CppAst.CodeGen.CSharp
{
    public class DefaultContainerResolver : ICSharpConverterPlugin
    {
        private static readonly string CacheContainerKey = $"{typeof(DefaultContainerResolver)}.{nameof(CacheContainerKey)}";

        public void Register(CSharpConverter converter, CSharpConverterPipeline pipeline)
        {
            pipeline.GetCSharpContainerResolvers.Add(GetSharpContainer);
        }

        public static ICSharpContainer GetSharpContainer(CSharpConverter converter, CppElement element, CSharpElement context)
        {
            var cacheContainer = converter.GetTagValueOrDefault<CacheContainer>(CacheContainerKey);

            if (cacheContainer == null)
            {
                cacheContainer = new CacheContainer { DefaultClass = CreateClassLib(converter) };
                converter.Tags[CacheContainerKey] = cacheContainer;
            }

            if (converter.Options.DispatchOutputPerInclude &&
                !converter.IsFromSystemIncludes(element))
            {
                var fileName = Path.GetFileNameWithoutExtension(element.Span.Start.File);

                if (fileName != null)
                {
                    if (cacheContainer.IncludeToClass.TryGetValue(fileName, out var csClassLib))
                    {
                        return csClassLib;
                    }

                    csClassLib = CreateClassLib(converter, UPath.Combine(UPath.Root, $"{CSharpHelper.ToPascal(fileName)}.generated.cs"), fileName);
                    cacheContainer.IncludeToClass.Add(fileName, csClassLib);
                    return csClassLib;
                }
            }

            return cacheContainer.DefaultClass;
        }

        private static CSharpClass CreateClassLib(CSharpConverter converter, UPath? subFilePathOverride = null, string nameOverride = "")
        {
            var path = converter.Options.DefaultOutputFilePath;
            var compilation = converter.CurrentCSharpCompilation;

            if (subFilePathOverride != null)
            {
                path = UPath.Combine(converter.Options.DefaultOutputFilePath.GetDirectory(), subFilePathOverride.Value);
            }

            var csFile = new CSharpGeneratedFile(path);
            compilation.Members.Add(csFile);

            var csNamespace = new CSharpNamespace(converter.Options.DefaultNamespace);
            csFile.Members.Add(csNamespace);

            var csClassName = string.IsNullOrWhiteSpace(nameOverride)
                ? converter.Options.DefaultClassLib
                : CSharpHelper.ToPascal(nameOverride);
            var csClassLib = new CSharpClass(csClassName);
            csClassLib.Modifiers |= CSharpModifiers.Partial | CSharpModifiers.Static;
            converter.ApplyDefaultVisibility(csClassLib, csNamespace);

            csNamespace.Members.Add(csClassLib);
            return csClassLib;
        }

        private class CacheContainer
        {
            public CacheContainer()
            {
                IncludeToClass = new Dictionary<string, CSharpClass>();
            }

            public CSharpClass DefaultClass { get; set; }

            public Dictionary<string, CSharpClass> IncludeToClass { get; }
        }
    }
}