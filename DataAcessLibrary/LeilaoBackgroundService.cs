using CardBid.Data;
using CardBid.Data.Models;

public class LeiloesBackgroundService : BackgroundService
{
    private readonly IServiceProvider _provider;

    public LeiloesBackgroundService(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CheckAuctionStatus();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Adjust the interval as needed
        }
    }

    private async Task CheckAuctionStatus()
    {
        using (var scope = _provider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<CardBidDbContext>();
            try
            {
                dbContext.Leiloes.Where(a => a.DataLimite <= DateTime.Now && a.Estado == "Aceite").ToList().ForEach(a =>
                {
                    if (a.MaiorLicitacao != null)
                    {
                        Licitacoes licitacao = dbContext.Licitacoes.Where(l => l.Id == a.MaiorLicitacao).First();

                        Faturas faturas = new Faturas
                        {
                            CompradorId = licitacao.LicitanteId,
                            LeilaoId = a.Id,
                            Fatura = $"Auction Nº{a.Id}: {a.Titulo}\n Bid Nº{licitacao.Id}\n Value = {licitacao.Valor}"
                        };

                        dbContext.Faturas.Add(faturas);
                    }

                    a.Estado = "Finalizado";
                });
                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CheckAuctionStatus: {ex.Message}");
            }
        }
    }
}
