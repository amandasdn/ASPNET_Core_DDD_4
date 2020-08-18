using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Services;

namespace Project.App.Pages.Categories
{
    public class IndexModel : ComponentBase
    {
        private CategoriesService _service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
