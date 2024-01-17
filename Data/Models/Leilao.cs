public class Leiloes
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal PrecoInicial { get; set; }
    public int GrauDeDegradacao { get; set; }
    public DateTime DataLimite { get; set; }
    public string Categoria { get; set; }
    public int Vendedor_Id { get; set; }
    public int Maior_Licitacao { get; set; }
    public string Titulo { get; set; }
    public string Estado { get; set; }
}
