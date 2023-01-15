using AutoMapper;
using DTOs;
using EntityFramework;
using EntityFramework.Entity;
using Model;
using System.Collections.ObjectModel;

namespace APIRest.MapperClass
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<JoueurEntity, JoueurDto>().ReverseMap();
            CreateMap<PartieEntity, PartieDto>().ReverseMap();
            CreateMap<MancheEntity, MancheDto>().ReverseMap();
            CreateMap<JoueurDto, Joueur>().ReverseMap();

        }
    }
}
