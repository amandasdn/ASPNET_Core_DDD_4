using Microsoft.AspNetCore.Components;
using Project.App.Shared;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.Pages.Categories
{
    public class CreateEditModel : MainBase
    {
        public Category CategoryObj = new Category();

        [Parameter] public Guid CategoryId { get; set; }

        public bool IsEdit;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if(CategoryId != Guid.Empty) IsEdit = true;

            if(IsEdit)
            {
                CategoryObj = await _serviceCategory.FindByIdAsync(CategoryId);
            }
        }

        public async Task OnSave()
        {
            await _serviceCategory.SaveAsync(CategoryObj);

            NavManager.NavigateTo("/categories");
        }
    }
}
