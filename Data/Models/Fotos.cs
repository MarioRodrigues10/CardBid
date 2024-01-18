namespace CardBid.Data.Models
{
    public class Fotos
    {
        public string Foto { get; set; }
        public int Leilao_Id { get; set; }

        public Fotos() { }
        public Fotos(string foto, int leilao_id)
        {
            Foto = foto;
            Leilao_Id = leilao_id;
        }
    }
}