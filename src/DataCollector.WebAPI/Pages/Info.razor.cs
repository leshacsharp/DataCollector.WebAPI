using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Pages
{
    public partial class Info : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Parameter]
        public string UserId { get; set; }

        private User User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await UserService.GetByIdAsync(UserId);
        }
    }
}
