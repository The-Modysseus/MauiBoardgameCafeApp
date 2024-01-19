using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBoardgameCafeApp.Views;
using MauiBoardgameCafeApp.Models;
using MauiBoardgameCafeApp.Data;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBoardgameCafeApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
		protected readonly Database _database;

		public MainViewModel() 
		{
			_database = Database.Instance;
			_ = Initialize();
		}

		public ObservableCollection<Boardgame> BoardgameList { get; set; } = new();

		private async Task Initialize()
		{
			var boardgames = await _database.GetBoardgames();
			foreach (var boardgame in boardgames)
			{
				BoardgameList.Add(boardgame);
			}
		}

		#region Methods
		[RelayCommand]
		private async Task ShowCreateBoardgamePage()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new AddBoardgameView());
		}
		#endregion
	}
}
