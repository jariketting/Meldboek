#pragma checksum "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "173032e62cb4b40766dcf744dcadeb4de6551c1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_Personlist), @"mvc.1.0.view", @"/Views/Person/Personlist.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Person/Personlist.cshtml", typeof(AspNetCore.Views_Person_Personlist))]
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
#line 1 "C:\Users\amyno\Documents\meldboek\Views\_ViewImports.cshtml"
using meldboek;

#line default
#line hidden
#line 2 "C:\Users\amyno\Documents\meldboek\Views\_ViewImports.cshtml"
using meldboek.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"173032e62cb4b40766dcf744dcadeb4de6551c1c", @"/Views/Person/Personlist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b303f695a79eb6d1dfd699c250715c9df1ce1a57", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_Personlist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PersonInfo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Topbar_Sidenav.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 27, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(59, 2344, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173032e62cb4b40766dcf744dcadeb4de6551c1c5267", async() => {
                BeginContext(65, 37, true);
                WriteLiteral("\r\n    <title>Gebruikers</title>\r\n    ");
                EndContext();
                BeginContext(102, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "173032e62cb4b40766dcf744dcadeb4de6551c1c5685", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(173, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(179, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173032e62cb4b40766dcf744dcadeb4de6551c1c7105", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(238, 2158, true);
                WriteLiteral(@"
    <style>
        body {
            font-family: 'Trebuchet MS', sans-serif;
            background-color: #ffffff;
        }

        .topbar {
            background-color: #e947ff;
        }

        .navbtn {
            background-color: #e947ff;
        }

        .overlay {
            background-color: #e947ff;
        }

        .overlay a:hover, .overlay a:focus, .logout a:hover, .logout a:focus {
            color: #f4a3ff;
        }

        .personlist-content {
            width: 100%;
            overflow: hidden;
            padding-top: 100px;
            padding-bottom: 50px;
        }

        /* options list */
        .options {
            position: fixed;
            float: left;
            width: 200px;
            height: 550px;
            padding-top: 80px;
            padding-left: 40px;
            border-right: 2px solid #e947ff;
            overflow-y: auto;
        }

        .options a {
            color: #000000;
            f");
                WriteLiteral(@"ont-size: 24px;
            text-decoration: none;
            display: block;
            padding-bottom: 15px;
        }

        .options a:hover {
             color: #f4a3ff;
        }

        .page-title {
            font-size: 28px;
            padding-bottom: 20px;
        }

        /* Persons list */
        .person-list {
            padding-top: 40px;
            margin-left: 340px;
        }

        /* Single person */
        .person {
            width: 90%;
            overflow: hidden;
            border-bottom: 1px solid #e947ff;
        }

        /* Person content consists of name (h1) and friend/unfriend options (a). */
        .person-content {
            float: left;
            width: 80%;
        }

        .person-content h1 {
            font-size: 22px;
            padding-bottom: 10px;
            padding-top: 20px;
        }

        .person-options {
            margin-top: 20px;
            margin-left: 83%;
        }

        .p");
                WriteLiteral("erson-options a {\r\n            text-decoration: none;\r\n            font-size: 20px;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2403, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2405, 2774, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "173032e62cb4b40766dcf744dcadeb4de6551c1c11483", async() => {
                BeginContext(2411, 350, true);
                WriteLiteral(@"
    <!-- Colored bar at the top of the page -->
    <div class=""topbar"">

        <!-- The button that opens the sidemenu -->
        <span class=""navbtn"" onclick=""nav()"">&#9776; </span>

        <!-- Page title -->
        <h1>Gebruikers</h1>

        <!-- Account information button -->
        <a href=""#accountinfo""><img id=""acc-icon""");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 2761, "\"", 2804, 1);
#line 114 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 2767, Url.Content("~/Content/account.png"), 2767, 37, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2805, 142, true);
                WriteLiteral("/></a>\r\n    </div>\r\n\r\n    <!-- Sidemenu overlay -->\r\n    <div id=\"nav\" class=\"overlay\">\r\n        <div class=\"overlay-content\">\r\n            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 2947, "\"", 2977, 1);
#line 120 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 2954, Url.Action("Newsfeed"), 2954, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2978, 195, true);
                WriteLiteral(">Newsfeed</a>\r\n            <br>\r\n            <a onclick=\"nav()\" href=\"#forums\">Forums</a>\r\n            <br>\r\n            <a onclick=\"nav()\" href=\"#chat\">Chat</a>\r\n            <br>\r\n            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3173, "\"", 3202, 1);
#line 126 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 3180, Url.Action("Groepen"), 3180, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3203, 369, true);
                WriteLiteral(@">Groepen</a>
            <br>
            <p style=""color: #f4a3ff;"">Gebruikers</p>
        </div>
        <div class=""logout""><a onclick=""nav()"" href=""#logout"">Log uit</a></div>
    </div>

    <!-- All the actual content of the page -->
    <div class=""personlist-content"">

        <!-- Personlist options -->
        <div class=""options"">
            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3572, "\"", 3648, 1);
#line 138 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 3579, Url.Action("FilteredPersonlist", new { filter = "Alle gebruikers" }), 3579, 69, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3649, 36, true);
                WriteLiteral(">Alle gebruikers</a>\r\n            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3685, "\"", 3753, 1);
#line 139 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 3692, Url.Action("FilteredPersonlist", new { filter = "Vrienden"}), 3692, 61, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3754, 103, true);
                WriteLiteral(">Vrienden</a>\r\n        </div>\r\n\r\n        <div class=\"person-list\">\r\n            <h1 class=\"page-title\">");
                EndContext();
                BeginContext(3858, 16, false);
#line 143 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                              Write(TempData["Page"]);

#line default
#line hidden
                EndContext();
                BeginContext(3874, 141, true);
                WriteLiteral("</h1>\r\n\r\n            <!-- Single person attribute; Here all the posts from GetPersonlist() or FilteredPersonlist() are put on the page. -->\r\n");
                EndContext();
#line 146 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
             foreach (var person in Model)
            {

#line default
#line hidden
                BeginContext(4074, 116, true);
                WriteLiteral("                <div class=\"person\">\r\n                    <div class=\"person-content\">\r\n                        <h1>");
                EndContext();
                BeginContext(4191, 23, false);
#line 150 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                       Write(person.Person.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(4214, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(4216, 22, false);
#line 150 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                                                Write(person.Person.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(4238, 37, true);
                WriteLiteral("</h1>\r\n                    </div>\r\n\r\n");
                EndContext();
#line 153 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                     if (person.Status == "")
                    {

#line default
#line hidden
                BeginContext(4345, 54, true);
                WriteLiteral("                        <div class=\"person-options\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4399, "\"", 4470, 1);
#line 155 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 4406, Url.Action("Friend", new { FriendId = person.Person.PersonId }), 4406, 64, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4471, 53, true);
                WriteLiteral(" style=\"color: #00ff00;\">Vriend toevoegen</a></div>\r\n");
                EndContext();
#line 156 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                    }

#line default
#line hidden
                BeginContext(4547, 22, true);
                WriteLiteral("                    \r\n");
                EndContext();
#line 158 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                     if (person.Status == "FriendPending")
                    {

#line default
#line hidden
                BeginContext(4652, 105, true);
                WriteLiteral("                        <div class=\"person-options\"><a style=\"color: #0000ff;\">In behandeling</a></div>\r\n");
                EndContext();
#line 161 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                    }

#line default
#line hidden
                BeginContext(4780, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 163 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                     if (person.Status == "IsFriendsWith")
                    {

#line default
#line hidden
                BeginContext(4865, 54, true);
                WriteLiteral("                        <div class=\"person-options\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4919, "\"", 5022, 1);
#line 165 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
WriteAttributeValue("", 4926, Url.Action("DeleteFriend", new { FriendId = person.Person.PersonId, Page = @TempData["Page"] }), 4926, 96, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5023, 55, true);
                WriteLiteral(" style=\"color: #ff0000;\">Vriend verwijderen</a></div>\r\n");
                EndContext();
#line 166 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
                    }

#line default
#line hidden
                BeginContext(5101, 26, true);
                WriteLiteral("\r\n                </div>\r\n");
                EndContext();
#line 169 "C:\Users\amyno\Documents\meldboek\Views\Person\Personlist.cshtml"
            }

#line default
#line hidden
                BeginContext(5142, 30, true);
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5179, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PersonInfo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
