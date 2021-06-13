using JogoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JogoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddJogo : ContentPage
	{
		public AddJogo ()
		{
			InitializeComponent ();
            BindingContext = new AddJogoViewModel();
        }
	}
}