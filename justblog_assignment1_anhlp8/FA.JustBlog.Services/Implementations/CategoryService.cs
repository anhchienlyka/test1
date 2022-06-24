using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Data.UnitOfWorks;
using FA.JustBlog.Services.Interfaces;
using FA.JustBlog.Services.Models.Request;
using FA.JustBlog.Services.Models.Response;
using System.Collections.Generic;

namespace FA.JustBlog.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IBlogUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IBlogUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateCategory(CategoryRequest request)
        {
            if (request != null)
            {
                var category = _mapper.Map<Category>(request);
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
            }
        }

        public void DeleteCategory(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            var cats = _unitOfWork.CategoryRepository.GetAll();
            if (cats == null)
                return new List<CategoryResponse>();
            return _mapper.Map<IEnumerable<CategoryResponse>>(cats);
        }

        public CategoryResponse GetCategory(int id)
        {
            var catEntity = _unitOfWork.CategoryRepository.Find(id);
            if (catEntity == null)
                return null;
            return _mapper.Map<CategoryResponse>(catEntity);
        }

        public void UpdateCategory(CategoryRequest request)
        {
            if (request != null)
            {
                var category = _mapper.Map<Category>(request);
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
            }
        }
    }
}