using Microsoft.EntityFrameworkCore;


namespace TemplateHexagonal.Core.Domain.Shared
{
    public class PaginatedDataList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedDataList(List<T> items, int count, int pageIndex, int pageSize = 10)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedDataList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            
            var count =  await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedDataList<T>(items, count, pageIndex, pageSize);
            
        }
    }
}
