﻿namespace BL.TesteGol.Domain.Core.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}