﻿using System;

namespace BL.TesteGol.Domain.Core
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}