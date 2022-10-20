namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAuctions();
        List<Auction> GetMyBids(string username);
        List<Auction> GetMyWinningBids(string userName);
        
        Auction GetById(int id);

        void Add(Auction auction);

        void Edit(Auction auction, int id);

        void AddBid(Bid bid, Auction auction);
    }
}
