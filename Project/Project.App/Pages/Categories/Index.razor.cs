using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Service.Services;
using Project.Domain.Models;
using Project.App.Shared;

namespace Project.App.Pages.Categories
{
    public class IndexModel : MainBase
    {
        public List<Category> CategoriesList;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            CategoriesList = await _serviceCategory.ListAllAsync();
        }

    }
}
