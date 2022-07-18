namespace Catalogue.Application.Dto
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public int CompanyId { get; set; }
    }
}
