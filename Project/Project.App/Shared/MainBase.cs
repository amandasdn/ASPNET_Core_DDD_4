﻿using Microsoft.AspNetCore.Components;
using Project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.App.Shared
{
    public class MainBase : ComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }

        [Inject] public CategoryService ServiceCategory { get; set; }

        [Inject] public ProductService ServiceProduct { get; set; }
    }
}
