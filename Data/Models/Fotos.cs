namespace CardBid.Data.Models
{
    public class Fotos
    {
        public string Foto { get; set; }
        public int LeilaoId { get; set; }

        public Fotos() { }
        public Fotos(string foto, int leilaoid)
        {
            Foto = foto;
            LeilaoId = leilaoid;
        }
    }
}