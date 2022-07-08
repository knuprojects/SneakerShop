namespace Security.Domain.Common
{
    public interface IBaseEntity
    {
        bool? Deleted { get; set; }
    }
}
