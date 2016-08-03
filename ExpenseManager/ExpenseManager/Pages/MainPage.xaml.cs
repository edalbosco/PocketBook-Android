using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpenseManager.Pages
{
    public partial class MainPage : ContentPage
    {

        private List<Models.Entry> entries;
        private decimal balance;

        private Command addIncomeCommand;
        private Command addExpenseCommand;

        public List<Models.Entry> Entries
        {
            get { return entries; }
            set { entries = value; OnPropertyChanged(); }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; OnPropertyChanged(); }
        }

        public Command AddIncomeCommand
        {
            get { return addIncomeCommand; }
            set { addIncomeCommand = value; OnPropertyChanged(); }
        }

        public Command AddExpenseCommand
        {
            get { return addExpenseCommand; }
            set { addExpenseCommand = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();

            AddIncomeCommand = new Command(AddIncome);
            AddExpenseCommand = new Command(AddExpense);

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadData();
        }

        public void LoadData()
        {
            Entries = App.Database.GetItems().ToList();

            decimal balance = 0;

            foreach(var e in Entries)
            {
                balance += e.Amount;
            }

            Balance = balance;
        }

        private  void AddExpense(object obj)
        {
             PopupNavigation.PushAsync(new ExpensePage(this));
        }

        private void AddIncome(object obj)
        {
            PopupNavigation.PushAsync(new IncomePage(this));
        }

        public void OnDeleteEntry(object sender, EventArgs e)
        {
            App.Database.DeleteItem(((sender as BindableObject).BindingContext as Models.Entry).ID);
            LoadData();
        }
    }
}
