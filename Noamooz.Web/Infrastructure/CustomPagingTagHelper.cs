using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Noamooz.Web.Models.ViewModel;

namespace Noamooz.Web.Infrastructure
{
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class CustomPagingTagHelper : TagHelper
    {
        private IUrlHelperFactory _UrlHelper;
        public CustomPagingTagHelper(IUrlHelperFactory urlHelper)
        {
            _UrlHelper = urlHelper;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public PagingInformation pageModel { get; set; }
        public string pageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _UrlHelper.GetUrlHelper(viewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= pageModel.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(pageAction,new {page=i});
                tag.InnerHtml.Append(i.ToString());
                if (i == pageModel.CurrentPage)
                {
                    tag.AddCssClass("active rounded");
                }
                else
                {
                    tag.AddCssClass("rounded");
                }
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
