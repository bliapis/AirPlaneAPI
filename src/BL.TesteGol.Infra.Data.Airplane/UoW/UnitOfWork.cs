using BL.TesteGol.Domain.Core;
using BL.TesteGol.Domain.Core.Interfaces;
using BL.TesteGol.Infra.Data.Airplane.Context;

namespace BL.TesteGol.Infra.Data.Airplane.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirplaneContext _context;

        public UnitOfWork(AirplaneContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}