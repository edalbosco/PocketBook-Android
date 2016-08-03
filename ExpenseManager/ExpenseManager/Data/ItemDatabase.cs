using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;
using ExpenseManager.Models;

namespace ExpenseManager.Data
{
    public class ItemDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public ItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Models.Entry>();
        }
        
        public IEnumerable<Models.Entry> GetItems()
        {
            string query = "SELECT * FROM [Entry]";

            lock (locker)
            {
                return database.Query<Models.Entry>(query);
            }
        }

        public Models.Entry GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Models.Entry>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(Models.Entry item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Models.Entry>(id);
            }
        }
    }
}

