using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidPhotoUrlException : Exception
    {
        public string PhotoUrl { get; set; }
        public InvalidPhotoUrlException(string photoUrl) : base($"PhotoUrl: {photoUrl} is invalid!")
        {
            PhotoUrl = photoUrl;
        }
    }
}
