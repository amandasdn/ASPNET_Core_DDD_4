using Project.App.Shared;
using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.Pages.Products
{
    public class IndexModel : MainBase
    {
        public IEnumerable<Product> ProductsList;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ProductsList = await ServiceProduct.ListAllAsync();
        }
    }
}
