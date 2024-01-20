using MauiBoardgameCafeApp.ViewModels;

namespace MauiBoardgameCafeApp.Views;

public partial class SeeBoardgamesView : ContentPage
{
	public SeeBoardgamesView()
	{
		InitializeComponent();
		BindingContext = new SeeBoardgamesViewModel();
	}

	private SeeBoardgamesViewModel viewModel => BindingContext as SeeBoardgamesViewModel;

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await viewModel.ReloadData();
	}
}