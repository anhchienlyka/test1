using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Services.Models;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;

namespace FA.JustBlog.Services.Mapper
{
    public class ServiceMapperProfile : Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<Post, PostResponse>();
            CreateMap<Tag, TagResponse>();
            CreateMap<Comment, CommentResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<PostRequest, Post>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<TagRequest, Tag>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<TagResponse, Tag>();
            CreateMap<PagingResult<Tag>, PagingResult<TagResponse>>();
            CreateMap<PagingResult<Post>, PagingResult<PostResponse>>();
            CreateMap<PagingResult<Category>, PagingResult<CategoryResponse>>();
            CreateMap<PagingResult<Comment>, PagingResult<CommentResponse>>();
        }
    }
}