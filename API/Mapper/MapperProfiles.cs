using AutoMapper;
using ProjetPoulinaDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
            {
            CreateMap<Centre, CentreDTO>()
                .ForMember(r => r.DateAu, i => i.MapFrom(src => src.amortissment.DateAu))
                .ForMember(r => r.DateDu, i => i.MapFrom(src => src.amortissment.DateDu))
            .ReverseMap();


            CreateMap<Speculation_centre, Speculation_centreDTO>()
                .ForMember(r => r.Delai_speculation, i => i.MapFrom(src => src.speculation.Delai))
                .ForMember(r => r.Delai_centre, i => i.MapFrom(src => src.centre.Delai))
            .ReverseMap();

            CreateMap<Stock, StockDTO>()
                .ForMember(r => r.fk_centre, i => i.MapFrom(src => src.speculation_centre.fk_centre))
                .ForMember(r => r.fk_speculation, i => i.MapFrom(src => src.speculation_centre.fk_speculation))
            .ReverseMap();

            CreateMap<TraitementStock, TraitementStockDTO>()
                .ForMember(r => r.ValeurDuStock, i => i.MapFrom(src => src.stock.ValeurDuStock))
            .ReverseMap();

            CreateMap<Prix, PrixDTO>()
                 .ForMember(r => r.Delai, i => i.MapFrom(src => src.speculation.Delai))
            .ReverseMap();


        }
    }


}


