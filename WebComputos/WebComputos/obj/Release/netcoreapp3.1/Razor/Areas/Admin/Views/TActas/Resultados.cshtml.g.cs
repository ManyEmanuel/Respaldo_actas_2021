#pragma checksum "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d484d8cbc165bb5b86f1b8fd00a882d320a0c81d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TActas_Resultados), @"mvc.1.0.view", @"/Areas/Admin/Views/TActas/Resultados.cshtml")]
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
#line 1 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\_ViewImports.cshtml"
using WebComputos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\_ViewImports.cshtml"
using WebComputos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d484d8cbc165bb5b86f1b8fd00a882d320a0c81d", @"/Areas/Admin/Views/TActas/Resultados.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2673f04ad96dad8b737105e95647700b133d2894", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TActas_Resultados : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<WebComputos.Models.TResultadosActas>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Resultados.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
  
    IEnumerable<TPartidos> Lpar = ViewBag.partido;
    IEnumerable<Combinaciones> Lcom = ViewBag.combinacion;
    IEnumerable<TResultadosActas> Lres = ViewBag.Resact;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n\r\n<!--Resultados-->\r\n");
#nullable restore
#line 12 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
 if (Lpar.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d484d8cbc165bb5b86f1b8fd00a882d320a0c81d5186", async() => {
                WriteLiteral("\r\n        <h2 class=\"text-center\">Partidos</h2>\r\n        <br />\r\n        <br />\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 21 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contador = 0;
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 25 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var Resultado in Model)
            {
                if (Resultado.IdPartido != 0)
                {
                    var partido = Lpar.FirstOrDefault(x => x.IdPartido == Resultado.IdPartido);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-md-3\">\r\n                        <div class=\"row\">\r\n                            <div class=\"col-md-4\"> </div>\r\n                            <div class=\"col-md-4\">\r\n");
#nullable restore
#line 34 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                 if (partido.Siglas == "MORENA")
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p class=\"text-center\"> <img");
                BeginWriteAttribute("src", " src=\"", 1164, "\"", 1199, 1);
#nullable restore
#line 36 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
WriteAttributeValue("", 1170, Url.Content(partido.LogoURL), 1170, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"50\" height=\"25\" /> </p>\r\n");
#nullable restore
#line 37 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p class=\"text-center\"> <img");
                BeginWriteAttribute("src", " src=\"", 1405, "\"", 1440, 1);
#nullable restore
#line 40 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
WriteAttributeValue("", 1411, Url.Content(partido.LogoURL), 1411, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"50\" height=\"50\" /> </p>\r\n");
#nullable restore
#line 41 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <p class=\"text-center\"> ");
#nullable restore
#line 42 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                                       Write(Html.TextBoxFor(x => x[contador].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-md-4\"> </div>\r\n\r\n                            ");
#nullable restore
#line 46 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                       Write(Html.HiddenFor(x => x[contador].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 47 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                       Write(Html.HiddenFor(x => x[contador].IdPartido));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 48 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                       Write(Html.HiddenFor(x => x[contador].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            \r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 52 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"

                }
                contador++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <br />\r\n        <br />\r\n        <h2 class=\"text-center\">Coaliciones</h2>\r\n        <br />\r\n        <br />\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 63 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contador1 = 0;
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 67 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var Combi in Model)
            {
                if (Combi.IdCombinacion != 0)
                {
                    var coalicion = Lcom.FirstOrDefault(x => x.idCombinacion == Combi.IdCombinacion);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""col-md-3"">
                        <div class=""row"">
                            <div class=""col-md-4""> </div>
                            <div class=""col-md-4"">
                                <p class=""text-center"">
                                    <img");
                BeginWriteAttribute("src", " src=\"", 2919, "\"", 2956, 1);
#nullable restore
#line 77 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
WriteAttributeValue("", 2925, Url.Content(coalicion.LogoURL), 2925, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"50\" height=\"50\" />\r\n                                </p>\r\n                                <p class=\"text-center\">\r\n                                    ");
#nullable restore
#line 80 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                               Write(Html.Label(coalicion.Combinacion));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </p>\r\n                                <p class=\"text-center\">");
#nullable restore
#line 82 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                                  Write(Html.TextBoxFor(x => x[contador1].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                                ");
#nullable restore
#line 84 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           Write(Html.HiddenFor(x => x[contador1].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 85 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           Write(Html.HiddenFor(x => x[contador1].IdCombinacion));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 86 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           Write(Html.HiddenFor(x => x[contador1].IdCoalicion));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 87 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           Write(Html.HiddenFor(x => x[contador1].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                            </div>\r\n                            <div class=\"col-md-4\"> </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 93 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                }
                contador1++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <br />\r\n        <br />\r\n        <h2 class=\"text-center\">Candidatos Independientes</h2>\r\n        <br />\r\n        <br />\r\n\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 104 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contador2 = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var Inde in Model)
            {
                if (Inde.IdIndependiente != 0)
                {
                    var coalicion = Lpar.FirstOrDefault(x => x.Independiente == true && x.IdPartido == Inde.IdIndependiente);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""col-md-3"">
                        <div class=""row"">
                            <div class=""col-md-4""> </div>
                            <div class=""col-md-4"">
                                <p class=""text-center"">
                                    <img");
                BeginWriteAttribute("src", " src=\"", 4704, "\"", 4741, 1);
#nullable restore
#line 117 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
WriteAttributeValue("", 4710, Url.Content(coalicion.LogoURL), 4710, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"50\" height=\"50\" /> </p>\r\n                                <p class=\"text-center\">   \r\n                                ");
#nullable restore
#line 119 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           Write(Html.Label(coalicion.Siglas));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                                    ");
#nullable restore
#line 121 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                               Write(Html.HiddenFor(x => x[contador2].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 122 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                               Write(Html.HiddenFor(x => x[contador2].IdIndependiente));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                    ");
#nullable restore
#line 124 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                               Write(Html.HiddenFor(x => x[contador2].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <p class=\"text-center\"> ");
#nullable restore
#line 125 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                                   Write(Html.TextBoxFor(x => x[contador2].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                            </div>\r\n                            <div class=\"col-md-4\"> </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 130 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                }
                contador2++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n\r\n        <br />\r\n        <br />\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 138 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contnor = 0;
            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 142 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var nor in Model)
            {
                if (nor.NoRegistrados != 0)
                {
                    var nul = Lres.FirstOrDefault(x => x.NoRegistrados == nor.NoRegistrados);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-md-3\">\r\n                        <p class=\"text-center\">Candidatos no registrados</p>\r\n                   \r\n                        ");
#nullable restore
#line 150 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnor].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 151 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnor].NoRegistrados));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 152 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnor].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <p class=\"text-center\">\r\n                        ");
#nullable restore
#line 154 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.TextBoxFor(x => x[contnor].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </p>\r\n                     </div>\r\n");
#nullable restore
#line 157 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                }
                contnor++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 161 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contnul = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 164 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var nul in Model)
            {
                if (nul.Nulos != 0)
                {
                    var nulo = Lres.FirstOrDefault(x => x.Nulos == nul.Nulos);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-md-3\">\r\n                        <p class=\"text-center\">Votos nulos</p>\r\n                    \r\n                        ");
#nullable restore
#line 172 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnul].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 173 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnul].Nulos));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 174 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contnul].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <p class=\"text-center\">");
#nullable restore
#line 175 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                          Write(Html.TextBoxFor(x => x[contnul].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                     </div>\r\n");
#nullable restore
#line 177 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                }
                contnul++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 181 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
              
                int contot = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
             foreach (var tot in Model)
            {
                if (tot.Total != 0)
                {
                    var tota = Lres.FirstOrDefault(x => x.Total == tot.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-md-3\">\r\n                        <p class=\"text-center\">Total de votos</p>\r\n                    \r\n                        ");
#nullable restore
#line 192 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contot].IdResultadoActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 193 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contot].Total));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 194 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                   Write(Html.HiddenFor(x => x[contot].IdActa));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <p class=\"text-center\"> ");
#nullable restore
#line 195 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                                           Write(Html.TextBoxFor(x => x[contot].VotosRegistrados, new { @type = "number", @style = "text-align:center; width : 80px " }));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                    </div>\r\n");
#nullable restore
#line 197 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                }
                contot++;
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n\r\n        <input class=\"btn btn-success\" type=\"submit\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 210 "D:\Desktop\26Medianoche\WebComputos\WebComputos\Areas\Admin\Views\TActas\Resultados.cshtml"
                           





}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d484d8cbc165bb5b86f1b8fd00a882d320a0c81d27741", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<WebComputos.Models.TResultadosActas>> Html { get; private set; }
    }
}
#pragma warning restore 1591
