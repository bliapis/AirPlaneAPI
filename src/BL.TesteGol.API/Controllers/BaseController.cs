﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BL.TesteGol.Domain.Core.Bus;
using BL.TesteGol.Domain.Core.Notifications;

namespace BL.TesteGol.API.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IBus _bus;

        protected BaseController(
            IDomainNotificationHandler<DomainNotification> notifications,
            IBus bus)
        {
            _notifications = notifications;
            _bus = bus;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(
                    new
                    {
                        success = true,
                        data = result
                    });
            }

            //Todas notificações com key "-1", não podem ser apresentadas ao usuário, apenas logadas.
            return Ok(new
            {
                success = false,
                errors = _notifications.GetNotifications().Where(n => n.Key != "-1").Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }


        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);

            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _bus.RaiseEvent(new DomainNotification(codigo, mensagem));
        }
    }
}