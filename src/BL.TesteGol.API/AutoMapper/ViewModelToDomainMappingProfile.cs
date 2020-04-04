using AutoMapper;
using BL.TesteGol.API.ViewModels;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;

namespace BL.TesteGol.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Grupo Acesso
            CreateMap<AirplaneViewModel, AirplaneModel>();
            #endregion
        }
    }
}