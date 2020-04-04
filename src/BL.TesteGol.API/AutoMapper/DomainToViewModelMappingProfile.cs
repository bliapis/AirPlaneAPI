using AutoMapper;
using BL.TesteGol.API.ViewModels;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;

namespace BL.TesteGol.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Grupo Acesso
            CreateMap<AirplaneModel, AirplaneViewModel>();
            #endregion
        }
    }
}