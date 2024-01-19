namespace CardBid.Data.Models
{
    public class Faturas
    {
        public int Id { get; set; }
        public string Fatura { get; set; }
        public int CompradorId { get; set; }
        public int LeilaoId { get; set; }

        public Faturas() { }

        public Faturas(int id, string fatura, int compradorid, int leilaoid)
        {
            Id = id;
            Fatura = fatura;
            CompradorId = compradorid;
            LeilaoId = leilaoid;
        }

        public Faturas(string fatura, int compradorid, int leilaoid)
        {
            Fatura = fatura;
            CompradorId = compradorid;
            LeilaoId = leilaoid;
        }
    }
}