#pragma checksum "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0115174674626ff6f1a6e0ff0503f002cd428a5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\_ViewImports.cshtml"
using WebRock;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\_ViewImports.cshtml"
using WebRock.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0115174674626ff6f1a6e0ff0503f002cd428a5f", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96440a4d1d731b57d7d363fe05ce98259e3bd978", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebRock.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-square form-control btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:50px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 35, "\"", 43, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f5401", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0115174674626ff6f1a6e0ff0503f002cd428a5f5667", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 4 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <div class=""container backgroundWhite pt-4"">
            <div class=""card"" style=""border:1px solid #000000;"">
                <div class=""card-header bg-dark text-light ml-0 row container"" style=""border-radius: 0px;"">
                    <div class=""col-12 col-md-6"">
                        <h1 class=""text-white"">
                            ");
#nullable restore
#line 10 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </h1>\r\n                    </div>\r\n                    <div class=\"col-12 col-md-6 text-md-right\">\r\n                        <h1 class=\"text-warning\">");
#nullable restore
#line 14 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                                            Write(Model.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h1>
                    </div>
                </div>
                <div class=""card-body"">
                    <div class=""container rounded p-2"">
                        <div class=""row"">
                            <div class=""col-12 col-lg-4 p-1 text-center"">
                                <img");
                BeginWriteAttribute("src", " src=\"", 985, "\"", 1016, 2);
#nullable restore
#line 21 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 991, WC.ImagePath, 991, 13, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 1004, Model.Image, 1004, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" width=""100%"" class=""rounded"" />
                            </div>
                            <div class=""col-12 col-lg-8"">
                                <div class=""row pl-3"">
                                    <div class=""col-12"">
                                        <span class=""badge p-3 border"" style=""background-color:lavenderblush"">");
#nullable restore
#line 26 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                                                                                                         Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        <span class=\"badge p-3 border\" style=\"background-color:azure\">");
#nullable restore
#line 27 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                                                                                                 Write(Model.Types.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                        <h3 class=\"text-success\"></h3>\r\n                                        <p class=\"text-secondary\">");
#nullable restore
#line 29 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                                                             Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""card-footer bg-dark"">
                    <div class=""row"">
                        <div class=""col-12 col-md-6 pb-1"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f11271", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n");
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span class=""ti-close"" aria-hidden=""true""></span></button>
            </div>
            <div class=""modal-body"">
                <div class=""row no-gutters"">
                    <div class=""col-lg-6 col-md-12 col-sm-12 col-xs-12"">
                        <!-- Product Slider -->
                        <div class=""product-gallery"">
                            <div class=""quickview-slider-active"">
                                <div class=""single-slider"">
                                    <img");
            BeginWriteAttribute("src", " src=\"", 3811, "\"", 3842, 2);
#nullable restore
#line 73 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 3817, WC.ImagePath, 3817, 13, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 3830, Model.Image, 3830, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"#\">\r\n                                </div>\r\n                                <div class=\"single-slider\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 3995, "\"", 4026, 2);
#nullable restore
#line 76 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 4001, WC.ImagePath, 4001, 13, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
WriteAttributeValue("", 4014, Model.Image, 4014, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"#\">\r\n                                </div>\r\n");
            WriteLiteral(@"                            </div>
                        </div>
                        <!-- End Product slider -->
                    </div>
                    <div class=""col-lg-6 col-md-12 col-sm-12 col-xs-12"">
                        <div class=""quickview-content"">
                            <h2>");
#nullable restore
#line 90 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                            <div class=""quickview-ratting-review"">
                                <div class=""quickview-ratting-wrap"">
                                    <div class=""quickview-ratting"">
                                        <i class=""yellow fa fa-star""></i>
                                        <i class=""yellow fa fa-star""></i>
                                        <i class=""yellow fa fa-star""></i>
                                        <i class=""yellow fa fa-star""></i>
                                        <i class=""fa fa-star""></i>
                                    </div>
                                    <a href=""#""> (1 customer review)</a>
                                </div>
                                <div class=""quickview-stock"">
                                    <span><i class=""fa fa-check-circle-o""></i> in stock</span>
                                </div>
                            </div>
                            <h3>");
#nullable restore
#line 106 "F:\LAN\HOCTAP\test1\WebRock\WebRock\Views\Home\Details.cshtml"
                           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                            <div class=""quickview-peragraph"">
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Mollitia iste laborum ad impedit pariatur esse optio tempora sint ullam autem deleniti nam in quos qui nemo ipsum numquam.</p>
                            </div>
                            <div class=""size"">
                                <div class=""row"">

                                    <div class=""col-lg-6 col-12"">
                                        <h5 class=""title"">Color</h5>
                                        <select>
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f18674", async() => {
                WriteLiteral("orange");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f19760", async() => {
                WriteLiteral("purple");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f20763", async() => {
                WriteLiteral("black");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0115174674626ff6f1a6e0ff0503f002cd428a5f21765", async() => {
                WriteLiteral("pink");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class=""quantity"">
                                <!-- Input Order -->
                                <div class=""input-group"">
                                    <div class=""button minus"">
                                        <button type=""button"" class=""btn btn-primary btn-number"" disabled=""disabled"" data-type=""minus"" data-field=""quant[1]"">
                                            <i class=""ti-minus""></i>
                                        </button>
                                    </div>
                                    <input type=""text"" name=""quant[1]"" class=""input-number"" data-min=""1"" data-max=""1000"" value=""1"">
                                    <div class=""button plus"">
                                        <button type=""button"" class=""btn btn-primary btn-number"" data-");
            WriteLiteral(@"type=""plus"" data-field=""quant[1]"">
                                            <i class=""ti-plus""></i>
                                        </button>
                                    </div>
                                </div>
                                <!--/ End Input Order -->
                            </div>
                            <div class=""add-to-cart"">
                                <a href=""#"" class=""btn"">Add to cart</a>
                                <a href=""#"" class=""btn min""><i class=""ti-heart""></i></a>
                                <a href=""#"" class=""btn min""><i class=""fa fa-compress""></i></a>
                            </div>
                            <div class=""default-social"">
                                <h4 class=""share-now"">Share:</h4>
                                <ul>
                                    <li><a class=""facebook"" href=""#""><i class=""fa fa-facebook""></i></a></li>
                                    <li><a class=""twitter"" href=""#");
            WriteLiteral(@"""><i class=""fa fa-twitter""></i></a></li>
                                    <li><a class=""youtube"" href=""#""><i class=""fa fa-pinterest-p""></i></a></li>
                                    <li><a class=""dribbble"" href=""#""><i class=""fa fa-google-plus""></i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebRock.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
