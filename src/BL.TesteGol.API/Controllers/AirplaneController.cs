using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BL.TesteGol.API.ViewModels;
using BL.TesteGol.Domain.Core.Bus;
using BL.TesteGol.Domain.Core.Notifications;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Service;

namespace BL.TesteGol.API.Controllers
{
    [Route("airplane/")]
    public class AirplaneController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAirplaneService _airplaneService;

        public AirplaneController(
            IDomainNotificationHandler<DomainNotification> notifications,
            IBus bus,
            IMapper mapper,
            IAirplaneService airplaneService) : base(notifications, bus)
        {
            _mapper = mapper;
            _airplaneService = airplaneService;
        }

        [HttpGet] // Obter Todos
        [Route("todos")]
        public IActionResult Airplane()
        {
            var result = _mapper.Map<IEnumerable<AirplaneViewModel>>(_airplaneService.ObterTodos());

            return Response(result);
        }

        [HttpGet] // Obter por Id
        [Route("{id}")]
        public IActionResult Airplane(Guid id)
        {
            var result = _mapper.Map<AirplaneViewModel>(_airplaneService.ObterPorId(id));

            return Response(result);
        }

        [HttpPost] // Adicionar Grupo de Acesso
        [Route("adicionar")]
        public IActionResult AirplaneAdd([FromBody]AirplaneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }

            _airplaneService.Adicionar(_mapper.Map<AirplaneModel>(model));

            return Response();
        }

        [HttpPut] // Editar Grupo de Acesso
        [Route("editar")]
        public IActionResult AirplaneEdit([FromBody]AirplaneViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }

            _airplaneService.Editar(_mapper.Map<AirplaneModel>(model));

            return Response();
        }

        [HttpDelete] // Remover Grupo de Acesso
        [Route("remover/{id}")]
        public IActionResult AirplaneRemove(Guid id)
        {
            _airplaneService.Remover(id);

            return Response();
        }
    }
}