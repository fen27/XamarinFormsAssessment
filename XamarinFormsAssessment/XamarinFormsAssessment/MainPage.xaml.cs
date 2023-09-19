using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAssessment.Classes;

namespace XamarinFormsAssessment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        

        private void MyAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddEntry());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string db_name = "enrty_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            using (SQLiteConnection conn = new SQLiteConnection(db_path))
            {
                conn.CreateTable<UserEntry>();
                var userEntries = conn.Table<UserEntry>().ToList();

                entryListView.ItemsSource = userEntries;
            }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as UserEntry;
            Navigation.PushAsync(new ViewEntry(item.Id, item.First_name, item.Last_name, item.DateofBirth));
        }

       
    }

}
