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

        private string _pageList = "/categories";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if(CategoryId != Guid.Empty) IsEdit = true;

            if(IsEdit)
            {
                CategoryObj = await ServiceCategory.FindByIdAsync(CategoryId);

                if(CategoryObj.Removed)
                    NavManager.NavigateTo(_pageList);
            }
        }

        public async Task OnSave(EditContext ec)
        {
            if (ec.Validate())
            {
                if (IsEdit)
                    await ServiceCategory.UpdateAsync(CategoryObj);
                else
                    await ServiceCategory.SaveAsync(CategoryObj);

                NavManager.NavigateTo(_pageList);
            }
        }

        public async Task OnRemove()
        {
            await ServiceCategory.RemoveAsync(CategoryObj);

            NavManager.NavigateTo(_pageList);
        }
    }
}
