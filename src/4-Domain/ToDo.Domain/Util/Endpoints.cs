namespace ToDo.Domain.Util
{
    public static class Endpoints
    {
        public static class Route
        {
            public const string POST = "";
            public const string PUT = "";
            public const string ALL = "";
            public const string DELETE = "{id}";

            public const string ID = "{id}";
            public const string DESCRIPTION = "description/{description}";

            //Instituicao
            public const string CNPJ = "cnpj/{cnpj}";

            //Clientes
            public const string NAME = "name/{name}";
            public const string CPF = "cpf/{cpf}";
            public const string EMAIL = "email/{email}";

            //Livros
            public const string AUTOR = "autor/{autor}";
            public const string TITULO = "titulo/{titulo}";
            public const string GENEROS = "generos";
            public const string GENERO_ID = "genero/{id}";
            public const string GENERO_ID_DESCRIPTION = "genero/{id}/{description}";
        }

        public static class Recursos
        {
            public const string Cliente = "api/cliente";
            public const string Livro = "api/livro";
            public const string Instituicao = "api/instituicao";
            public const string Emprestimo = "api/emprestimo";
        }
    }
}
