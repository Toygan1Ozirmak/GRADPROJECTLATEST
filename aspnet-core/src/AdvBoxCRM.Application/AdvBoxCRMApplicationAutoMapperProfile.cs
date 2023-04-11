using AdvBoxCRM.Boxes;
using AutoMapper;

namespace AdvBoxCRM;

public class AdvBoxCRMApplicationAutoMapperProfile : Profile
{
    public AdvBoxCRMApplicationAutoMapperProfile()
    {

        CreateMap<Box,BoxDto>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
