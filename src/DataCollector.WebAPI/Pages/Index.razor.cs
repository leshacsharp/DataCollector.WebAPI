using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using DataCollector.WebAPI.Models.Interfaces;
using DataCollector.WebAPI.Models.Api;
using DataCollector.WebAPI.Models.Dto;

namespace DataCollector.WebAPI.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        public List<UserDto> Users { get; set; }

        private UserFilterModel Filter { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Filter = new UserFilterModel();
            Filter.CommonInfo.WithoutAge = true;
            Users = await UserService.GetAsync(Filter);
        }

        public async Task GetUsersAsync()
        {
            Users = await UserService.GetAsync(Filter);
        }

        MatTheme theme1 = new MatTheme()
        {
            Primary = "#12E6E6"
        };
        private bool collapseNavMenu = true;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
