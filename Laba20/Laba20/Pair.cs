using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba20
{
    internal sealed class Pair<TEntityType>
    {
        public Pair(int index, TEntityType entity)
        {
            Index = index;
            Entity = entity;
        }

        public int Index { get; }
        public TEntityType Entity { get; }
    }
}