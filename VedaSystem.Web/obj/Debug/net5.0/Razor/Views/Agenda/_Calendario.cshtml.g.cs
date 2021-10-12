#pragma checksum "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\Agenda\_Calendario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c42be9b9514cf58704c8108fc49efee645882237"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agenda__Calendario), @"mvc.1.0.view", @"/Views/Agenda/_Calendario.cshtml")]
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
#line 1 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\_ViewImports.cshtml"
using VedaSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\_ViewImports.cshtml"
using VedaSystem.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\Agenda\_Calendario.cshtml"
using VedaSystem.Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\Agenda\_Calendario.cshtml"
using VedaSystem.Web.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\Agenda\_Calendario.cshtml"
using VedaSystem.Domain.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\prodi\Documents\Projetos\VedaSystemProject\VedaSystem.Web\Views\Agenda\_Calendario.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c42be9b9514cf58704c8108fc49efee645882237", @"/Views/Agenda/_Calendario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e304bc72dd3cdf895a5f0078544ed7e2bf075e58", @"/Views/_ViewImports.cshtml")]
    public class Views_Agenda__Calendario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VedaSystem.Application.ViewModels.CalendarioViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""page-header border-0 mb-3"">
    <h1 class=""page-title text-primary-d2 text-150"">
        Calendário
        <small class=""page-info text-secondary-d4"">
            <i class=""fa fa-angle-double-right text-80 opacity-1""></i>
            Agendamentos
        </small>
    </h1>
</div>
<div id=""alert-1"" class=""d-none alert bgc-white border-l-4 brc-purple-m1 shadow-sm"" role=""alert"">
    Toque em um slot de data e mantenha pressionado para adicionar um novo evento.
</div>
<div class=""row"">
    <div class=""col-12 col-md-9"" id='calendar-container'>
        <div class=""card acard"">
            <div class=""card-body p-lg-4"">
                <div id='calendar' class=""text-blue-d1""></div>
            </div>
        </div>
    </div>
    <div class=""col-12 col-md-3 mt-3 mt-md-4"" id='external-events'>
        <div class=""bgc-secondary-l4 border-1 brc-secondary-l2 shadow-sm p-35 radius-1"">
            <p class=""text-120 text-primary-d2"">
                Eventos arrastaveis
            </p>");
            WriteLiteral(@"

            <p id=""alert-2"" class=""alert bgc-white border-none border-l-4 brc-purple-m1"">
                Arraste e solte os eventos a seguir ou clique em um slot de data para adicionar um novo evento
            </p>

            <div>
                <div class='fc-event badge bgc-blue-d1 text-white border-0 py-2 text-90 mb-1 radius-2px' data-class=""bgc-blue-d1 text-white text-95"">
                    Meu Evento 1
                </div>
                <div class='fc-event badge bgc-green-d2 text-white border-0 py-2 text-90 mb-1 radius-2px' data-class=""bgc-green-d2 text-white text-95"">
                    Meu Evento 2
                </div>
                <div class='fc-event badge bgc-red-d1 text-white border-0 py-2 text-90 mb-1 radius-2px' data-class=""bgc-red-d1 text-white text-95"">
                    Meu Evento 3
                </div>
                <div class='fc-event badge bgc-purple-d1 text-white border-0 py-2 text-90 mb-1 radius-2px' data-class=""bgc-purple-d1 text-white text-95");
            WriteLiteral(@""">
                    Meu Evento 4
                </div>
                <div class='fc-event badge bgc-orange-d1 text-white border-0 py-2 text-90 mb-1 radius-2px' data-class=""bgc-orange-d1 text-white text-95"">
                    Meu Evento 5
                </div>
            </div>

            <label class=""mt-2"">
                <input type=""checkbox"" id='drop-remove' class=""mr-1"" />
                Remover depois do uso
            </label>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VedaSystem.Application.ViewModels.CalendarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
