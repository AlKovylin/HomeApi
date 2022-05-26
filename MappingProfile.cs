using AutoMapper;
using HomeApi.Configurations;
using HomeApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi
{
    /// <summary>
    /// Настройки маппинга всех сущностей приложения
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
