#pragma checksum "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41b9044ce5930e2dd8782f25aba3eefb332d7c62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Materiel_Details), @"mvc.1.0.view", @"/Views/Materiel/Details.cshtml")]
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
#line 1 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41b9044ce5930e2dd8782f25aba3eefb332d7c62", @"/Views/Materiel/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e0bd676fd6529541b2fce84f1407bde3b504457", @"/Views/_ViewImports.cshtml")]
    public class Views_Materiel_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication8.Models.Materiel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Details</h1>\r\n<div>\r\n    <h4>Materiel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">Identifiant du Matériel</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 11 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.IdMat));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">Date d\'Affectation</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 14 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.DateAffectation));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">Description</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 17 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">Type de Matériel</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 20 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">État du Matériel</dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 24 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
             if (Model.Etat == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>En Marche</span>\r\n");
#nullable restore
#line 27 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>En Panne</span>\r\n");
#nullable restore
#line 31 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n        <dt class=\"col-sm-2\">Système d\'exploitation</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 35 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.SystemExp));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">Disponibilité</dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 39 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
             if (Model.disponibilite == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>Disponible</span>\r\n");
#nullable restore
#line 42 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>Non Disponible</span>\r\n");
#nullable restore
#line 46 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n     \r\n        <dt class=\"col-sm-2\">Marque du Matériel</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 51 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.marque));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n\r\n        <dt class=\"col-sm-2\">Identifiant du Bon d\'Entrée</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 55 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.idBonDentree));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n        <dt class=\"col-sm-2\">Code Fiscal du Fournisseur</dt>\r\n        <dd class=\"col-sm-10\"> ");
#nullable restore
#line 58 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                          Write(Html.DisplayFor(model => model.codefiscale));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </dd>\r\n\r\n       \r\n    </dl>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41b9044ce5930e2dd8782f25aba3eefb332d7c629397", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41b9044ce5930e2dd8782f25aba3eefb332d7c6210562", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\hamza\source\repos\WebApplication8\WebApplication8\Views\Materiel\Details.cshtml"
                           WriteLiteral(Model.IdMat);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication8.Models.Materiel> Html { get; private set; }
    }
}
#pragma warning restore 1591
