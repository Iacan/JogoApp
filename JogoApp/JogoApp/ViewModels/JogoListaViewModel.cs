using JogoApp.Models;
using JogoApp.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JogoApp.ViewModels
{
    public class JogoListaViewModel : BaseJogoViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllJogosCommand { get; private set; }

        public JogoListaViewModel()
        {
            _JogoRepository = new JogoRepository();

            AddCommand = new Command(async () => await ExibirAddJogo());
            DeleteAllJogosCommand = new Command(async () => await DeleteAllJogos());

            EncontrarJogos();
        }

        void EncontrarJogos()
        {
            JogoLista = _JogoRepository.GetAllJogosData();
        }

        async Task ExibirAddJogo()
        {
            await _navigationService.NavigateToAddJogo();
        }

        async Task DeleteAllJogos()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Lista de Jogos", "Deletar todos os detalhes de Jogos ?", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _JogoRepository.DeleteAllJogos();
                await _navigationService.NavigateToAddJogo();
            }
        }

        async void ExibirJogoDetails(int selectedJogoID)
        {
            await _navigationService.NavigateToDetailsPage(selectedJogoID);
        }

        Jogo _selectedJogoItem;
        public Jogo SelectedJogoItem
        {
            get => _selectedJogoItem;
            set
            {
                if (value != null)
                {
                    _selectedJogoItem = value;
                    NotifyPropertyChanged("SelectedJogoItem");
                    ExibirJogoDetails(value.Id);
                }
            }
        }
    }
}
