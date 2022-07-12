namespace Catalogue.Application.Dto
{
    public class UpDateCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
