namespace CardBid.Data.Models
{
    public class Leiloes
    {
        public int Id { get; set; }
        public DateTime DataLimite { get; set; }
        public decimal PrecoInicial { get; set; }
        public decimal  BidFee { get; set; }
        public string Estado { get; set; }
        public int GrauDeDegradacao { get; set; }
        public string Descricao { get; set; }
        public int VendedorId { get; set; }
        public string Categoria { get; set; }
        public int? MaiorLicitacao { get; set; } = null;
        public string Titulo { get; set; }
        public Leiloes() { }

        public Leiloes(int id, DateTime DataLimite, decimal PrecoInicial, decimal BidFee, string Estado,
            int GrauDeDegradacao, string Descricao, int VendedorId, string Categoria,
            int? MaiorLicitacao, string Titulo)
        {
            Id = id;
            this.DataLimite = DataLimite;
            this.PrecoInicial = PrecoInicial;
            this.BidFee = BidFee;
            this.Estado = Estado;
            this.GrauDeDegradacao = GrauDeDegradacao;
            this.Descricao = Descricao;
            this.VendedorId = VendedorId;
            this.Categoria = Categoria;
            this.MaiorLicitacao = MaiorLicitacao;
            this.Titulo = Titulo;
        }

        public Leiloes(DateTime DataLimite, decimal PrecoInicial, decimal BidFee, string Estado, int GrauDeDegradacao,
            string Descricao, int VendedorId, string Categoria, string Titulo)
        {
            this.DataLimite = DataLimite;
            this.PrecoInicial = PrecoInicial;
            this.BidFee = BidFee;
            this.Estado = Estado;
            this.GrauDeDegradacao = GrauDeDegradacao;
            this.Descricao = Descricao;
            this.VendedorId = VendedorId;
            this.Categoria = Categoria;
            this.Titulo = Titulo;
        }

    }
}