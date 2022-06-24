using FA.JustBlog.Core.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Net;

namespace FA.JustBlog.TagHelpers
{
    [HtmlTargetElement("pager", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PagerTagHelper : TagHelper
    {
        private readonly HttpContext _httpContext;
        private readonly IUrlHelper _urlHelper;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public PagerTagHelper(IHttpContextAccessor accessor, IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            _httpContext = accessor.HttpContext;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        [HtmlAttributeName("pager-model")]
        public PagingResultBase Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Model == null)
            {
                return;
            }

            if (Model.TotalPage == 0)
            {
                return;
            }

            var action = ViewContext.RouteData.Values["action"].ToString();
            var urlTemplate = WebUtility.UrlDecode(_urlHelper.Action(action, new { pageIndex = "{0}" }));
            var request = _httpContext.Request;
            foreach (var key in request.Query.Keys)
            {
                if (key == "pageIndex")
                {
                    continue;
                }

                urlTemplate += "&" + key + "=" + request.Query[key];
            }

            var startIndex = Math.Max(Model.PageOffset - 5, 1);
            var finishIndex = Math.Min(Model.PageOffset + 5, Model.TotalPage);

            output.TagName = "";
            output.Content.AppendHtml("<ul class=\"pagination\">");
            AddPageLink(output, string.Format(urlTemplate, 1), "&laquo;");

            for (var i = startIndex; i <= finishIndex; i++)
            {
                if (i == Model.PageOffset + 1)
                {
                    AddCurrentPageLink(output, i);
                }
                else
                {
                    AddPageLink(output, string.Format(urlTemplate, i), i.ToString());
                }
            }

            AddPageLink(output, string.Format(urlTemplate, Model.TotalPage), "&raquo;");
            output.Content.AppendHtml("</ul>");
        }

        private void AddPageLink(TagHelperOutput output, string url, string text)
        {
            output.Content.AppendHtml("<li class=\"page-item\"><a class=\"page-link\" href=\"");
            output.Content.AppendHtml(url);
            output.Content.AppendHtml("\">");
            output.Content.AppendHtml(text);
            output.Content.AppendHtml("</a>");
            output.Content.AppendHtml("</li>");
        }

        private void AddCurrentPageLink(TagHelperOutput output, int page)
        {
            output.Content.AppendHtml("<li class=\"page-item active\"><a class=\"page-link\">");
            output.Content.AppendHtml(page.ToString());
            output.Content.AppendHtml("</a>");
            output.Content.AppendHtml("</li>");
        }
    }
}