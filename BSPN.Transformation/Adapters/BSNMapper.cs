using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace BSPN.Transformation
{
    public interface IBSNMapper
    {
        void CreateMap<TSource, TDest>();
        TDest Map<TDest>(object sourceObj);
        void ExcludeProperty<TSource, TDest>(string propertyName);
    }

    public class BSNMapper : IBSNMapper
    {
        public BSNMapper()
        {

        }

        public void CreateMap<TSource, TDest>()
        {
            Mapper.CreateMap<TSource, TDest>();
        }
        
        public TDest Map<TDest>(object sourceObj)
        {
            return Mapper.Map<TDest>(sourceObj);
        }
        
        public void ExcludeProperty<TSource, TDest>(string propertyName)
        {
            var typeMap = Mapper.FindTypeMapFor<TSource, TDest>();
            typeMap.GetPropertyMaps().First(t => t.SourceMember.Name == propertyName).Ignore();
        }
    }
}
