using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HexagonalAPIWEBWORKER.Core.Domain.Shared
{
    public class PaginatedList<T> : IPaginatedList<T> where T : class
    {
        public List<T> Items { get; set; }

        [JsonIgnore]
        public int PageSize { get; set; }

        [JsonIgnore]
        public int PageNumber { get; set; }

        public int TotalPages
        { get { return GetTotalPages(); } }

        [JsonIgnore]
        public int Skip
        { get { return GetSkip(); } }

        public int TotalCount { get; set; }
        public int TotalItemsCount { get; set; }
        public int CurrentPage { get; set; }

        [JsonIgnore]
        public bool IsValid
        { get { return PaginatedListIsValid(); } }

        public PaginatedList(int totalCount, int pageNumber, int pageSize)
        {
            TotalCount = totalCount > 0 ? totalCount : 0;
            PageNumber = pageNumber == 0 ? 1 : pageNumber;
            PageSize = pageSize == 0 ? 100 : pageSize;

            Items = Array.Empty<T>().ToList();
            CurrentPage = pageNumber;
            TotalItemsCount = 0;
        }

        private int GetTotalPages()
        {
            return (int)Math.Ceiling(TotalCount / (double)PageSize);
        }

        private int GetSkip()
        {
            return PageSize * (PageNumber - 1);
        }

        private bool PaginatedListIsValid()
        {
            if (PageNumber > TotalPages)
                return false;

            return true;
        }
    }
}
