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

           MainPage mainPage = new MainPage();
           MainPage = new NavigationPage(mainPage);
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
