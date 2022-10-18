﻿namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAuctions();

        Auction GetById(int id);
    }
}
