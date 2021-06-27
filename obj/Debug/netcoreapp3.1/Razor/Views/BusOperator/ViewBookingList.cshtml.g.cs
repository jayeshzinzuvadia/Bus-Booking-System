#pragma checksum "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3121003284d9a42262f8b7b1ee14f5ae570dafde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BusOperator_ViewBookingList), @"mvc.1.0.view", @"/Views/BusOperator/ViewBookingList.cshtml")]
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
#line 1 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.ViewModels.Passenger;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.ViewModels.BusOperator;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\_ViewImports.cshtml"
using BusBookingSystem.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3121003284d9a42262f8b7b1ee14f5ae570dafde", @"/Views/BusOperator/ViewBookingList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b9ad1f32cd8b076c5c3e6768d7ea787cfcddcdd", @"/Views/_ViewImports.cshtml")]
    public class Views_BusOperator_ViewBookingList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BusBookingListViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewPassengerCheckList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BusOperator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
  
    ViewBag.Title = "View Booking List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"text-center mt-3\">");
#nullable restore
#line 7 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                        Write(ViewBag.BusName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Bus</h2>\r\n<h4 class=\"text-center\">");
#nullable restore
#line 8 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(ViewBag.RouteSequence);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<h5 class=\"text-center\">");
#nullable restore
#line 9 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(ViewBag.BusTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n<hr class=\"bg-danger\" />\r\n\r\n<div class=\"text-light mb-3\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3121003284d9a42262f8b7b1ee14f5ae570dafde6555", async() => {
                WriteLiteral("View Passenger Check List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n<!--Booked Passenger Info List-->\r\n");
#nullable restore
#line 17 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center mb-3""><h5>Upcoming Passengers' List</h5></div>
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Seat No.</th>
                <th>Passenger Name</th>
                <th>Gender</th>
                <th>Age</th>
                <th>Source</th>
                <th>Destination</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 32 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
             for (int id = 0; id < Model.Count; id++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 35 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Passenger.PSeatNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Passenger.PName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Passenger.PGender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 38 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Passenger.PAge);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 39 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Source);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 40 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
                   Write(Model[id].Destination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 42 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 45 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header text-danger\">\r\n            Booking List is empty\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 53 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\BusOperator\ViewBookingList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BusBookingListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
