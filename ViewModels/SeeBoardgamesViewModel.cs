using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBoardgameCafeApp.Models;
using MauiBoardgameCafeApp.Data;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBoardgameCafeApp.ViewModels
{
	public partial class SeeBoardgamesViewModel
	{
		protected readonly Database _database;

		public SeeBoardgamesViewModel() 
		{
			_database = Database.Instance;
		}

		public ObservableCollection<Boardgame> BoardgameList { get; set; } = new();
		
		public async Task ReloadData()
		{
			var boardgames = await _database.GetBoardgames();
			BoardgameList.Clear();
			foreach (var boardgame in boardgames)
			{
				BoardgameList.Add(boardgame);
			}
		}

		#region Methods
		[RelayCommand]
		private async Task ShowMainPage()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
		#endregion
	}
}
