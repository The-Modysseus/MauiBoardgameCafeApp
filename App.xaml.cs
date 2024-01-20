using MauiBoardgameCafeApp.Views;
using MauiBoardgameCafeApp.Data;

namespace MauiBoardgameCafeApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainView());
		}

		protected override async void OnStart()
		{
			base.OnStart();
			await Database.CreateAsync();
		}
	}
}
