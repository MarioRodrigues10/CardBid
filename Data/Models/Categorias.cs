namespace CardBid.Data.Models
{
    public class Categorias
    {
        public string Nome { get; set; }

        public Categorias() { }

        public Categorias(string nome)
        {
            Nome = nome;
        }
    }
}