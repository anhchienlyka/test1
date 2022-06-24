using FA.JustBlog.Core.Models;
using System.Collections.Generic;

namespace FA.JustBlog.Data.Repositories.Interfaces
{
    public interface ITagRepository : IGenericRepostiory<Tag>
    {
        //Tag Find(int TagId);

        //void AddTag(Tag Tag);

        //void UpdateTag(Tag Tag);

        //void DeleteTag(Tag Tag);

        //void DeleteTag(int TagId);

        //IList<Tag> GetAllTags();

        Tag GetTagByUrlSlug(string urlSlug);

        void AddTagsByNames(string names, string seperator = ";");

        List<int> GetIdsByTagNames(string names);
    }
}