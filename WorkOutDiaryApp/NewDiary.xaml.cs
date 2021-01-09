using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkOutDiaryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDiary : ContentPage
    {
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
    }
}