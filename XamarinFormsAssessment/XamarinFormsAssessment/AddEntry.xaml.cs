using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XamarinFormsAssessment.Classes;
using SQLite;
using System.IO;
using Plugin.Toast;

namespace XamarinFormsAssessment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEntry : ContentPage
    {

        public AddEntry()
        {
            InitializeComponent();
            BirthDate.MaximumDate = DateTime.Today;
        }

        void AddEntry_Clicked(object sender, EventArgs e)
        {
            UserEntry userEntry = new UserEntry()
            {
                First_name = FirstName.Text,
                Last_name = LastName.Text,
                DateofBirth = BirthDate.Date,
                age = DateTime.Today.Year - BirthDate.Date.Year,
            };

            string db_name = "enrty_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            using (SQLiteConnection conn = new SQLiteConnection(db_path))
            {
                conn.CreateTable<UserEntry>();
                int rowsAdded = conn.Insert(userEntry);
            }

            Navigation.PushAsync(new MainPage());
            CrossToastPopUp.Current.ShowToastMessage("Entry Added.");
            
        }
    }
}