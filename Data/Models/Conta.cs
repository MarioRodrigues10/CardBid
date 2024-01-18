namespace CardBid.Data.Models
{
    public class Conta
    {
        public string NomeUtilizador { get; set; }
        public string PalavraPasse { get; set; }
        public int Utilizador_Id { get; set; }
        public Utilizadores Utilizador { get; set; }
    }
}