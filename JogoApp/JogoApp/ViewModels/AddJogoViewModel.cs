using JogoApp.Models;
using JogoApp.Services;
using JogoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JogoApp.ViewModels
{
    public class AddJogoViewModel : BaseJogoViewModel
    {
        public ICommand AddJogoCommand { get; private set; }
        public ICommand ViewAllJogosCommand { get; private set; }

        public AddJogoViewModel()
        {
            _JogoValidator = new JogoValidator();
            _Jogo = new Jogo();
            _JogoRepository = new JogoRepository();

            AddJogoCommand = new Command(async () => await AddJogo());
            ViewAllJogosCommand = new Command(async () => await ExibirJogoLista());
        }

        async Task AddJogo()
        {
            var resultadoValidacao = _JogoValidator.Validate(_Jogo);

            if (resultadoValidacao.IsValid)
            {
                bool respostaUsuario = await _messageService.ShowAsyncBool("Adicionar Jogo","Deseja salvar os detalhes do Jogo?", "OK", "Cancela");
                if (respostaUsuario)
                {
                    _JogoRepository.InsertJogo(_Jogo);
                    await _navigationService.NavigateToJogoLista();
                }
            }
            else
            {
                await _messageService.ShowAsync("Adicionar Jogo", resultadoValidacao.Errors[0].ErrorMessage, "OK");
            }
        }

        async Task ExibirJogoLista()
        {
            await _navigationService.NavigateToJogoLista();
        }

        public bool IsViewAll => _JogoRepository.GetAllJogosData().Count > 0 ? true : false;
    }
}
