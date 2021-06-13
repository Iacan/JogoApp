using JogoApp.Models;
using JogoApp.Services;
using JogoApp.Validator;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JogoApp.ViewModels
{
    public class DetailsViewModel : BaseJogoViewModel
    {
        public ICommand UpdateJogoCommand { get; private set; }
        public ICommand DeleteJogoCommand { get; private set; }

        public DetailsViewModel(int selectedJogoID)
        {
            _JogoValidator = new JogoValidator();
            _Jogo = new Jogo();
            _Jogo.Id = selectedJogoID;
            _JogoRepository = new JogoRepository();

            UpdateJogoCommand = new Command(async () => await UpdateJogo());
            DeleteJogoCommand = new Command(async () => await DeleteJogo());

            EncontrarDetalhesDoJogo();
        }

        void EncontrarDetalhesDoJogo()
        {
            _Jogo = _JogoRepository.GetJogoData(_Jogo.Id);
        }

        async Task UpdateJogo()
        {
            var resultadoValidacao = _JogoValidator.Validate(_Jogo);

            if (resultadoValidacao.IsValid)
            {
                bool isUserAccept = await _messageService.ShowAsyncBool("Detalhes do Jogo", "Atualiza detalhes do Jogo ?", "OK", "Cancelar");
                if (isUserAccept)
                {
                    _JogoRepository.UpdateJogo(_Jogo);
                    _navigationService.PopAsyncService();
                }
            }
            else
            {
                await _messageService.ShowAsync("Detalhes do Jogo", resultadoValidacao.Errors[0].ErrorMessage, "OK");
            }
        }

        async Task DeleteJogo()
        {
            bool respostaUsuario = await _messageService.ShowAsyncBool("Detalhes do Jogo", "Deletar detalhes do Jogo", "OK", "Cancelar");
            if (respostaUsuario)
            {
                _JogoRepository.DeleteJogo(_Jogo.Id);
                _navigationService.PopAsyncService();
            }
        }
    }
}
