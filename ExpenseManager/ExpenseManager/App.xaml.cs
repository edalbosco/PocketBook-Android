using ExpenseManager.Data;

using Xamarin.Forms;

namespace ExpenseManager
{
    public partial class App : Application
    {
        static ItemDatabase database;

        public NavigationPage Navigation { get; private set; }

        public App()
        {
            InitializeComponent();
            Current = this;

            MainPage = Navigation = new NavigationPage(new Pages.MainPage());
        }

        public static new App Current { get; private set; }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
