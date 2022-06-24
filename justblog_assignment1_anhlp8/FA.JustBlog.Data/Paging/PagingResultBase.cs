namespace FA.JustBlog.Core.Paging
{
    public class PagingResultBase
    {
        public PagingResultBase()
        {
            PageSize = 5;
        }

        public int PageSize { get; set; }

        public int PageOffset { get; set; }

        public int ItemCount { get; set; }

        public int TotalPage { get; set; }
    }
}