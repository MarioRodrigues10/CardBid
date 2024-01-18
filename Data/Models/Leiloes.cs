namespace CardBid.Data.Models
{
    public class Leiloes
    {
        public int Id { get; set; }
        public DateTime DataLimite { get; set; }
        public decimal PrecoInicial { get; set; }
        public string Estado { get; set; }
        public int GrauDeDegradacao { get; set; }
        public string Descricao { get; set; }
        public int Vendedor_Id { get; set; }
        public Utilizadores Vendedor { get; set; }
        public string Categoria { get; set; }
        public int? MaiorLicitacao { get; set; }
        public string Titulo { get; set; }
    }
}