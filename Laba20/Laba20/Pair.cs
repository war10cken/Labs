using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba20
{
    internal sealed class Pair<TKey, TEntity>
    {
        public Pair(TKey key, TEntity entity)
        {
            Key = key;
            Entity = entity;
        }

        public TKey Key { get; }
        public TEntity Entity { get; private set; }
    }
}