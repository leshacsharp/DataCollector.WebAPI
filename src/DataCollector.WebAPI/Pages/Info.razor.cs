using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
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


        private MatTheme theme = new MatTheme() { Primary = "#12E6E6" };
        private bool collapseNavMenu = true;
        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
