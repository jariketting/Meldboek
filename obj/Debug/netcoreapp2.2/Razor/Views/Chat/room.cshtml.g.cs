#pragma checksum "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca2b46a18b22c9b8623eeb54dc6c679dc0df9cd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_room), @"mvc.1.0.view", @"/Views/Chat/room.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Chat/room.cshtml", typeof(AspNetCore.Views_Chat_room))]
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
#line 1 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/_ViewImports.cshtml"
using meldboek;

#line default
#line hidden
#line 2 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/_ViewImports.cshtml"
using meldboek.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca2b46a18b22c9b8623eeb54dc6c679dc0df9cd4", @"/Views/Chat/room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8de9e6b9d5c199835f9faa7d02b60c87e660435", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_room : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
  
    ViewData["Title"] = "Chatroom: ";
    Layout = "~/Views/Shared/_LayoutJari.cshtml";

#line default
#line hidden
            BeginContext(97, 88, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1 class=\"page-title\">Chatroom: <span class=\"text-info\">");
            EndContext();
            BeginContext(157, 12, false);
#line 7 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
                                     Write(ViewBag.name);

#line default
#line hidden
            EndContext();
            BeginContext(169, 88, true);
            WriteLiteral("</span> <a class=\"float-right text-danger\" href=\"/Chat\">Leave chat</a></h2>\n    <hr />\n\n");
            EndContext();
#line 10 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
     foreach(var message in ViewBag.messages)
    {

#line default
#line hidden
            BeginContext(309, 49, true);
            WriteLiteral("    <div class=\"row\">\n        <div class=\"col-2\">");
            EndContext();
            BeginContext(359, 16, false);
#line 13 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
                      Write(message.Username);

#line default
#line hidden
            EndContext();
            BeginContext(375, 26, true);
            WriteLiteral(" </div><div class=\"col-2\">");
            EndContext();
            BeginContext(402, 20, false);
#line 13 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
                                                                 Write(message.DatetimeSend);

#line default
#line hidden
            EndContext();
            BeginContext(422, 61, true);
            WriteLiteral("</div><div class=\"col-8\"></div>\n\n        <div class=\"col-12\">");
            EndContext();
            BeginContext(484, 15, false);
#line 15 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"
                       Write(message.Content);

#line default
#line hidden
            EndContext();
            BeginContext(499, 18, true);
            WriteLiteral("</div>\n    </div>\n");
            EndContext();
            BeginContext(518, 11, true);
            WriteLiteral("    <hr />\n");
            EndContext();
#line 19 "/Users/yasemin/Documents/Inf_jaar_2/Project D/meldboek/Views/Chat/room.cshtml"

    }

#line default
#line hidden
            BeginContext(536, 5, true);
            WriteLiteral("\n    ");
            EndContext();
            BeginContext(541, 242, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca2b46a18b22c9b8623eeb54dc6c679dc0df9cd46059", async() => {
                BeginContext(561, 215, true);
                WriteLiteral("\n        <label for=\"message\"></label>\n        <textarea rows=\"3\" class=\"form-control\" name=\"message\" id=\"message\"></textarea>\n        <br />\n        <input class=\"btn btn-primary\" type=\"submit\" value=\"Send\" />\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(783, 7, true);
            WriteLiteral("\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
