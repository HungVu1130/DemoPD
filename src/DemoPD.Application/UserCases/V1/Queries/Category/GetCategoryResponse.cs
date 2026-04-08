using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Application.UserCases.V1.Queries.Category
{
    public record GetCategoryResponse
    {
        public Guid CategoryId {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
    }
}
