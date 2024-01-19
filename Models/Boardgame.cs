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
		public string PublicationYear { get; set; }
		public string PlayersMin { get; set; }
		public string PlayersMax { get; set; }
		public string PlayTime { get; set; }
		public string MinimumAge { get; set; }
		public string CountAvailable { get; set; }
		public string CountInUse { get; set; }
		public string[] Ratings { get; set; }
		public string CountRatings { get; set; }


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
