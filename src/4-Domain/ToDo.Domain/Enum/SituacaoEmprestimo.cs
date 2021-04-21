using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Enum
{
    public enum SituacaoEmprestimo
    {
        [Display(Name = "Ativa")]
        Ativa = 1,
        [Display(Name = "Pendente")]
        Pendente = 2,
        [Display(Name = "Concluída")]
        Concluída = 3,
    }
}
