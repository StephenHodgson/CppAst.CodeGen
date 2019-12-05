using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CppAst.CodeGen.CSharp
{
    class CSharpContainerListDebugView<T>
    {
        private readonly ICollection<T> _collection;

        public CSharpContainerListDebugView(ICollection<T> collection)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                T[] array = new T[_collection.Count];
                _collection.CopyTo(array, 0);
                return array;
            }
        }
    }
}