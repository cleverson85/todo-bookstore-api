namespace ToDo.Domain.Pesquisa
{
    public class PaginacaoParametroDto
    {
        public int Pagina { get; set; } = 1;
        public int ItensPorPagina { get; set; } = 10;
    }
}
