using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlayerProject.Web.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
