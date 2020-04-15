using AutoMapper;
using Brackets.Data;

namespace Brackets.ViewModels
{
    public class CheckResultViewModelProfile : Profile
    {
        public CheckResultViewModelProfile()
        {
            CreateMap<LogDto, CheckResultViewModel>()
                .ForMember(x => x.Time, opt => opt.MapFrom(src => src.Time.ToShortDateString()))
                .ForMember(x => x.Id, c => c.MapFrom(m => m.LogID));
        }
    }
}
