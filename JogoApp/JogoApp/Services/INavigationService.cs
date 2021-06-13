using System.Threading.Tasks;

namespace JogoApp.Services
{
    public interface INavigationService 
    {
        Task NavigateToAddJogo();
        Task NavigateToDetailsPage(int ID);
        Task NavigateToJogoLista();
        void PopAsyncService();
    }
}
