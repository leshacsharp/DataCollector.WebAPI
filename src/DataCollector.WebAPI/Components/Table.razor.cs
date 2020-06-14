using DataCollector.WebAPI.Models.Dto;
using DataCollector.WebAPI.Models.Entities;
using DataCollector.WebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Components
{
    public partial class Table : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Parameter ]
        public List<UserDto> Users { get; set; }

        private User SelectedUser { get; set; }

        private bool DialogIsOpen { get; set; }

        public async Task SelectionChanged(object obj)
        {
            if (obj == null)
            {
                return;
            }
            else
            {
                var userDto = (UserDto)obj;
                SelectedUser = await UserService.GetByIdAsync(userDto.Id.ToString());
                DialogIsOpen = true;

                StateHasChanged();
            }
        }
    }
}
