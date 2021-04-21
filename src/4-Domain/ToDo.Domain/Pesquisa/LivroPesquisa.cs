namespace ToDo.Domain.Pesquisa
{
    public class LivroPesquisa
    {
        public string description { get; set; }
        public int generoId { get; set; } = 0;

        public LivroPesquisa(string description, int generoId)
        {
            this.description = description;
            this.generoId = generoId;
        }
    }
}
