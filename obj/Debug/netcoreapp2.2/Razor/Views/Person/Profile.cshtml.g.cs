#pragma checksum "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_Profile), @"mvc.1.0.view", @"/Views/Person/Profile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Person/Profile.cshtml", typeof(AspNetCore.Views_Person_Profile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab", @"/Views/Person/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b303f695a79eb6d1dfd699c250715c9df1ce1a57", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<meldboek.ViewModels.Profile>
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
#line 1 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
  
    ViewData["Title"] = "Profiel";

#line default
#line hidden
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(81, 33, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n    ");
            EndContext();
            BeginContext(114, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab5532", async() => {
                BeginContext(120, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(130, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab5922", async() => {
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
                BeginContext(201, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(211, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab7347", async() => {
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
                BeginContext(270, 6, true);
                WriteLiteral("\r\n    ");
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
            BeginContext(283, 2487, true);
            WriteLiteral(@"
    <style>
        .topbar {
            background-color: orange;
        }

        .navbtn {
            background-color: orange;
        }

        .overlay {
            background-color: orange;
        }

        .overlay a:hover, .overlay a:focus, .logout a:hover, .logout a:focus {
            color: #ffe4b3;
        }

        body {
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;

        }

        .profile-content {
            margin-left: 10%;
            padding-bottom: 10%;
        }

        .info h1 {
            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            color: orange;
            font-size: 26px;
            font-weight: bold;
            padding-top: 150px;
        }

        .info h2 {
            padding-top: 10px;
            color: #000000;
            font-size: 22px;
        }

        .personlist-cont");
            WriteLiteral(@"ent {
            width: 100%;
            overflow: hidden;
            padding-top: 100px;
            padding-bottom: 50px;
        }
    
        /* Persons list */
        .person-list {
            padding-top: 40px;
        }

        .person-list h1 {
            color: orange;
            font-size: 24px;
        }

        /* Single person */
        .person {
            width: 90%;
            overflow: hidden;
            border-bottom: 1px solid orange;
        }

        /* Person content consists of name (h1) and friend/unfriend options (a). */
        .person-content {
            float: left;
            width: 80%;
        }

        .person-content h1 {
            color: #000000;
            font-size: 22px;
            padding-bottom: 10px;
            padding-top: 20px;
        }

        .person-options {
            margin-top: 20px;
            margin-left: 83%;
        }

        .person-options a {
            text-decoration: none;
     ");
            WriteLiteral(@"       font-size: 20px;
        }

        #accept-friend {
            color: #00ff00;
            transition: 0.2s;
            display: block;
        }

        #accept-friend:hover {
            color: #b3ffb3;
        }

        #deny-delete-friend {
            color: #ff0000;
            transition: 0.2s;
        }

        #deny-delete-friend:hover {
            color: #ffb3b3;
        }
    </style>
    ");
            EndContext();
            BeginContext(2770, 4146, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1c58f0e8e2715d322d74ebad0cefd0e4ed7e36ab12040", async() => {
                BeginContext(2776, 326, true);
                WriteLiteral(@"
        <div class=""topbar"">

            <!-- The button that opens the sidemenu -->
            <span class=""navbtn"" onclick=""nav()"">&#9776; </span>

            <!-- Page title -->
            <h1 style=""width: 53%;"">Profiel</h1>

            <!-- Account information button -->
            <a><img id=""acc-icon""");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 3102, "\"", 3145, 1);
#line 131 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3108, Url.Content("~/Content/account.png"), 3108, 37, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3146, 162, true);
                WriteLiteral("/></a>\r\n        </div>\r\n\r\n        <!-- Sidemenu overlay -->\r\n        <div id=\"nav\" class=\"overlay\">\r\n            <div class=\"overlay-content\">\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3308, "\"", 3338, 1);
#line 137 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3315, Url.Action("Newsfeed"), 3315, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3339, 53, true);
                WriteLiteral(">Nieuws</a>\r\n                <br>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3392, "\"", 3431, 1);
#line 139 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3399, Url.Action("ForumHome","Forum"), 3399, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3432, 53, true);
                WriteLiteral(">Forums</a>\r\n                <br>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3485, "\"", 3520, 1);
#line 141 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3492, Url.Action("Index", "Chat"), 3492, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3521, 51, true);
                WriteLiteral(">Chat</a>\r\n                <br>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3572, "\"", 3601, 1);
#line 143 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3579, Url.Action("Groepen"), 3579, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3602, 54, true);
                WriteLiteral(">Groepen</a>\r\n                <br>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3656, "\"", 3688, 1);
#line 145 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 3663, Url.Action("Personlist"), 3663, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3689, 268, true);
                WriteLiteral(@">Gebruikers</a>
            </div>
            <div class=""logout""><a onclick=""nav()"" href=""#logout"">Log uit</a></div>
        </div>

        <div class=""profile-content"">
            <div class=""info"">
                <h1>Info</h1>
                <h2>Naam: ");
                EndContext();
                BeginContext(3958, 10, false);
#line 153 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                     Write(Model.Name);

#line default
#line hidden
                EndContext();
                BeginContext(3968, 34, true);
                WriteLiteral("</h2>\r\n                <h2>Email: ");
                EndContext();
                BeginContext(4003, 11, false);
#line 154 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                      Write(Model.Email);

#line default
#line hidden
                EndContext();
                BeginContext(4014, 105, true);
                WriteLiteral("</h2>\r\n            </div>\r\n\r\n            <div class=\"person-list\">\r\n                <h1>Vrienden</h1>\r\n\r\n");
                EndContext();
#line 160 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                 foreach (var person in Model.PersonInfos)
                 {
                        

#line default
#line hidden
#line 162 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         if (person.Status == "IsFriendsWith")
                         {

#line default
#line hidden
                BeginContext(4291, 152, true);
                WriteLiteral("                            <div class=\"person\">\r\n                                <div class=\"person-content\">\r\n                                    <h1>");
                EndContext();
                BeginContext(4444, 23, false);
#line 166 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                   Write(person.Person.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(4467, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(4469, 22, false);
#line 166 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                                            Write(person.Person.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(4491, 171, true);
                WriteLiteral("</h1>\r\n                                </div>\r\n                                <div class=\"person-options\">\r\n                                    <a id=\"deny-delete-friend\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4662, "\"", 4784, 1);
#line 169 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 4669, Url.Action("DeleteFriendProfile", "Person", new { FriendId = person.Person.PersonId, PersonId = @Model.PersonId }), 4669, 115, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4785, 101, true);
                WriteLiteral(">Vriend verwijderen</a>\r\n                                </div>\r\n                            </div>\r\n");
                EndContext();
#line 172 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         }

#line default
#line hidden
#line 172 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                          
                 }

#line default
#line hidden
                BeginContext(4934, 119, true);
                WriteLiteral("            </div>\r\n\r\n            <div class=\"person-list\">\r\n                <h1>Ontvangen vriendschapsverzoeken</h1>\r\n");
                EndContext();
#line 178 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                     foreach (var person in Model.PersonInfos)
                     {
                        

#line default
#line hidden
#line 180 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         if (person.Status == "requested")
                         {

#line default
#line hidden
                BeginContext(5229, 152, true);
                WriteLiteral("                            <div class=\"person\">\r\n                                <div class=\"person-content\">\r\n                                    <h1>");
                EndContext();
                BeginContext(5382, 23, false);
#line 184 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                   Write(person.Person.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(5405, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(5407, 22, false);
#line 184 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                                            Write(person.Person.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(5429, 192, true);
                WriteLiteral("</h1>\r\n                                </div>\r\n                                <div class=\"person-options\" style=\"margin-top: 10px;\">\r\n                                    <a id=\"accept-friend\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 5621, "\"", 5771, 1);
#line 187 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 5628, Url.Action("AcceptFriend", "Person", new { PersonRequestedId = person.Person.PersonId, PersonAcceptedId = @Model.PersonId, page = "Profile" }), 5628, 143, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5772, 86, true);
                WriteLiteral(">Vriend accepteren</a>\r\n                                    <a id=\"deny-delete-friend\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 5858, "\"", 5966, 1);
#line 188 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
WriteAttributeValue("", 5865, Url.Action("RefuseFriendReq", "Person", new { PersonId = person.Person.PersonId, page = "Profile" }), 5865, 101, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5967, 98, true);
                WriteLiteral(">Vriend afwijzen</a>\r\n                                </div>\r\n                            </div>\r\n");
                EndContext();
#line 191 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         }

#line default
#line hidden
#line 191 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                          
                     }

#line default
#line hidden
                BeginContext(6117, 120, true);
                WriteLiteral("            </div>\r\n\r\n            <div class=\"person-list\">\r\n                <h1>Verstuurde vriendschapsverzoeken</h1>\r\n");
                EndContext();
#line 197 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                     foreach (var person in Model.PersonInfos)
                     {
                        

#line default
#line hidden
#line 199 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         if (person.Status == "FriendPending")
                         {

#line default
#line hidden
                BeginContext(6417, 152, true);
                WriteLiteral("                            <div class=\"person\">\r\n                                <div class=\"person-content\">\r\n                                    <h1>");
                EndContext();
                BeginContext(6570, 23, false);
#line 203 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                   Write(person.Person.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(6593, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(6595, 22, false);
#line 203 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                                                            Write(person.Person.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(6617, 196, true);
                WriteLiteral("</h1>\r\n                                </div>\r\n                                <div class=\"person-options\"><a style=\"color: #0000ff;\">In behandeling</a></div>\r\n                            </div>\r\n");
                EndContext();
#line 207 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                         }

#line default
#line hidden
#line 207 "C:\Users\ses-9\Desktop\meldboek\meldboek\Views\Person\Profile.cshtml"
                          
                     }

#line default
#line hidden
                BeginContext(6865, 44, true);
                WriteLiteral("            </div>\r\n\r\n        </div>\r\n\r\n    ");
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
            BeginContext(6916, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<meldboek.ViewModels.Profile> Html { get; private set; }
    }
}
#pragma warning restore 1591
