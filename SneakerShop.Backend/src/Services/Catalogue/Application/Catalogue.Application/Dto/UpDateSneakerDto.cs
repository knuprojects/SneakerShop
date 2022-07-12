namespace Catalogue.Application.Dto
{
    public class UpDateSneakerDto
    {
        public int SneakerId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? Deleted { get; set; }
    }
}
