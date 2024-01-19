using MauiBoardgameCafeApp.Views;

namespace MauiBoardgameCafeApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainView());
		}
	}
}
