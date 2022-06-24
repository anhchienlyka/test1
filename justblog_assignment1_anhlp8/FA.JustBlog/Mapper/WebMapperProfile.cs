using AutoMapper;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Models;
using FA.JustBlog.Services.Models;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Mapper
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<CategoryResponse, EditCategoryViewModel>();
            CreateMap<PostResponse, CreatePostViewModel>();
            CreateMap<CommentResponse, CreateCommentViewModel>();
            CreateMap<CommentResponse, EditCommentViewModel>();

            CreateMap<CreatePostViewModel, PostRequest>();
            CreateMap<CreateCategoryViewModel, CategoryRequest>();
            CreateMap<EditCategoryViewModel, CategoryRequest>();
            CreateMap<CreateTagViewModel, TagRequest>();
            CreateMap<EditTagViewModel, TagRequest>();
            CreateMap<CreateCommentViewModel, CommentRequest>();
            CreateMap<EditCommentViewModel, CommentRequest>();
            CreateMap<CategoryResponse, SelectListItem>()
                .ForMember(d => d.Value, o => o.MapFrom(c => c.Id))
                .ForMember(d => d.Text, o => o.MapFrom(c => c.Name));

            CreateMap<TagResponse, SelectListItem>()
                .ForMember(d => d.Value, o => o.MapFrom(c => c.Id))
                .ForMember(d => d.Text, o => o.MapFrom(c => c.Name));

            CreateMap<CreateUserViewModel, CreateUserRequest>()
                .ForMember(d => d.UserRoleNames, o => o.MapFrom(s => s.SelectRoles.Where(r => r.IsSelected).Select(r => r.RoleName).ToList()));
            CreateMap<EditUserViewModel, EditUserRequest>()
                .ForMember(d => d.UserRoleNames, o => o.MapFrom(s => s.SelectRoles.Where(r => r.IsSelected).Select(r => r.RoleName).ToList()));
            CreateMap<UserResponse, UserViewModel>();
            CreateMap<UserResponse, EditUserViewModel>();
            CreateMap<PagingResult<UserResponse>, PagingResult<UserViewModel>>();
        }
    }
}