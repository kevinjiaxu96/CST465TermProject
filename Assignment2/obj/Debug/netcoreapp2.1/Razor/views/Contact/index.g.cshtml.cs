#pragma checksum "/Users/kevjxu/Projects/CST465/Assignment2/views/Contact/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70a6fd352b7b586a8c3b1b612dcf764cd2d7f379"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.views_Contact_index), @"mvc.1.0.view", @"/views/Contact/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/views/Contact/index.cshtml", typeof(AspNetCore.views_Contact_index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70a6fd352b7b586a8c3b1b612dcf764cd2d7f379", @"/views/Contact/index.cshtml")]
    public class views_Contact_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Assignment2.Models.Person>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("scripts", async() => {
                BeginContext(51, 148, true);
                WriteLiteral("\n    <script type=\"text/javascript\">\n        window.onload = function() {\n            $(\"#nav-contact\").addClass(\"active\");\n        }\n    </script>\n");
                EndContext();
            }
            );
#line 10 "/Users/kevjxu/Projects/CST465/Assignment2/views/Contact/index.cshtml"
 using(Html.BeginForm("SubmitForm", "Contact", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(268, 784, true);
            WriteLiteral(@"    <div class=""form-group"">
        <label for=""Name"">Name</label>
        <input type=""text"" class=""form-control"" id=""Name"" name=""Name"" placeholder=""Name"">
    </div>
    <div class=""form-group"">
        <label for=""Phonenumber"">Phone Number</label>
        <input type=""text"" class=""form-control"" name=""PhoneNumber"" id=""Phonenumber"" placeholder=""Phone #"">
    </div>
    <div class=""form-group"">
        <label for=""Email"">Email</label>
        <input type=""email"" class=""form-control"" name=""Email"" id=""Email"" placeholder=""Email"">
    </div>
    <div class=""form-group"">
        <label for=""Message"">Message</label>
        <textarea class=""form-control"" rows=""5"" name=""Message"" id=""Message""></textarea>
    </div>
    <button type=""submit"" class=""btn btn-primary"">Submit</button>
");
            EndContext();
#line 29 "/Users/kevjxu/Projects/CST465/Assignment2/views/Contact/index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Assignment2.Models.Person> Html { get; private set; }
    }
}
#pragma warning restore 1591