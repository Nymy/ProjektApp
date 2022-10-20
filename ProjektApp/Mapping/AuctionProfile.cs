using AutoMapper;
using ProjektApp.Core;
using ProjektApp.Persistence;

namespace ProjektApp.Mapping
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionDb, Auction>()
                .ReverseMap();
        }
    }
}