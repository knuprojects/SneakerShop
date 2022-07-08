using System;

namespace Security.Domain.Entities
{
    public class AccessToken
    {
        public string Value { get; set; }
        public TimeSpan ExpirationTime { get; set; }
    }
}

