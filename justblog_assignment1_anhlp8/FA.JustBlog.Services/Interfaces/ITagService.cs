using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<TagResponse> GetAll(int pageOffset = 0, int pageSize = 5);

        PagingResult<TagResponse> GetPopularTags(int pageOffset = 0, int pageSize = 5);

        void CreateTag(TagRequest request);

        void UpdateTag(TagRequest request);

        void DeleteTag(int id);

        TagResponse GetTagById(int id);
        TagResponse ViewTagById(int tagId);
    }
}