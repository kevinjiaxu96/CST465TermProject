#pragma checksum "/Users/kevjxu/Projects/CST465/Assignment2/views/Home/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6260c6b4fd9f76bdfe009d26eda5c382b5415cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.views_Home_index), @"mvc.1.0.view", @"/views/Home/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/views/Home/index.cshtml", typeof(AspNetCore.views_Home_index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6260c6b4fd9f76bdfe009d26eda5c382b5415cc8", @"/views/Home/index.cshtml")]
    public class views_Home_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/kevjxu/Projects/CST465/Assignment2/views/Home/index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(38, 1, true);
            WriteLiteral("\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(57, 145, true);
                WriteLiteral("\n    <script type=\"text/javascript\">\n        window.onload = function() {\n            $(\"#nav-home\").addClass(\"active\");\n        }\n    </script>\n");
                EndContext();
            }
            );
            BeginContext(204, 1289, true);
            WriteLiteral(@"
<div class=""content-container"">
    <div class=""info-card-container"">
        <div class=""info-card"">
            <svg xmlns=""http://www.w3.org/2000/svg"" class=""my-info"">    
                <symbol id=""myName"">
                    <text text-anchor=""middle""
                        x=""50%""
                        y=""40%""
                        class=""name efirstname""
                        >
                    KEVIN
                    </text>
                    <text text-anchor=""middle""
                        x=""50%""
                        y=""65%""
                        class=""name lastname""
                        >
                    XU
                    </text>
                </symbol>
                <g>
                    <use xlink:href=""#myName""
                    class=""namestroke""></use>     
                    <use xlink:href=""#myName""
                    class=""namestroke""></use>     
                    <use xlink:href=""#myName""
                    class=""namestroke""></use>     
 ");
            WriteLiteral(@"                   <use xlink:href=""#myName""
                    class=""namestroke""></use>     
                    <use xlink:href=""#myName""
                    class=""namestroke""></use>     
                </g>
            </svg>
        </div>
    </div>
</div>");
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