using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.App.Components
{
    public class DataTableModel<T> : ComponentBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; }

        public ElementReference ElemRef = new ElementReference("datatable-" + Guid.NewGuid());

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            await JsRuntime.InvokeVoidAsync("setDataTable", ElemRef);
        }

        [Parameter] public RenderFragment<T> DataTableHeader { get; set; }

        [Parameter] public RenderFragment<T> DataTableBody { get; set; }

        [Parameter] public IEnumerable<T> Items { get; set; }
    }
}
