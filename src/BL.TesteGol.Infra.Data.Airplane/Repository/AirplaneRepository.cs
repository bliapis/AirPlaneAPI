using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BL.TesteGol.Domain.Airplane.Airplane.Entities;
using BL.TesteGol.Domain.Airplane.Airplane.Interfaces.Repository;
using BL.TesteGol.Infra.Data.Airplane.Context;

namespace BL.TesteGol.Infra.Data.Airplane.Repository
{
    public class AirplaneRepository : Repository<AirplaneModel>, IAirplaneRepository
    {
        public AirplaneRepository(AirplaneContext context) : base(context)
        {
        }
    }
}