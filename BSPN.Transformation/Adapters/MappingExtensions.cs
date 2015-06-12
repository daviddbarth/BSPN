using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BSPN.Transformation
{
    public static class MappingExtensions
    {
        public static void ExcludeProperty<SourceType, DestinationType>(this IMappingEngine mapper, string propertyName)
        {
            //var nflTeamTypeMap = _mapper.ConfigurationProvider.CreateTypeMap(typeof(NFLTeam), typeof(INFLTeamDTO));
            var typeMap = mapper.ConfigurationProvider.FindTypeMapFor(typeof (SourceType), typeof (DestinationType));
            var propertyMaps = typeMap.GetPropertyMaps().First(pm => pm.SourceMember.Name == propertyName);
            propertyMaps.Ignore();
            //var propertyMaps = nflTeamTypeMap.GetPropertyMaps();

            //propertyMaps.First(x => x.SourceMember.Name == "NFLGames").Ignore();
        }
    }
}
