namespace Catalogue.Domain.Common
{
    public interface IBaseEntity
    {
        bool? Deleted { get; set; }
    }
}
