#pragma checksum "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61ee84605c67987131fd32bd34ca55987b39a16c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ViewBusRouteList), @"mvc.1.0.view", @"/Views/Admin/ViewBusRouteList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61ee84605c67987131fd32bd34ca55987b39a16c", @"/Views/Admin/ViewBusRouteList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b9ad1f32cd8b076c5c3e6768d7ea787cfcddcdd", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ViewBusRouteList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BusRouteListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewBusList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewBusRoute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateBusRoute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveBusRoute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
  
    ViewBag.Title = "View Bus Route List";
    var busRoute = Model.BusRouteList;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61ee84605c67987131fd32bd34ca55987b39a16c8178", async() => {
                WriteLiteral("Back");
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
            WriteLiteral("\r\n\r\n<!--BusRouteList starts-->\r\n<h2 class=\"text-center mt-1\">Bus Route List of ");
#nullable restore
#line 11 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                          Write(Model.Bus.BusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h4 class=\"text-center\">");
#nullable restore
#line 12 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(Model.Bus.RouteSequence);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<hr class=\"bg-danger\" />\r\n\r\n<div class=\"row mt-3\">\r\n    <div class=\"col\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61ee84605c67987131fd32bd34ca55987b39a16c10363", async() => {
                WriteLiteral("\r\n            Add New Route\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-busId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                WriteLiteral(Context.Request.Query["busId"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-busId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 26 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
 if (ViewBag.TotalNoOfBusRoutes > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row mb-3\">\r\n        <div class=\"col font-weight-bold\">\r\n            Total Bus Routes : ");
#nullable restore
#line 30 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                          Write(ViewBag.TotalNoOfBusRoutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
    <table class=""table table-hover"">
        <thead>
            <tr>
                <th>Route Order</th>
                <th>Source</th>
                <th>Destination</th>
                <th>Departure Time</th>
                <th>Arrival Time</th>
                <th>Ticket Price</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 46 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
             for (int id = 0; id < ViewBag.TotalNoOfBusRoutes; id++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 49 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(busRoute[id].RouteOrder);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(busRoute[id].Source);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 51 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(busRoute[id].Destination);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(busRoute[id].DepartureTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 53 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                   Write(busRoute[id].ArrivalTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                    \r\n                    <td><i class=\"fa fa-rupee\"></i> ");
#nullable restore
#line 54 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                               Write(busRoute[id].TicketPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <div class=\"row\">\r\n                            <div class=\"col\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61ee84605c67987131fd32bd34ca55987b39a16c16285", async() => {
                WriteLiteral("\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61ee84605c67987131fd32bd34ca55987b39a16c16580", async() => {
                    WriteLiteral("\r\n                                        Update\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-busRouteId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                                 WriteLiteral(busRoute[id].BusRouteId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busRouteId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-busRouteId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busRouteId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                            WriteLiteral(busRoute[id].BusId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-busId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["busId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    <button type=\"button\" class=\"btn btn-outline-danger\" data-toggle=\"modal\" data-target=\"#exampleModal_");
#nullable restore
#line 64 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                                                                                                                   Write(id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">\r\n                                        Remove\r\n                                    </button>\r\n                                    <!-- Modal -->\r\n                                    <div class=\"modal fade\"");
                BeginWriteAttribute("id", " id=\"", 2809, "\"", 2830, 2);
                WriteAttributeValue("", 2814, "exampleModal_", 2814, 13, true);
#nullable restore
#line 68 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
WriteAttributeValue("", 2827, id, 2827, 3, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" tabindex=\"-1\" role=\"dialog\"");
                BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 2859, "\"", 2898, 2);
                WriteAttributeValue("", 2877, "exampleModalLabel_", 2877, 18, true);
#nullable restore
#line 68 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
WriteAttributeValue("", 2895, id, 2895, 3, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" aria-hidden=""true"">
                                        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                                            <div class=""modal-content"">
                                                <div class=""modal-header"">
                                                    <h5 class=""modal-title""");
                BeginWriteAttribute("id", " id=\"", 3251, "\"", 3277, 2);
                WriteAttributeValue("", 3256, "exampleModalLabel_", 3256, 18, true);
#nullable restore
#line 72 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
WriteAttributeValue("", 3274, id, 3274, 3, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Remove Bus Route</h5>
                                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                        <span aria-hidden=""true"">&times;</span>
                                                    </button>
                                                </div>
                                                <div class=""modal-body"">
                                                    Are you sure you want to remove this bus route and delete all the data?
                                                </div>
                                                <div class=""modal-footer"">
                                                    <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Close</button>
                                                    <button type=""submit"" class=""btn btn-danger"">Remove</button>
                                                </div>
                   ");
                WriteLiteral("                         </div>\r\n                                        </div>\r\n                                    </div>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-busRouteId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
                                                                                                   WriteLiteral(busRoute[id].BusRouteId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["busRouteId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-busRouteId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["busRouteId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 92 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 95 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header text-danger\">\r\n            Bus Route List is empty\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 103 "F:\ENGINEERING\SEM_5\WDDN\Project\BusBookingSystem\Views\Admin\ViewBusRouteList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BusRouteListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
