namespace WebAPITestApp.Web.Infrastructure.MappingProfilers
{
    public class Mapper : IMap
    {
        TDestination IMap.Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource,TDestination>(source);
        }
    }
}
