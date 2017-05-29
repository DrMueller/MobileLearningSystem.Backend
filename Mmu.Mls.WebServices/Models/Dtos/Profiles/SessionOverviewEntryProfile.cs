using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Models.Dtos.Profiles
{
    public class SessionOverviewEntryProfile : Profile
    {
        public SessionOverviewEntryProfile()
        {
            CreateMap<Session, SessionOverviewEntry>()
                .ForMember(d => d.SessionFactsCount, c => c.MapFrom(f => f.SessionFacts.Count))
                .ForMember(d => d.SessionId, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.Name))
                .ForMember(d => d.SessionRunsCount, c => c.MapFrom(f => f.SessionRuns.Count));
        }
    }
}
