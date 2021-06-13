using JogoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JogoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JogoLista : ContentPage
	{
		public JogoLista ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.BindingContext = new JogoListaViewModel();
        }
    }
}