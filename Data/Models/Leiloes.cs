using System.Data;

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
        public string Categoria { get; set; }
        public int? MaiorLicitacao { get; set; } = null;
        public string Titulo { get; set; }
        public Leiloes() { }

        public Leiloes(int id, DateTime DataLimite, decimal PrecoInicial, string Estado, 
            int GrauDeDegradacao, string Descricao, int Vendedor_Id, string Categoria, 
            int? MaiorLicitacao, string Titulo)
        {
            Id = id;
            this.DataLimite = DataLimite;
            this.PrecoInicial = PrecoInicial;
            this.Estado = Estado;
            this.GrauDeDegradacao = GrauDeDegradacao;
            this.Descricao = Descricao;
            this.Vendedor_Id = Vendedor_Id;
            this.Categoria = Categoria;
            this.MaiorLicitacao = MaiorLicitacao;
            this.Titulo = Titulo;
        }

        public Leiloes(DateTime DataLimite, decimal PrecoInicial, string Estado, int GrauDeDegradacao, 
            string Descricao, int Vendedor_Id, string Categoria, string Titulo)
        {
            this.DataLimite = DataLimite;
            this.PrecoInicial = PrecoInicial;
            this.Estado = Estado;
            this.GrauDeDegradacao = GrauDeDegradacao;
            this.Descricao = Descricao;
            this.Vendedor_Id = Vendedor_Id;
            this.Categoria = Categoria;
            this.Titulo = Titulo;
        }

    }
}