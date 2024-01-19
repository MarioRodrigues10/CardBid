namespace CardBid.Data.Models
{
    public class Utilizadores
    {
        public int Id { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public char Genero { get; set; }
        public string Telefone { get; set; }
        public string Morada { get; set; }
        public Utilizadores() { }

        public Utilizadores(int id, string nif, string email, string nome, DateTime dataDeNascimento, char genero, string telefone, string morada)
        {
            Id = id;
            NIF = nif;
            Email = email;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Genero = genero;
            Telefone = telefone;
            Morada = morada;
        }


        public Utilizadores(string nif, string email, string nome, DateTime dataDeNascimento, char genero, string telefone, string morada)
        {
            NIF = nif;
            Email = email;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Genero = genero;
            Telefone = telefone;
            Morada = morada;
        }
    }
}