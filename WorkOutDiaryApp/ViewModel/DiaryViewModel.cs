using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOutDiaryApp.Model;
using Xamarin.Forms;

namespace WorkOutDiaryApp.ViewModel
{
    public class DiaryViewModel
    {
        public event PropertyChangingEventHandler propertyChanged;
        public ObservableCollection<ImageModel> diaryModelList { get; set; } = new ObservableCollection<ImageModel>();
            
        private string dataBaseName = "WorkOutDiaryAppDatabase.db", databasePath;

        // Create a database
        public async Task InitializeDataBase(/*DiaryModel diary  -- Exempel på att lägga till rad i databas*/)
        {
            try
            {
                // Maps the path on android
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dataBaseName);

                // Creates tables if not already created. It will ignore existing tables.
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    db.CreateTable<DiaryModel>();
                    /*
                    db.Insert(diary);*/
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Database error - There was an error when creating the data base", e.Message, "Close");
            }
        }
        // Fetch data from NewDiary entries and add to Db 
        public async Task CreateDiaryEntry(DiaryModel diaryModel)
        {

            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    if(diaryModel != null)
                    {
                        db.Insert(diaryModel);
                    }
                }
                GetDiaryEntries();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Database error - There was an error when creating the data base", e.Message, "Close");
            }
            
        }
        public async Task DeleteDiaryEntry(int id)
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    db.Delete<DiaryModel>(id);
                }
                GetDiaryEntries();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Database error - There was an error when creating the data base", e.Message, "Close");
            }
        }
        public void GetDiaryEntries()
        {

            diaryModelList.Clear();

            using (SQLiteConnection db = new SQLiteConnection(databasePath))
            {
               var List = db.Table<DiaryModel>().ToList();
                foreach (var item in List)
                {
                    ImageModel imageModel = new ImageModel(item);
                    diaryModelList.Add(imageModel);
                }
            }
            RaisePropertyChanged(nameof(diaryModelList));
        }


        protected void RaisePropertyChanged(string propertyName)
        {
            propertyChanged?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
        public void Update()
        {

        }


    }
}
