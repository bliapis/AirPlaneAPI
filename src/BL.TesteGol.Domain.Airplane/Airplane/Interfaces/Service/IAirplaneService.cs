using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using System;
using System.Collections.Generic;

namespace BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Service
{
    public interface IAirplaneService : IDisposable
    {
        AirplaneModel ObterPorId(Guid usuarioId);
        IEnumerable<AirplaneModel> ObterTodos();

        void Adicionar(AirplaneModel airplane);
        void Editar(AirplaneModel usuario);
        void Remover(Guid usuarioId);
    }
}