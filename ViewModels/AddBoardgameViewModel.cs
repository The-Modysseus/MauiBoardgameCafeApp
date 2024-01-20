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
		protected readonly Database _database;
		public AddBoardgameViewModel() 
		{
			_database = Database.Instance;
		}

		#region New values
		public string NewName { get; set; }
		public string NewDescription { get; set; }
		public string NewPublicationYear { get; set; }
		public string NewPlayersMin { get; set; }
		public string NewPlayersMax { get; set; }
		public string NewPlayTime { get; set; } 
		public string NewMinimumAge { get; set; }
		public string NewCountAvailable { get; set; }
		public string NewCountInUse { get; set; }
		public int NewLatestRating { get; set; }
		public string NewCountRatings { get; set; } = "0";
		#endregion

		public ObservableCollection<Boardgame> BoardgameList { get; set; } = new();

		#region Methods
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
				LatestRating = NewLatestRating,
				CountRatings = NewCountRatings
			};
			var inserted = await _database.AddBoardgame(newBoardgame);
            if (inserted != 0)
            {
				BoardgameList.Add(newBoardgame);
				NewName = string.Empty;
				NewDescription = string.Empty;
				NewPublicationYear = string.Empty;
				NewPlayersMin = string.Empty;
				NewPlayersMax = string.Empty;
				NewPlayTime = string.Empty;
				NewMinimumAge = string.Empty;
				NewCountAvailable = string.Empty;
				NewCountInUse = string.Empty;
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
