using System;
using System.Collections.Generic;
using BL.TesteGol.Domain.Core.Bus;
using BL.TesteGol.Domain.Core.Interfaces;
using BL.TesteGol.Domain.Core.Notifications;
using BL.TesteGol.Domain.Airplane.Shared.Service;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Service;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Repository;

namespace BL.TesteGol.Domain.Airplane.Airplane.Services
{
    public class AirplaneService : ServiceBase, IAirplaneService
    {
        private readonly IBus _bus;
        private readonly IAirplaneRepository _airplaneRepo;

        public AirplaneService(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IAirplaneRepository airplaneRepo) : base(uow, bus, notifications)
        {
            _bus = bus;
            _airplaneRepo = airplaneRepo;
        }

        public AirplaneModel ObterPorId(Guid airplaneId)
        {
            return _airplaneRepo.GetById(airplaneId);
        }

        public IEnumerable<AirplaneModel> ObterTodos()
        {
            var airplaneLst = _airplaneRepo.GetAll();
            return airplaneLst;
        }

        public void Adicionar(AirplaneModel airplaneModel)
        {
            var airplane = new AirplaneModel(airplaneModel.Modelo, airplaneModel.QtdPassageiros);

            if (!ValidarAirPlane(airplane)) return;

            _airplaneRepo.Add(airplane);

            Commit();
        }

        public void Editar(AirplaneModel airplaneModel)
        {
            if (!ValidarAirPlane(airplaneModel)) return;

            var atual = _airplaneRepo.GetById(airplaneModel.Id);

            airplaneModel.DataCriacao = atual.DataCriacao; //Todo: Alterar essa forma de fazer

            _airplaneRepo.Update(airplaneModel);

            Commit();
        }

        public void Remover(Guid airplaneId)
        {
            if (!ChecarAirPlaneExistente(airplaneId, "2")) return;

            _airplaneRepo.Remove(airplaneId);
            Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Validadores de serviço
        private bool ValidarAirPlane(AirplaneModel airplaneModel)
        {
            if (airplaneModel.IsValid()) return true;

            NotifyErrorValidation(airplaneModel.ValidationResult);

            return false;
        }

        private bool ChecarAirPlaneExistente(Guid airplaneId, string messageType)
        {
            var airplane = _airplaneRepo.GetById(airplaneId);

            if (airplane != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Registro não encontrado."));
            return false;
        }
        #endregion
    }
}