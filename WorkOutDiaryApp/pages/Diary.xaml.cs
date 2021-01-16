using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutDiaryApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOutDiaryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Diary : ContentPage
    {
        public Diary()
        {
            InitializeComponent();
            App.diaryViewModel.GetDiaryEntries();
            BindingContext = App.diaryViewModel;
        }

        private async void Remove_Entry_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var selecter = item.CommandParameter as ImageModel;
            await App.diaryViewModel.DeleteDiaryEntry(selecter.Id);
        }
    }
}