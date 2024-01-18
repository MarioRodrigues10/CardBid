namespace CardBid.Data.Models
{
    public class Faturas
    {
        public string Fatura { get; set; }
        public int Id { get; set; }
        public int Comprador_Id { get; set; }
        public int Leilao_Id { get; set; }
        public Utilizadores Comprador { get; set; }
        public Leiloes Leilao { get; set; }
    }
}