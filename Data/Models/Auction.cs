public class Auction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal ListingPrice { get; set; }
    public int DegradationLevel { get; set; }
    public DateTime FinalDate { get; set; }
    public string Collection { get; set; }
    public decimal BidFee { get; set; }
    public decimal TotalPotentialEarnings => ListingPrice - BidFee;
}
