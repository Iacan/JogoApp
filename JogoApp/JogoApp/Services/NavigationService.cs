using JogoApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAddJogo()
        {
            await JogoApp.App.Current.MainPage.Navigation.PushAsync(new AddJogo());
        }

        public async Task NavigateToDetailsPage(int ID)
        {
            await JogoApp.App.Current.MainPage.Navigation.PushAsync(new DetailsPage(ID));
        }

        public async Task NavigateToJogoLista()
        {
            await JogoApp.App.Current.MainPage.Navigation.PushAsync(new JogoLista());
        }

        public async void PopAsyncService()
        {
            await JogoApp.App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
