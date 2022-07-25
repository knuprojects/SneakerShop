namespace Catalogue.Application.Dto
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public int CompanyId { get; set; }
    }
}
