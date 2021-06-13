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

            //aplica a inje��o de depend�ncia nos servi�os implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
            //cria uma inst�ncia do repositorio
            _JogoRepository = new JogoRepository();
            //invoca o evento 
            OnAppStart();
		}

        private void OnAppStart()
        {
            //obtem todos os dados 
            var getLocalDB = _JogoRepository.GetAllJogosData();

            //se existir dados ent�o exibe a lista sen�o inclui dados
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
