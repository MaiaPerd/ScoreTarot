using APIRest.DTOs;
using AutoMapper;
using EntityFramework;
using EntityFramework.Entity;
using Model;
using System.Collections.ObjectModel;

namespace APIRest.MapperClass
{
    public class MapperApiREST : Profile
    {
        public MapperApiREST()
        {//list joueur avec id
            CreateMap<JoueurEntity, JoueurDto>().ReverseMap();
            CreateMap<PartieEntity, PartieDto>()
                .ForMember(parten => parten.ManchesId, act => act.MapFrom(source => source.Manches.Select(m => m.Id).ToArray()))
                .ForMember(parten => parten.JoueursId, act => act.MapFrom(source => source.Joueurs.Select(j => j.Id).ToArray()))
                .ReverseMap()
                //.ForMember( pdto => pdto.Manches.Select(m=>m.Id), act => act.MapFrom(source => source.ManchesId.ToArray()))
                //.ForMember( pdto => pdto.Joueurs.Select(j=>j.Id), act => act.MapFrom(source => source.JoueursId.ToArray()))
                ;
            CreateMap<MancheEntity, MancheDto>()
                .ForMember(mancheEn => mancheEn.JoueurAllierId, act => act.MapFrom(source => source.JoueurAllier.Id))
                .ForMember(mancheEn => mancheEn.JoueurQuiPrendId, act => act.MapFrom(source => source.JoueurQuiPrend.Id))
                .ReverseMap()
                //.ForMember(mancheEn => mancheEn.JoueurAllier.Id, act => act.MapFrom(source => source.JoueurAllierId))
                //.ForMember(mancheEn => mancheEn.JoueurQuiPrend.Id, act => act.MapFrom(source => source.JoueurQuiPrendId))
                ;

            CreateMap<JoueurDto, Joueur>().ReverseMap();
            CreateMap<Manche, MancheDto>().ReverseMap();

        }
    }
}
