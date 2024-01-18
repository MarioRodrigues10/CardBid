namespace CardBid.Data.Models
{
    public class Licitacoes
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int Licitante_Id { get; set; }
        public int Leilao_Id { get; set; }
        public DateTime Data { get; set; }

        public Licitacoes() { }
        
        public Licitacoes(int id, decimal valor, int licitante_Id, int leilao_Id, DateTime data)
        {
            Valor = valor;
            Id = id;
            Licitante_Id = licitante_Id;
            Leilao_Id = leilao_Id;
            Data = data;
        }

        public Licitacoes(decimal valor, int licitante_Id, int leilao_Id, DateTime data)
        {
            Valor = valor;
            Licitante_Id = licitante_Id;
            Leilao_Id = leilao_Id;
            Data = data;
        }
    }
}