using System;

namespace Security.Domain.Abstraction
{
    public interface IClock
    {
        DateTime Current();
    }
}
