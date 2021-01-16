using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutDiaryApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOutDiaryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class NewDiary : ContentPage

    {
        private byte[] ImageByte; 
        DiaryModel diaryModel = new DiaryModel();
        public NewDiary()
        {
            InitializeComponent();
        }

        // Take a photo with "Take photo" button
        async void Take_Photo_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            // Make sure it's possible to cancel the photo
            if(result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
                ImageByte = File.ReadAllBytes(result.FullPath);
            }
        }
        // Convert image to byte for SQLite
        private ImageSource ConvertImageFrom(byte[] ImageFile)
        {
            try
            {
                var stream = new MemoryStream(ImageFile);
                return ImageSource.FromStream(() => stream);
            }
            catch (Exception)
            {
                // if image fails or does not exist
                return null;
            }
        }
        public async void CreateDiaryEntry()
        {
            var diaryModel = new DiaryModel();

            {
                diaryModel.Squats = int.Parse(squatsEntry.Text);
                diaryModel.PushUps = int.Parse(pushupsEntry.Text);
                diaryModel.MountainClimbers = int.Parse(mountainClimbersEntry.Text);
                diaryModel.Burpees = int.Parse(burpeesEntry.Text);
                diaryModel.Time = dateEntry.Date;
                diaryModel.ImageFile = ImageByte;
            };

            await App.diaryViewModel.CreateDiaryEntry(diaryModel);
        }

        private async void Save_Diary_Clicked(object sender, EventArgs e)
        {
            Diary diary = new Diary();
            CreateDiaryEntry();
            await Navigation.PushAsync(diary, true);
        }
    }
}