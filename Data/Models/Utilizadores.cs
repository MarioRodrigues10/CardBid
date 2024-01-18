namespace CardBid.Data.Models
{
    public class Utilizadores
    {
        public int Id { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public int Telefone { get; set; }
        public string Morada { get; set; }
    }
}