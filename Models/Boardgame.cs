using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Runtime.CompilerServices;

namespace MauiBoardgameCafeApp.Models
{
	public class Boardgame : INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int PublicationYear { get; set; }
		public int PlayersMin { get; set; }
		public int PlayersMax { get; set; }
		public string PlayTime { get; set; }
		public int MinimumAge { get; set; }
		public int CountAvailable { get; set; }
		public int CountInUse { get; set; }
		public int[] Ratings { get; set; }
		public int CountRatings { get; set; }


		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public void RaisePropertyChanged(params string[] properties)
		{
			foreach (var propertyName in properties)
			{
				PropertyChanged?.Invoke(this, new
				PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
