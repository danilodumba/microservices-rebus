using System;

namespace MicroservicesRebus.Core
{
    public abstract class Message
    {
        protected Message()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime Date {get; private set;}
    }
}
