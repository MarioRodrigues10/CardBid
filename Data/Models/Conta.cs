namespace CardBid.Data.Models
{
    public class Conta
    {
        public string NomeUtilizador { get; set; }
        public string PalavraPasse { get; set; }
        public int Utilizador_Id { get; set; }

        public Conta() { }

        public Conta(string nomeUtilizador, string PalavaPasse, int Utilizador_Id)
        {
            NomeUtilizador = nomeUtilizador;
            PalavraPasse = PalavraPasse;
            Utilizador_Id = Utilizador_Id;
        }
    }
}