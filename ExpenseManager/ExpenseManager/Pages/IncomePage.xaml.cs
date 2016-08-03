using ExpenseManager.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExpenseManager.Pages
{
    public partial class IncomePage : PopupPage
    {

        private decimal amount;
        private int meanIndex;
        private int reasonIndex;
        private string note;
        private DateTime date;

        MainPage _main;

        public IncomePage(MainPage main)
        {
            InitializeComponent();
            date = DateTime.Today;
            _main = main;

            BindingContext = this;
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value; OnPropertyChanged();
            }
        }

        public int MeanIndex
        {
            get
            {
                return meanIndex;
            }

            set
            {
                meanIndex = value; OnPropertyChanged();
            }
        }

        public int ReasonIndex
        {
            get
            {
                return reasonIndex;
            }

            set
            {
                reasonIndex = value; OnPropertyChanged();
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value; OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value; OnPropertyChanged();
            }
        }

        public void SaveClicked(object sender, EventArgs e)
        {
            Models.Entry item = new Models.Entry()
            {
                Amount = Amount,
                Date = Date.ToString("yyyy/MM/dd"),
                Mean = MeanPicker.Items[MeanIndex],
                Note = Note,
                Reason = ReasonPicker.Items[ReasonIndex],
                Type = "Income"
            };

            App.Database.SaveItem(item);

            PopupNavigation.PopAsync();

            _main.LoadData();
        }
    }
}
