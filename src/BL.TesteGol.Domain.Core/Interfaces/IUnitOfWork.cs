using System;

namespace BL.TesteGol.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}