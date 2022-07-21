using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidPhotoUrlException : CustomException
    {
        public string PhotoUrl { get; set; }
        public InvalidPhotoUrlException(string photoUrl) : base($"PhotoUrl: {photoUrl} is invalid!")
        {
            PhotoUrl = photoUrl;
        }
    }
}
