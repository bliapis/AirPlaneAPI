using BL.TesteGol.Domain.Core.Events;

namespace BL.TesteGol.Domain.Core.Bus
{
    public interface IBus
    {
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}