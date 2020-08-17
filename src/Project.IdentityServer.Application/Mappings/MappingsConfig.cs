using AutoMapper;

namespace Project.identityserver.Application.Mappings
{
    public class MappingsConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMappingProfile());
                config.AddProfile(new ViewModelToCommandMappingProfile());
                config.AddProfile(new CommandToDomainMappingProfile());
                config.AddProfile(new DomainToModelServiceMappingProfile());
            });
        }
    }
}