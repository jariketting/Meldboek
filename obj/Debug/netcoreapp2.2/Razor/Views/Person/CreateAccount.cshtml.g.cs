#pragma checksum "C:\Users\amyno\Documents\meldboek\Views\Person\CreateAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65df685aa1b679f618b9339d93eff6cd37899271"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_CreateAccount), @"mvc.1.0.view", @"/Views/Person/CreateAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Person/CreateAccount.cshtml", typeof(AspNetCore.Views_Person_CreateAccount))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65df685aa1b679f618b9339d93eff6cd37899271", @"/Views/Person/CreateAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b303f695a79eb6d1dfd699c250715c9df1ce1a57", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_CreateAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<meldboek.Models.Person>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(56, 1882, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65df685aa1b679f618b9339d93eff6cd378992714248", async() => {
                BeginContext(62, 1869, true);
                WriteLiteral(@"
    <style>
        body {
            font-family: 'Open Sans', sans-serif;
            background: 21323;
            margin: 0 auto 0 auto;
            width: 100%;
            text-align: center;
            margin: 0px 0px 0px 0px;
        }

        .box {
            background: #ffabf3;
            width: 800px;
            border-radius: 6px;
            position: center margin: 0 auto 0 auto;
            padding: 100px 100px 100px 50px;
            border: #e67cd7 4px solid;
        }

        .Personname {
            background: #ecf0f1;
            border: #8593bc 1px solid;
            border-bottom: #ccc 2px solid;
            padding: 8px;
            width: 350px;
            color: #AAAAAA;
            margin-top: 10px;
            font-size: 1em;
            border-radius: 4px;
        }

        .button {
            background: #6f89c4;
            width: 200px;
            padding-top: 5px;
            padding-bottom: 5px;
            padding-left: 7");
                WriteLiteral(@"5px;
            color: white;
            border-radius: 4px;
            border: #27ae60 1px solid;
            margin-top: 10px;
            margin-bottom: 20px;
            margin-left: 100px;
            margin-right: auto;
            float: left;
            margin-left: 125px;
            font-weight: 600;
            font-size: 0.8em;
        }

            .button:hover {
                background: Blue;
            }

        .fpwd {
            color: #6f89c4;
            text-decoration: underline;
        }

        #absoluteCenteredDiv {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            margin: auto;
            width: 800px;
            height: 300px;
            text-align: left;
        }
    </style>
");
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
            BeginContext(1938, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1940, 1192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65df685aa1b679f618b9339d93eff6cd378992717336", async() => {
                BeginContext(1946, 92, true);
                WriteLiteral("\r\n    <h1 id=\"login-header\">CreateAccount</h1>\r\n    <div id=\"absoluteCenteredDiv\">\r\n        ");
                EndContext();
                BeginContext(2038, 1073, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65df685aa1b679f618b9339d93eff6cd378992717820", async() => {
                    BeginContext(2085, 1019, true);
                    WriteLiteral(@"
            <div class=""box"">

                <p><font face=""verdana"" color=""black"">Firstname</font></p>
                <input type=""string"" required name=firstname id=""firstname"" size=""50""><br><br>
                <p><font face=""verdana"" color=""black"">Lastname</font></p>
                <input type=""string"" required name=lastname id=""lastname"" size=""50""><br><br>
                <p><font face=""verdana"" color=""black"">Emailadres</font></p>
                <input type=""string"" required name=email id=""email"" size=""50""><br><br>
                <p><font face=""verdana"" color=""black"">Wachtwoord</font></p>
                <input type=""password"" required name=password id=""password"" size=""50""> <br><br>
                <p><font face=""verdana"" color=""black"">Wachtwoord Herhalen</font></p>
                <input type=""password"" required name=password2 id=""password2"" size=""50""> <br><br>
                <input type=""submit"" class=""button"" value=""Accout Toevoegen"" id=""submit"">
            </div>
        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3111, 14, true);
                WriteLiteral("\r\n    </div>\r\n");
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
            BeginContext(3132, 9, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<meldboek.Models.Person> Html { get; private set; }
    }
}
#pragma warning restore 1591
