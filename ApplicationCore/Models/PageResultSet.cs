namespace ApplicationCore.Models
{
    public class PageResultSet<TEntity> where TEntity : class
    {


        public PageResultSet(List<TEntity> data, int pageIndex, int pageSize, long count)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
            TotalPages = (int)Math.Ceiling(Count / (double)pageSize);
        }

        public int PageIndex { get; }
        public int PageSize { get; }
        public long Count { get; }
        public List<TEntity> Data { get; }
        public int TotalPages { get; }

        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPrevPage => PageIndex > 1;

    }
}
