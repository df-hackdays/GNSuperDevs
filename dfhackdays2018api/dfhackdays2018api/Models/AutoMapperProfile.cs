using System;
using AutoMapper;
using dfhackdays2018.Models;

namespace dfhackdays2018api.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMaps();
        }

        protected void CreateMaps()
        {
            CreateMap<StudentViewModel, Student>()
                .ForMember(s => s.StudentId, opt => opt.Ignore())
                .ForMember(s => s.Profession, opt => opt.Ignore())
                .ForMember(s => s.Aspirations, opt => opt.Ignore());
        }
    }
}
