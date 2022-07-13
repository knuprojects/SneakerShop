using Catalogue.Domain.Exceptions;

namespace Catalogue.Domain.ValueObjects
{
    public class PhotoUrl
    {
        public string Value { get; set; }
        public PhotoUrl(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidPhotoUrlException(value);
            if (value.Length > 256 || value.Length < 12)
                throw new InvalidPhotoUrlException(value);

            Value = value;
        }
        public static implicit operator PhotoUrl(string value) => value is null ? null : new PhotoUrl(value);

        public static implicit operator string(PhotoUrl value) => value.Value;
        public override string ToString() => Value;
    }
}
