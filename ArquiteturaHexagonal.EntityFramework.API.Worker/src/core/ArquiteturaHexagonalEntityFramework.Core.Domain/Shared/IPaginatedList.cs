using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateHexagonal.Core.Domain.Shared
{
    public interface IPaginatedList<T> where T : class
    {
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; }
        public int TotalCount { get; set; }
        public int TotalItemsCount { get; set; }
    }
}
