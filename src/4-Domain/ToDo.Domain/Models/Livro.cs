using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Domain.Models
{
    public class Livro : BaseEntity
    {
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public string Autor { get; set; }
        public string Sinopse { get; set; }
        public byte[] ImagemCapa { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
