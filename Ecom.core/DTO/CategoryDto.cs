using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.DTO
{
    public record CategoryDto
    (string Name, string Description);
    public record UpdateCategoryDto(int id, string Name, string Description);

}
