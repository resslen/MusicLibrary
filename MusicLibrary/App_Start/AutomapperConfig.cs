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
        }
    }
}