using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Project.App.Shared;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.Pages.Products
{
    public class CreateEditModel : MainBase
    {
        public Product ProductObj = new Product();

        [Parameter] public Guid ProductId { get; set; }

        public bool IsEdit;

        private string _pageList = "/products";

        IEnumerable<Category> CategoriesIEnum;

        public Dictionary<Guid, string> CategoriesItems;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            CategoriesIEnum = await ServiceCategory.ListAllAsync();

            if(CategoriesIEnum.Count() > 0)
            {
                CategoriesItems = CategoriesIEnum.ToDictionary(item => item.Id, item => item.Name);
            }

            if (ProductId != Guid.Empty) IsEdit = true;

            if (IsEdit)
            {
                ProductObj = await ServiceProduct.FindByIdAsync(ProductId);

                if (ProductObj.Removed)
                    NavManager.NavigateTo(_pageList);
            }
        }

        public async Task OnSave(EditContext ec)
        {
            if (ec.Validate())
            {
                if (IsEdit)
                    await ServiceProduct.UpdateAsync(ProductObj);
                else
                    await ServiceProduct.SaveAsync(ProductObj);

                NavManager.NavigateTo(_pageList);
            }
        }

        public async Task OnRemove()
        {
            await ServiceProduct.RemoveAsync(ProductObj);

            NavManager.NavigateTo(_pageList);
        }
    }
}
