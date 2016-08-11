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
    public partial class ExpensePage : PopupPage
    {
        private decimal amount;
        private string reason;
        private string note;
        private DateTime date;

        MainPage _main;

        private TapGestureRecognizer PictureRecognizer = new TapGestureRecognizer();

        public ExpensePage(MainPage main)
        {
            InitializeComponent();
            date = DateTime.Today;
            _main = main;

            PictureRecognizer.Tapped += PictureRecognizer_Tapped;
            PicButton.GestureRecognizers.Add(PictureRecognizer);

            BindingContext = this;
        }

        private async void PictureRecognizer_Tapped(object sender, EventArgs e)
        {
            await DisplayAlert("Add Picture", "Here the application will take a picture or choose one from the galery", "Close");
            ExpensePic.IsVisible = true;
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

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value; OnPropertyChanged();
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
            //Makes the expense negative
            if (amount > 0)
                amount *= -1;

            Models.Entry item = new Models.Entry()
            {
                Amount = Amount,
                Date = Date.ToString("yyyy/MM/dd"),
                Note = Note,
                Mean="",
                Reason = Reason,
                Type = "Expense"
            };

            App.Database.SaveItem(item);

            PopupNavigation.PopAsync();

            _main.LoadData();
        }
    }
}
