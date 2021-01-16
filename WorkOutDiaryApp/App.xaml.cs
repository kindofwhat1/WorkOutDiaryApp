using System;
using WorkOutDiaryApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOutDiaryApp
{
    public partial class App : Application
    {
        public static DiaryViewModel diaryViewModel { get; set; } = new DiaryViewModel();
        public App()
            
        {
            InitializeComponent();

            NavigationPage page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = (Color)Application.Current.Resources["Purple"];
            MainPage = page;
        }

        protected override async void OnStart()
        {
           await diaryViewModel.InitializeDataBase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
