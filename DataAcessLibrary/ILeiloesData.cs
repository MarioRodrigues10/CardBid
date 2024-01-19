﻿using CardBid.Data.Models;

namespace CardBid.DataAcessLibrary
{
    public interface ILeiloesData
    {
        public List<Leiloes> ListAll();

        public Task<Leiloes> AddLeilao(Leiloes leilao);
    }
}
