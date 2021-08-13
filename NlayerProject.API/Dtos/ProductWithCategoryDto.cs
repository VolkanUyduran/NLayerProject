using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NlayerProject.API.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
