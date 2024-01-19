namespace CardBid.Data.Models
{
    public class Categorias
    {
        public string categoria { get; set; }

        public Categorias() { }

        public Categorias(string nome)
        {
            categoria = nome;
        }
    }
}