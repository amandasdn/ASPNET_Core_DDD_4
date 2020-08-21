using Microsoft.AspNetCore.Components;
using Project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.Shared
{
    public class MainBase : ComponentBase
    {
        protected internal CategoriesService _service { get; set; }
    }
}
