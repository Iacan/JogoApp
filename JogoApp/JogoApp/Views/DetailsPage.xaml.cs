using JogoApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JogoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage (int JogoID)
		{
			InitializeComponent ();
            this.BindingContext = new DetailsViewModel(JogoID);
        }
	}
}