using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using BL.TesteGol.Domain.Core.Bus;
using BL.TesteGol.Domain.Core.Interfaces;
using BL.TesteGol.Domain.Core.Notifications;
using BL.TesteGol.Domain.Airplane.Airplane.Services;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Service;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Repository;
using BL.TesteGol.Infra.Data.Airplane.Context;
using BL.TesteGol.Infra.Data.Airplane.Repository;
using BL.TesteGol.Infra.Data.Airplane.UoW;
using BL.TesteGol.Infra.CrossCutting.Bus;

namespace BL.TesteGol.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);

            #region Domains

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #region Domain Airplane

            services.AddScoped<IAirplaneService, AirplaneService>();

            #endregion

            #endregion

            #region Infra

            //Gerencial Data
            services.AddScoped<AirplaneContext>();
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region CrossCutting
            //Bus
            services.AddScoped<IBus, InMemoryBus>();

            #endregion
        }
    }
}