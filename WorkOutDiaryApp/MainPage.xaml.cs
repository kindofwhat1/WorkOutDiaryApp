using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkOutDiaryApp
{
   
    public partial class MainPage : ContentPage
    {
 
        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Add_To_Diary_Clicked(object sender, EventArgs e)
        {
            NewDiary newDiary = new NewDiary();
            newDiary.Title = "New Diary"; 
            await Navigation.PushAsync(newDiary, true);// True adds a small animation on navigation
            
        }

        private async void Button_Go_To_Diary_Clicked(object sender, EventArgs e)
        {
            Diary diary = new Diary();
            diary.Title = "Diary";
            await Navigation.PushAsync(diary, true);
        }
    }
}
