using AutoMapper;

namespace BSPN.Transformation
{
    public interface IBSNMappingEngine : IMappingEngine
    {
    }

    public class BSNMappingEngine : MappingEngine, IBSNMappingEngine
    {
        public BSNMappingEngine(IConfigurationProvider configurationProvider)
            :base(configurationProvider)
        {
            
        }
    }
}
