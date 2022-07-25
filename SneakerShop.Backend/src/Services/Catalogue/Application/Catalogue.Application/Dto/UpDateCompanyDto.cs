namespace Catalogue.Application.Dto
{
    public class UpdateCompanyDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
