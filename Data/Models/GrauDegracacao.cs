namespace CardBid.Data.Models
{
    public class GrauDegradacao
    {
        public int grauDegradacao { get; set; }
        public string Designacao { get; set; }

        public GrauDegradacao() { }
        public GrauDegradacao(int grauDegradacao, string designacao)
        {
            this.grauDegradacao = grauDegradacao;
            Designacao = designacao;
        }
    }
}