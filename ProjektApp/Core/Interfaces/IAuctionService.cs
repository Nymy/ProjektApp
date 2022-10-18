namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAuctions();

        Auction GetById(int id);

        void Add(Auction auction);

        void Edit(Auction auction, int id);
    }
}
