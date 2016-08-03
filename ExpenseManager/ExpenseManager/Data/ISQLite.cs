using System;
using SQLite;
using SQLite.Net;

namespace ExpenseManager.Data
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

