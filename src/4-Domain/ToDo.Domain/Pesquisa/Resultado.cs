using System.Collections.Generic;

namespace ToDo.Domain.Pesquisa
{
    public class Resultado<Entity>
    {
        public IEnumerable<Entity> Items { get; set; }
        public int Count { get; set; }

        public Resultado(IEnumerable<Entity> items, int count)
        {
            Items = items;
            Count = count;
        }
    }
}
