using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FA.JustBlog.Core.Enums
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var attr = enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>();
            return attr?.Name ?? string.Empty;
        }
    }
}