using System;
using System.Collections.Generic;

namespace ToDo.Domain.Pesquisa
{
    public class Resultado<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Count { get; set; }

        public Resultado(IEnumerable<T> items, int count)
        {
            Items = items;
            Count = count;
        }
    }
}
