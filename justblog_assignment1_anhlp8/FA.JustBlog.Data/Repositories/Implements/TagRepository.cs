using FA.JustBlog.Core.Helpers;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Data.Contexts;
using FA.JustBlog.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Data.Repositories.Implements
{
    public class TagRepository : GenericRepostiory<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug.Equals(urlSlug));
        }

        public void AddTagsByNames(string names, string seperator = ";")
        {
            var tagNames = names.ToLower().Split(seperator);
            foreach (var tagName in tagNames)
            {
                var name = tagName.Trim();
                var existTag = _context.Tags.FirstOrDefault(t => t.Name.Equals(name));
                //add new tag
                if (existTag == null)
                {
                    _context.Tags.Add(new Tag() { Name = name, UrlSlug = UrlSlugHelper.FrientlyUrl(name) });
                }
            }
        }

        public List<int> GetIdsByTagNames(string names)
        {
            var tagNames = names.ToLower().Split(";");
            var tagIds = new List<int>();
            foreach (var tagName in tagNames)
            {
                var tag = _context.Tags.First(t => t.Name.Equals(tagName.Trim())).Id;
                tagIds.Add(tag);
            }
            return tagIds;
        }
    }
}