using System;
using SQLite;
using SQLite.Net.Attributes;

namespace ExpenseManager.Models
{
	public class Entry
	{
		public Entry ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Type { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string Reason { get; set; }
        public string Mean { get; set; }
        public string Note { get; set; }

        [Ignore]
        public string EntryText
        {
            get
            {
                return Reason + " [" + Amount.ToString() + "]";
            }
        }

        [Ignore]
        public string EntryDetail
        {
            get
            {
                return Type + " - " + Date.ToString();
            }
        }
    }
}

