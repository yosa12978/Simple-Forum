#pragma checksum "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68b03d01d285b3637ab52d45322287cc2f74430d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Forum_Detail), @"mvc.1.0.view", @"/Views/Forum/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\asp.net apps\simple_Forum\simple_Forum\Views\_ViewImports.cshtml"
using simple_Forum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\asp.net apps\simple_Forum\simple_Forum\Views\_ViewImports.cshtml"
using simple_Forum.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68b03d01d285b3637ab52d45322287cc2f74430d", @"/Views/Forum/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24a4f200e7f2201f3d598fd895e95dd6b079798b", @"/Views/_ViewImports.cshtml")]
    public class Views_Forum_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<simple_Forum.Models.Post>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
  
    ViewData["Title"] = Model.title;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"alert alert-secondary\" style=\"border-radius: 0px; border-color:white;\">\r\n    <h3 style=\"word-wrap: break-word\">");
#nullable restore
#line 7 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
                                 Write(Html.DisplayFor(model => model.title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n</div>\r\n    <div>\r\n\r\n        <div class=\"alert alert-secondary mt-0\" style=\"border-radius: 0px; border-color:white; \">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 386, "\"", 436, 1);
#nullable restore
#line 13 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
WriteAttributeValue("", 392, Html.DisplayFor(model => model.Author.icon), 392, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px; height:100px;\" />\r\n            <p>");
#nullable restore
#line 14 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
          Write(Html.DisplayFor(model => model.createDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <a");
            BeginWriteAttribute("href", " href=\"", 540, "\"", 610, 2);
            WriteAttributeValue("", 547, "/Account/?name=", 547, 15, true);
#nullable restore
#line 14 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
WriteAttributeValue("", 562, Html.DisplayFor(model => model.Author.username), 562, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
                                                                                                                                  Write(Html.DisplayFor(model => model.Author.username));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n            <hr>\r\n            <p style=\"word-wrap: break-word\">");
#nullable restore
#line 16 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
                                        Write(Html.DisplayFor(model => model.text));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n<br>\r\n<hr>\r\n<h3>Discussions</h3>\r\n");
#nullable restore
#line 22 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
 foreach (var i in ViewBag.Discussies)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div class=\"alert alert-secondary mt-0\" style=\"border-radius: 0px; border-color:white;\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 994, "\"", 1014, 1);
#nullable restore
#line 26 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
WriteAttributeValue("", 1000, i.Author.icon, 1000, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100px; height:100px;\" />\r\n        <p>");
#nullable restore
#line 27 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
      Write(i.pubdate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - <a");
            BeginWriteAttribute("href", " href=\"", 1081, "\"", 1121, 2);
            WriteAttributeValue("", 1088, "/Account/?name=", 1088, 15, true);
#nullable restore
#line 27 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
WriteAttributeValue("", 1103, i.Author.username, 1103, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
                                                               Write(i.Author.username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n        <hr>\r\n        <p style=\"word-wrap: break-word\">");
#nullable restore
#line 29 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
                                    Write(i.text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 32 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 36 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-4\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68b03d01d285b3637ab52d45322287cc2f74430d8675", async() => {
                WriteLiteral(@"
                <div class=""form-group"">
                    <textarea name=""text"" class=""form-control"" placeholder=""Text"" style=""width: 100%; height: 150px;""></textarea>
                </div>
                <div class=""form-group"">
                    <input type=""submit"" value=""Submit"" class=""btn btn-outline-secondary"" />
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 48 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-4\">\r\n            <h4><a href=\"/Account/Login/\" class=\"btn btn-outline-primary\">Login to leave comments</a></h4>\r\n        </div>\r\n");
#nullable restore
#line 54 "D:\asp.net apps\simple_Forum\simple_Forum\Views\Forum\Detail.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<simple_Forum.Models.Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
