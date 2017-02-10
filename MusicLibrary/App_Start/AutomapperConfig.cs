using AutoMapper;
using MusicLibrary.DAL;
using MusicLibrary.Models;

namespace MusicLibrary.App_Start
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(Register);
        }

        private static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Artist, ArtistListViewModel>();
            config.CreateMap<Artist, ArtistViewModel>();
            config.CreateMap<NewArtistViewModel, Artist>();
            config.CreateMap<Album, AlbumListViewModel>()
                .ForMember(x => x.Author, conf => conf.MapFrom(album => album.Author.Name));
            config.CreateMap<Album, AlbumViewModel>()
                .ForMember(x => x.Author, conf => conf.MapFrom(album => album.Author.Name));
            config.CreateMap<NewAlbumViewModel, Album>();
        }
    }
}