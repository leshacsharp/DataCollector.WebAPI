using DataCollector.WebAPI.Models.Api;
using DataCollector.WebAPI.Models.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.WebAPI.Components
{
    public partial class DownloadData : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public UserFilterModel Filter { get; set; }

        private int StartRecord { get; set; }

        private int CountRecords { get; set; }

        public async Task DownloadFileAsync()
        {
            Filter.From = StartRecord;
            Filter.Count = CountRecords;

            var users = await UserService.GetAsync(Filter);
            var userStrs = users.Select(u => $"Id={u.Id} FirstName={u.FirstName} LastName={u.LastName}");
            var joinedUsers = string.Join("\n", userStrs);
            var usersBase64 = Convert.ToBase64String(Encoding.Default.GetBytes(joinedUsers));

            await JSRuntime.InvokeAsync<object>("saveAsFile", "users.txt", usersBase64);
        }
    }
}
