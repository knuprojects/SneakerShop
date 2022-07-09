using Security.Domain.Abstraction;
using System;

namespace Security.Infrastructure.Time
{
    public class Clock : IClock
    {
        public DateTime Current()
        {
            return DateTime.Now;
        }
    }
}
