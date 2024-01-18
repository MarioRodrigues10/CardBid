namespace CardBid.Data.Models
{
    public class Faturas
    {
        public int Id { get; set; }
        public string Fatura { get; set; }
        public int Comprador_Id { get; set; }
        public int Leilao_Id { get; set; }

        public Faturas() { }

        public Faturas(int id, string fatura, int comprador_id, int leilao_id)
        {
            Id = id;
            Fatura = fatura;
            Comprador_Id = comprador_id;
            Leilao_Id = leilao_id;
        }

        public Faturas(string fatura, int comprador_id, int leilao_id)
        {
            Fatura = fatura;
            Comprador_Id = comprador_id;
            Leilao_Id = leilao_id;
        }
    }
}