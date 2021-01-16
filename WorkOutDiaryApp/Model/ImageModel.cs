using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace WorkOutDiaryApp.Model 
{
    public class ImageModel : DiaryModel
    {
        public ImageSource imageSource { get; set; }
        public ImageModel(DiaryModel diaryModel)
        {
            this.Id = diaryModel.Id;
            this.Squats = diaryModel.Squats;
            this.PushUps = diaryModel.PushUps;
            this.MountainClimbers = diaryModel.MountainClimbers;
            this.Burpees = diaryModel.Burpees;
            this.Time = diaryModel.Time;
            this.ImageFile = diaryModel.ImageFile;

            if(ImageFile != null)
            {
                imageSource = ImageSource.FromStream(() => new MemoryStream(diaryModel.ImageFile));
            }
        }

    }
}
