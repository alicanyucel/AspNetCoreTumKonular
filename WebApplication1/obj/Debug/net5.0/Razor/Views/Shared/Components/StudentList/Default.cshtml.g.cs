#pragma checksum "C:\Users\ali\source\repos\WebApplication1\WebApplication1\Views\Shared\Components\StudentList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a881a8462aa19604abe7161246ef4fc6c0cc162"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_StudentList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/StudentList/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a881a8462aa19604abe7161246ef4fc6c0cc162", @"/Views/Shared/Components/StudentList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d89e8de4197c02b516bf7e12db63860ca0f5b478", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_StudentList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.StudentListViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ali\source\repos\WebApplication1\WebApplication1\Views\Shared\Components\StudentList\Default.cshtml"
 foreach (var students in Model.students)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 5 "C:\Users\ali\source\repos\WebApplication1\WebApplication1\Views\Shared\Components\StudentList\Default.cshtml"
Write(students.FirstName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ali\source\repos\WebApplication1\WebApplication1\Views\Shared\Components\StudentList\Default.cshtml"
                       ;
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.StudentListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
