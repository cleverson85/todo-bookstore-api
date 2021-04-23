using System;

namespace ToDo.Application.ViewModels
{
    public class EmprestimoViewModel : BaseViewModel
    {
        public int Cliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int Situacao { get; set; }
        public int[] LivrosEmprestimo { get; set; }
    }
}
