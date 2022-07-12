using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Application.Dto
{
    public class DeleteSneakerDto
    {
        public int SneakerId { get; set; }
        public bool? Deleted { get; set; }
    }
}
