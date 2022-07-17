using Catalogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Application.Dto
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public List<Company> Companies { get; set; }
    }
}
