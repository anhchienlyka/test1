using System.Collections.Generic;

namespace FA.JustBlog.Core.Paging
{
    public class PagingResult<T> : PagingResultBase where T : class
    {
        public IEnumerable<T> Items { get; set; }
    }
}