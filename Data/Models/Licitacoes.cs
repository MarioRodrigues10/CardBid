namespace CardBid.Data.Models
{
    public class Licitacoes
    {
        public decimal Valor { get; set; }
        public int Id { get; set; }
        public int Licitante_Id { get; set; }
        public int? Leilao_Id { get; set; }
        public DateTime Data { get; set; }
        public Utilizadores Licitante { get; set; }
        public Leiloes Leilao { get; set; }
    }
}