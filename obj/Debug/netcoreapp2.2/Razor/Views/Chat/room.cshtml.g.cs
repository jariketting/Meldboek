#pragma checksum "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1592c9edf5ecbab2d1b2337b922d9b20cb9ffe75"
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
#line 1 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\_ViewImports.cshtml"
using meldboek;

#line default
#line hidden
#line 2 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\_ViewImports.cshtml"
using meldboek.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1592c9edf5ecbab2d1b2337b922d9b20cb9ffe75", @"/Views/Chat/room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b303f695a79eb6d1dfd699c250715c9df1ce1a57", @"/Views/_ViewImports.cshtml")]
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
#line 1 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
  
    ViewData["Title"] = "Chatroom: ";
    Layout = "~/Views/Shared/_LayoutJari.cshtml";

#line default
#line hidden
            BeginContext(97, 88, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1 class=\"page-title\">Chatroom: <span class=\"text-info\">");
            EndContext();
            BeginContext(186, 12, false);
#line 7 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
                                                        Write(ViewBag.name);

#line default
#line hidden
            EndContext();
            BeginContext(198, 100, true);
            WriteLiteral("</span> <a class=\"float-right text-danger\" href=\"/Chat/Index\">Chat verlaten</a></h1>\r\n    <hr />\r\n\r\n");
            EndContext();
#line 10 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
     foreach(var message in ViewBag.messages)
    {

#line default
#line hidden
            BeginContext(352, 50, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-2\">");
            EndContext();
            BeginContext(403, 18, false);
#line 13 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
                      Write(message.Personname);

#line default
#line hidden
            EndContext();
            BeginContext(421, 27, true);
            WriteLiteral(" </div> <div class=\"col-2\">");
            EndContext();
            BeginContext(449, 20, false);
#line 13 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
                                                                    Write(message.DatetimeSend);

#line default
#line hidden
            EndContext();
            BeginContext(469, 180, true);
            WriteLiteral("</div> <div class=\"col-8\"></div>\r\n        <div class=\"col-12\"> <br /></div>                                                                           \r\n        <div class=\"col-12\">");
            EndContext();
            BeginContext(650, 15, false);
#line 15 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"
                       Write(message.Content);

#line default
#line hidden
            EndContext();
            BeginContext(665, 20, true);
            WriteLiteral("</div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(687, 12, true);
            WriteLiteral("    <hr />\r\n");
            EndContext();
#line 19 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Chat\room.cshtml"

    }

#line default
#line hidden
            BeginContext(708, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(714, 252, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1592c9edf5ecbab2d1b2337b922d9b20cb9ffe756248", async() => {
                BeginContext(734, 225, true);
                WriteLiteral("\r\n        <label for=\"message\"></label>\r\n        <textarea rows=\"3\" class=\"form-control\" name=\"message\" id=\"message\"></textarea>\r\n        <br />\r\n        <input class=\"btn btn-primary\" type=\"submit\" value=\"Versturen\" />\r\n    ");
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
            BeginContext(966, 8, true);
            WriteLiteral("\r\n</div>");
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
