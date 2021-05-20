#pragma checksum "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e38d3d4f7980d2546216af519160d776d15e735"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Profile), @"mvc.1.0.view", @"/Views/Profile/Profile.cshtml")]
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
#line 1 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/_ViewImports.cshtml"
using Postter.Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/_ViewImports.cshtml"
using Postter.Presentation.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
using Postter.Application.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e38d3d4f7980d2546216af519160d776d15e735", @"/Views/Profile/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1799c87cb7b204290fa820558d766beccdab65c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
  
    ViewData["Title"] = Model.CurrentUser.UserName;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"postter-box\">\n    <img class=\"profile-background-img\" src=\"https://i.pinimg.com/originals/a6/e8/1b/a6e81b2bb0685ebab1d7b2f15283b7e4.jpg\">\n");
#nullable restore
#line 10 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
     if (Model.IsCurrentUser)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"d-flex justify-content-end pt-3 pr-3\">\n            <button class=\"postter-button\">Edit</button>\n        </div>\n");
#nullable restore
#line 15 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"d-flex flex-column\">\n        <div class=\"ml-3 pb-2\" style=\"margin-top: -130px\">\n            <img class=\"avatar-img-lg\"");
            BeginWriteAttribute("src", "\n                 src=\"", 578, "\"", 630, 1);
#nullable restore
#line 19 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
WriteAttributeValue("", 601, Model.CurrentUser.Image_path, 601, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        </div>\n        <div class=\"pl-3\">\n            <div class=\"semi-bold-text\" style=\"font-weight: bold; font-size: 22px;\">");
#nullable restore
#line 22 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                                                               Write(Model.CurrentUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        </div>\n        <div class=\"pl-3\">\n            <div class=\"secondary-text\">user</div>\n        </div>\n        <div class=\"d-flex align-items-center pl-3 py-3\">\n            <div class=\"semi-bold-text\">");
#nullable restore
#line 28 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                   Write(Model.CurrentUser.Followers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n            <div class=\"secondary-text pl-2\">followers</div>\n            <div class=\"semi-bold-text pl-3\">");
#nullable restore
#line 30 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                        Write(Model.CurrentUser.Following.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <div class=""secondary-text pl-2"">following</div>
        </div>
    </div>
</div>
<div class=""postter-box"" id=""navbar"">
    <ul class=""nav semi-bold-text d-flex"" style=""font-size: 16px"">
        <li class=""nav-item flex-fill text-center align-items-center"">
            <a class=""nav-link active py-3"" href=""#"">Posts</a>
        </li>
        <li class=""nav-item flex-fill text-center"">
            <a class=""nav-link py-3 px-1"" href=""#"">Posts and replies</a>
        </li>
        <li class=""nav-item flex-fill text-center"">
            <a class=""nav-link py-3"" href=""#"">Media</a>
        </li>
        <li class=""nav-item flex-fill text-center"">
            <a class=""nav-link py-3"" href=""#"">Liked</a>
        </li>
    </ul>
</div>
<script>
        $(document).ready(function () {
            $(""#navbar"").on(""click"", "".nav-item"", function () {
                $("".nav .nav-item"").removeClass(""active"");
                $("".nav .nav-link"").removeClass(""active"");
                $(""#posts .tab"").remove");
            WriteLiteral(@"Class(""active"");

                $(this).addClass(""active"");
                $("".nav .nav-link"").eq($(this).index()).addClass(""active"");
                $(""#posts .tab"").eq($(this).index()).addClass(""active"");
            })
        })
    </script>
<div id=""posts"">
    <div class=""tab active"">
");
#nullable restore
#line 66 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
         foreach (var post in Model.CurrentUser.Posts)
        {
            if (post.ReplyTo == null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
           Write(await Html.PartialAsync("_Post", post));

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                                       
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <div class=\"tab\">\n");
#nullable restore
#line 75 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
         foreach (var post in Model.CurrentUser.Posts)
        {
            if (post.RepostFrom == null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
           Write(await Html.PartialAsync("_Post", post));

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                                       
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <div class=\"tab\">\n");
#nullable restore
#line 84 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
         foreach (var post in Model.CurrentUser.Posts)
        {
            if (post.AttachmentPath != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
           Write(await Html.PartialAsync("_Post", post));

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "/Users/ruslankhanov/Documents/IT/Postter/Postter.Presentation/Views/Profile/Profile.cshtml"
                                                       
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <div class=\"tab\">\n        AAAAAAAAAA\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
