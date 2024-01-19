using MauiBoardgameCafeApp.ViewModels;

namespace MauiBoardgameCafeApp
{
	public partial class MainView : ContentPage
	{
		public MainView()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
		}
	}
}
