using AutoMapper;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Models.Dtos.Profiles
{
    public class FactOverviewEntryProfile : Profile
    {
        public FactOverviewEntryProfile()
        {
            CreateMap<Fact, FactOverviewEntry>()
                .ForMember(d => d.FactName, c => c.MapFrom(f => f.Name))
                .ForMember(d => d.FactId, c => c.MapFrom(f => f.Id));
        }
    }
}