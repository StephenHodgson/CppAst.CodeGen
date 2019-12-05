// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CppAst.CodeGen.CSharp
{
    internal sealed class CppElementReferenceEqualityComparer : IEqualityComparer<CppElement>
    {
        public static readonly CppElementReferenceEqualityComparer Default = new CppElementReferenceEqualityComparer();

        /// <inheritdoc />
        public bool Equals(CppElement x, CppElement y) => ReferenceEquals(x, y);

        /// <inheritdoc />
        public int GetHashCode(CppElement obj) => RuntimeHelpers.GetHashCode(obj);
    }
}