#pragma checksum "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13f0ea657514d699949909b8097a4600ff20541f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Teletrabajo.Pages.Shared.Pages_Shared__SuccessErrorMessages), @"mvc.1.0.view", @"/Pages/Shared/_SuccessErrorMessages.cshtml")]
namespace Teletrabajo.Pages.Shared
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
#line 1 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\_ViewImports.cshtml"
using Teletrabajo;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13f0ea657514d699949909b8097a4600ff20541f", @"/Pages/Shared/_SuccessErrorMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"733f0e912d1e420ba92655d4c8cec1fe132775e3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__SuccessErrorMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
 if (Model.SuccessMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">\r\n        <p>");
#nullable restore
#line 4 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
      Write(Model.SuccessMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 6 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
 if (Model.ErrorMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">\r\n        <p>");
#nullable restore
#line 11 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
      Write(Model.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 13 "C:\Users\Fer\Desktop\Rama-s-Teletrabajo\Teletrabajo\Main\Source\Teletrabajo\Teletrabajo\Pages\Shared\_SuccessErrorMessages.cshtml"
}

#line default
#line hidden
#nullable disable
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
