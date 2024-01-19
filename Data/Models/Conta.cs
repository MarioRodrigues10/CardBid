namespace CardBid.Data.Models
{
    public class Conta
    {
        public string NomeUtilizador { get; set; }
        public string PalavraPasse { get; set; }
        public int Utilizador_Id { get; set; }

        public Conta() { }

        public Conta(string nomeUtilizador, string palavraPasse, int utilizador_Id)
        {
            NomeUtilizador = nomeUtilizador;
            PalavraPasse = palavraPasse;
            Utilizador_Id = utilizador_Id;
        }

        public Conta(string nomeUtilizador, string palavraPasse)
        {
            NomeUtilizador = nomeUtilizador;
            PalavraPasse = palavraPasse;
        }
    }
}