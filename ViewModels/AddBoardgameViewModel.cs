using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBoardgameCafeApp.Data;
using MauiBoardgameCafeApp.Views;
using MauiBoardgameCafeApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace MauiBoardgameCafeApp.ViewModels
{
    public partial class AddBoardgameViewModel : MainViewModel
    {
		//protected readonly Database _database;
		public AddBoardgameViewModel() 
		{
			//_database = Database.Instance;
			//_ = Initialize();
		}
		#region New values
		public string NewName { get; set; } = string.Empty;
		public string NewDescription { get; set; } = String.Empty;
		public int NewPublicationYear { get; set; }
		public int NewPlayersMin { get; set; }
		public int NewPlayersMax { get; set; }
		public string NewPlayTime { get; set; } 
		public int NewMinimumAge { get; set; }
		public int NewCountAvailable { get; set; }
		public int NewCountInUse { get; set; }
		public int[] NewRatings { get; set; } = Array.Empty<int>();
		public int NewCountRatings { get; set; } = 0;
		#endregion

		//public ObservableCollection<Boardgame> BoardgameList { get; set; } = new();

		#region Methods
		//private async Task Initialize()
		//{
		//	var boardgames = await _database.GetBoardgames();
		//	foreach (var boardgame in boardgames)
		//	{
		//		BoardgameList.Add(boardgame);
		//	}
		//}

		public async Task ReloadData()
		{
			var boardgames = await _database.GetBoardgames();
			BoardgameList.Clear();
			foreach (var boardgame in boardgames)
			{
				BoardgameList.Add(boardgame);
			}
		}

		[RelayCommand]
		public async Task AddBoardgame()
		{
			var newBoardgame = new Boardgame
			{
				Name = NewName,
				Description = NewDescription,
				PublicationYear = NewPublicationYear,
				PlayersMin = NewPlayersMin,
				PlayersMax = NewPlayersMax,
				PlayTime = NewPlayTime,
				MinimumAge = NewMinimumAge,
				CountAvailable = NewCountAvailable,
				CountInUse = NewCountInUse,
				Ratings = NewRatings,
				CountRatings = NewCountRatings
			};
			var inserted = await _database.AddBoardgame(newBoardgame);
            if (inserted != 0)
            {
				BoardgameList.Add(newBoardgame);
				NewName = string.Empty;
				NewDescription = string.Empty;
				NewPublicationYear = 0;
				NewPlayersMin = 0;
				NewPlayersMax = 0;
				NewPlayTime = string.Empty;
				NewMinimumAge = 0;
				NewCountAvailable = 0;
				NewCountInUse = 0;
            }
			await Application.Current.MainPage.Navigation.PopAsync();
        }

		[RelayCommand]
		public async Task Cancel()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
		#endregion
	}
}
