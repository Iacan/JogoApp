using JogoApp.Services;
using JogoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JogoApp
{
    public partial class App : Application
	{
        IJogoRepository _JogoRepository;
        public App ()
		{
            InitializeComponent();

            //aplica a injeção de dependência nos serviços implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
            //cria uma instância do repositorio
            _JogoRepository = new JogoRepository();
            //invoca o evento 
            OnAppStart();
		}

        private void OnAppStart()
        {
            //obtem todos os dados 
            var getLocalDB = _JogoRepository.GetAllJogosData();

            //se existir dados então exibe a lista senão inclui dados
            if (getLocalDB.Count > 0)
            {
                MainPage = new NavigationPage(new JogoLista());
            }
            else
            {
                MainPage = new NavigationPage(new AddJogo());
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
