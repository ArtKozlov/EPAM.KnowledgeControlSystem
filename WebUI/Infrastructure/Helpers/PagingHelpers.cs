using System;
using System.Text;
using System.Web.Mvc;
using WebUI.ViewModels;

namespace WebUI.Infrastructure.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString FewPageLinks(this HtmlHelper html,
        PageInfoViewModel pageInfoViewModel, Func<int,string, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageInfoViewModel.TotalPages; i++)
            {
                if (i == pageInfoViewModel.PageNumber)
                    CreatePageLink(i, pageInfoViewModel, ref pageUrl, ref result, "info");
                else
                    CreatePageLink(i, pageInfoViewModel, ref pageUrl, ref result, "default");
            }

            return MvcHtmlString.Create(result.ToString());
        }
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                PageInfoViewModel pageInfoViewModel, Func<int, string, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            if (pageInfoViewModel.PageNumber > 2)
            {
                CreatePageLink(pageInfoViewModel.PageNumber - 2, pageInfoViewModel, ref pageUrl, ref result, "default");
            }
            if (pageInfoViewModel.PageNumber != 1)
            {
                CreatePageLink(pageInfoViewModel.PageNumber - 1, pageInfoViewModel, ref pageUrl, ref result, "default");
            }

            CreatePageLink(pageInfoViewModel.PageNumber, pageInfoViewModel, ref pageUrl, ref result, "info");

            if (pageInfoViewModel.PageNumber != pageInfoViewModel.TotalPages)
            {
                CreatePageLink(pageInfoViewModel.PageNumber + 1, pageInfoViewModel, ref pageUrl, ref result, "default");
            }
            if (pageInfoViewModel.PageNumber < pageInfoViewModel.TotalPages - 1)
            {
                CreatePageLink(pageInfoViewModel.PageNumber + 2, pageInfoViewModel, ref pageUrl, ref result, "default");
            }

            return MvcHtmlString.Create(result.ToString());
        }
        public static MvcHtmlString PageTopLink(this HtmlHelper html,
                PageInfoViewModel pageInfoViewModel, Func<int, string, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            CreatePageLink(1, pageInfoViewModel, ref pageUrl, ref result, "primary");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PageEndLink(this HtmlHelper html,
                PageInfoViewModel pageInfoViewModel, Func<int, string, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            CreatePageLink(pageInfoViewModel.TotalPages, pageInfoViewModel, ref pageUrl, ref result, "primary");

            return MvcHtmlString.Create(result.ToString());
        }

        private static void CreatePageLink(int i, PageInfoViewModel pageInfoViewModel, ref Func<int, string, string> pageUrl, ref StringBuilder result, string buttonType)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.MergeAttribute("data-ajax", "true");
            tag.MergeAttribute("href", pageUrl(i, pageInfoViewModel.SearchItem));
            tag.MergeAttribute("data-ajax-mode", "replace");
            tag.MergeAttribute("data-ajax-update", "#results");
            if (buttonType == "default")
            {
                tag.SetInnerText(i.ToString());
                tag.AddCssClass("btn btn-default");
            }

            if (buttonType == "info")
            {
                tag.InnerHtml = i.ToString();
                tag.AddCssClass("btn btn-info");
                tag.AddCssClass("selected");
            }
            if (buttonType == "primary")
            {
                if (i == 1)
                    tag.InnerHtml = "<<";
                else
                    tag.InnerHtml = ">>";
                tag.AddCssClass("btn btn-primary");
            }
            result.Append(tag);
        }
    }
}