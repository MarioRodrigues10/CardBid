namespace CardBid.Data.Models
{
    public class Fotos
    {
        public string Foto { get; set; }
        public int Leilao_Id { get; set; }
        public Leiloes Leilao { get; set; }
    }
}