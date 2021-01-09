using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOutDiaryApp.Model
{
    public class DiaryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Squats { get; set; }
        public int PushUps { get; set; }
        public int MountainClimbers { get; set; }
        public int Burpees { get; set; }
        public DateTime Time {get; set; } 
        public byte[] ImageFile { get; set; }
    }
}
