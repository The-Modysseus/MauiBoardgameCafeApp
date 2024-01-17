using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBoardgameCafeApp.Models;
using SQLite;

namespace MauiBoardgameCafeApp.Data
{
	internal class Database
	{
		private readonly SQLiteAsyncConnection _connection;

		public Database()
		{
			var dataDir = FileSystem.AppDataDirectory;
			var databasePath = Path.Combine(dataDir, "MauiBoardgameCafeApp.db");

			string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

			if (string.IsNullOrEmpty(_dbEncryptionKey))
			{
				Guid g = new Guid();
				_dbEncryptionKey = g.ToString();
				SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
			}

			var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);

			_connection = new SQLiteAsyncConnection(dbOptions);

			_ = Initialise();
		}

		private async Task Initialise()
		{
			await _connection.CreateTableAsync<Boardgame>();
		}

		public async Task<List<Boardgame>> GetBoardgames()
		{
			return await _connection.Table<Boardgame>().ToListAsync();
		}

		public async Task<Boardgame> GetBoardgame(int id)
		{
			var query = _connection.Table<Boardgame>().Where(t => t.Id == id);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<int> AddBoardgame(Boardgame item)
		{
			return await _connection.InsertAsync(item);
		}

		public async Task<int> DeleteBoardgame(Boardgame item)
		{
			return await _connection.DeleteAsync(item);
		}

		public async Task<int> UpdateBoardgame(Boardgame item)
		{
			return await _connection.UpdateAsync(item);
		}
	}
}
