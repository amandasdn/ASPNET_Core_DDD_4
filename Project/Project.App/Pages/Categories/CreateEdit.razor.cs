using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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

                if(CategoryObj.Removed)
                    NavManager.NavigateTo("/categories");
            }
        }

        public async Task OnSave(EditContext ec)
        {
            if (ec.Validate())
            {
                if (IsEdit)
                    await _serviceCategory.UpdateAsync(CategoryObj);
                else
                    await _serviceCategory.SaveAsync(CategoryObj);

                NavManager.NavigateTo("/categories");
            }
        }

        public async Task OnRemove()
        {
            await _serviceCategory.RemoveAsync(CategoryObj);

            NavManager.NavigateTo("/categories");
        }
    }
}
