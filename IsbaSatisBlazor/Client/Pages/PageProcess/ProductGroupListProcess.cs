using Blazored.LocalStorage;
using IsbaSatisBlazor.Client.Utils;
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
    }
}
