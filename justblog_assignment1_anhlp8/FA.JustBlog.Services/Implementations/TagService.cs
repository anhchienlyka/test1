using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Paging;
using FA.JustBlog.Data.UnitOfWorks;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly IBlogUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagService(IBlogUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateTag(TagRequest request)
        {
            var tag = _mapper.Map<Tag>(request);
            _unitOfWork.TagRepository.Add(tag);
            _unitOfWork.Save();
        }

        public void DeleteTag(int id)
        {
            _unitOfWork.TagRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<TagResponse> GetAll(int pageOffset = 0, int pageSize = 5)
        {
            var tags = _unitOfWork.TagRepository.GetAll();
            if (tags == null)
                return new List<TagResponse>();
            return _mapper.Map<IEnumerable<TagResponse>>(tags);
        }

        public PagingResult<TagResponse> GetPopularTags(int pageOffset = 0, int pageSize = 5)
        {
            var tags = _unitOfWork.TagRepository.GetByCondition(pageSize, pageOffset, null, t => t.Count, false);
            var response = _mapper.Map<PagingResult<TagResponse>>(tags);
            return response;
        }

        public TagResponse GetTagById(int id)
        {
            var tag = _unitOfWork.TagRepository.Find(id);
            return _mapper.Map<TagResponse>(tag);
        }

        public void UpdateTag(TagRequest request)
        {
            var tag = _mapper.Map<Tag>(request);
            _unitOfWork.TagRepository.Update(tag);
            _unitOfWork.Save();
        }

        public TagResponse ViewTagById(int tagId)
        {
            var tag = _unitOfWork.TagRepository.Find(tagId);
            if (tag == null) return null;
            tag.Count++;
            _unitOfWork.TagRepository.Update(tag);
            _unitOfWork.Save();
            return _mapper.Map<TagResponse>(tag);
        }
    }
}