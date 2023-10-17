using Blazored.LocalStorage;
using IsbaSatisBlazor.Client.Pages.Users;
using IsbaSatisBlazor.Client.Utils;
using IsbaSatisBlazor.Shared.CustomExceptions;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace IsbaSatisBlazor.Client.Pages.PageProcess
{
    public class ProductGroupListProcess : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        ModalManager ModalManager { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        ILocalStorageService localStorageService { get; set; }

        protected IEnumerable<ProductGroupDTO> ProductGroupList;
        protected async override Task OnInitializedAsync()
        {
            await LoadList();
        }
        protected async Task LoadList()
        {
            try
            {
                string token = await localStorageService.GetItemAsStringAsync("token");
                ProductGroupList = await Client.GetServiceResponseAsync<List<ProductGroupDTO>>("api/productgroup/productgroups", token, true);
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("Api Exception", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("Exception", ex.Message);
            }
        }
        protected void goCreateUserPage()
        {
            NavigationManager.NavigateTo("/productgroups/add");
        }

        protected void goUpdateUserPage(Guid ProductGroupId)
        {
            NavigationManager.NavigateTo("/productgroups/edit/" + ProductGroupId);
        }

        protected async Task DeleteUser(Guid Id)
        {
            bool confirmed = await ModalManager.ConfirmationAsync("Confirmation", "User will be deleted. Are you sure?");

            if (!confirmed) return;

            try
            {
                string token = await localStorageService.GetItemAsStringAsync("token");
                bool deleted = await Client.PostGetServiceResponseAsync<bool, Guid>("api/User/Delete", Id, token, true);

                await LoadList();
            }
            catch (ApiException ex)
            {
                await ModalManager.ShowMessageAsync("User Deletion Error", ex.Message);
            }
            catch (Exception ex)
            {
                await ModalManager.ShowMessageAsync("An Error", ex.Message);
            }
        }

    }
}
