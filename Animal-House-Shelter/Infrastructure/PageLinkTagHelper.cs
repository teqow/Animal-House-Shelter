﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Animal_House_Shelter.Infrastructure
{
    //didnt work
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        //[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        //public Dictionary<string, object> PageUrlValues { get; set; }
        //    = new Dictionary<string, object>();

        //public bool PageClassesEnabled { get; set; } = false;
        //public string PageClass { get; set; }
        //public string PageClassNormal { get; set; }
        //public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction,
                    new { dogsPage = i });
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
