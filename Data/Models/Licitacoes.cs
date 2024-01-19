namespace CardBid.Data.Models
{
    public class Licitacoes
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int LicitanteId { get; set; }
        public int LeilaoId { get; set; }
        public DateTime Data { get; set; }

        public Licitacoes() { }

        public Licitacoes(int id, decimal valor, int licitanteId, int leilaoId, DateTime data)
        {
            Valor = valor;
            Id = id;
            LicitanteId = licitanteId;
            LeilaoId = leilaoId;
            Data = data;
        }

        public Licitacoes(decimal valor, int licitanteId, int leilaoId, DateTime data)
        {
            Valor = valor;
            LicitanteId = licitanteId;
            LeilaoId = leilaoId;
            Data = data;
        }
    }
}