using AutoMapper;
using ProjektApp.Core;
using ProjektApp.Persistence;

namespace ProjektApp.Mapping
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<BidDb, Bid>()
                .ReverseMap();  
        }
    }
}
