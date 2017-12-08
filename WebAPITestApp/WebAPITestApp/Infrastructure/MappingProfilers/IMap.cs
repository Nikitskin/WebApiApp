using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITestApp.Web.Infrastructure.MappingProfilers
{
    public interface IMap
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
