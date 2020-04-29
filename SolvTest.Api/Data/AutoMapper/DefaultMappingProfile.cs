using System;
using AutoMapper;
using SolvTest.Api.Data;


namespace SolvTest.Api.Data.AutoMapper
{
    public class DefaultMappingProfile :Profile
    {
        public DefaultMappingProfile()
        {
            //didnt have much time to bang this out, so i just did a simple one, on purpose, as a demo
            //of my working knowlege of AutoMapper
            CreateMap<Entities.MovieEntity, Models.MovieModel>()
                .ForMember(
                //project simple image string url to actual Uri type
                entity=> entity.ImageUrl,
                model=> model.MapFrom(src=>new Uri(src.ArtUrl))
            );

            CreateMap<Entities.ShowTimeEntity, Models.ShowTimeModel>();
        }
    }
}
