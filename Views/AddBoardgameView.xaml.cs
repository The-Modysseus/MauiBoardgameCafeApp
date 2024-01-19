using MauiBoardgameCafeApp.ViewModels;

namespace MauiBoardgameCafeApp.Views;

public partial class AddBoardgameView : ContentPage
{
	public AddBoardgameView()
	{
		InitializeComponent();
		BindingContext = new AddBoardgameViewModel();
	}
}