// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Linq;

namespace CppAst.CodeGen.CSharp
{
    public class DefaultEnumConverter : ICSharpConverterPlugin
    {
        public void Register(CSharpConverter converter, CSharpConverterPipeline pipeline)
        {
            pipeline.EnumConverters.Add(ConvertEnum);
        }

        public static CSharpElement ConvertEnum(CSharpConverter converter, CppEnum cppEnum, CSharpElement context)
        {
            if (!converter.Options.GenerateEnumItemAsFields && cppEnum.IsAnonymous && cppEnum.Items.Count == 1)
            {
                return GenerateConstEnumField(converter, cppEnum, context);
            }

            var csEnum = new CSharpEnum(converter.GetCSharpName(cppEnum, context))
            {
                CppElement = cppEnum
            };

            var container = converter.GetCSharpContainer(cppEnum, context);
            container.Members.Add(csEnum);
            converter.ApplyDefaultVisibility(csEnum, container);

            csEnum.Comment = converter.GetCSharpComment(cppEnum, csEnum);
            csEnum.BaseTypes.Add(converter.GetCSharpType(cppEnum.IntegerType, csEnum));

            return csEnum;
        }

        private static CSharpElement GenerateConstEnumField(CSharpConverter converter, CppEnum cppEnum, CSharpElement context)
        {
            var csEnumField = new CSharpField(converter.GetCSharpName(cppEnum, context))
            {
                CppElement = cppEnum,
            };

            csEnumField.Modifiers |= CSharpModifiers.Const;

            var container = converter.GetCSharpContainer(cppEnum, context);
            container.Members.Add(csEnumField);
            converter.ApplyDefaultVisibility(csEnumField, container);

            csEnumField.Comment = converter.GetCSharpComment(cppEnum, csEnumField);
            csEnumField.FieldType = converter.GetCSharpType(cppEnum.IntegerType, csEnumField);
            csEnumField.InitValue = $"unchecked(({csEnumField.FieldType}){converter.ConvertExpression(cppEnum.Items.FirstOrDefault().ValueExpression)})";

            return csEnumField;
        }
    }
}