using FluentValidation;
using JogoApp.Models;
using JogoApp.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace JogoApp.ViewModels
{
    public class BaseJogoViewModel : INotifyPropertyChanged
    {
        public Jogo _Jogo;
        public IValidator _JogoValidator;
        public IJogoRepository _JogoRepository;

        protected IMessageService _messageService;
        protected INavigationService _navigationService;

        public BaseJogoViewModel()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string Titulo
        {
            get => _Jogo.Titulo;
            set
            {
                _Jogo.Titulo = value;
                NotifyPropertyChanged(nameof(Titulo));
            }
        }

        public string Link
        {
            get => _Jogo.Link;
            set
            {
                _Jogo.Link = value;
                NotifyPropertyChanged(nameof(Link));
            }
        }

        public decimal RM
        {
            get => _Jogo.RM;
            set
            {
                _Jogo.RM = value;
                NotifyPropertyChanged(nameof(RM));
            }
        }

        public string Descricao
        {
            get => _Jogo.Descricao;
            set
            {
                _Jogo.Descricao = value;
                NotifyPropertyChanged(nameof(Descricao));
            }
        }

        List<Jogo> _JogoLista;
        public List<Jogo> JogoLista
        {
            get => _JogoLista;
            set
            {
                _JogoLista = value;
                NotifyPropertyChanged(nameof(JogoLista));
            }
        }

        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
