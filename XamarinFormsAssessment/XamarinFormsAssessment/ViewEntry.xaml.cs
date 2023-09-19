using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsAssessment.Classes;

namespace XamarinFormsAssessment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewEntry : ContentPage
    {
        public ViewEntry(int ID, string Fname, string Lname, DateTime Birthday)
        {
            InitializeComponent();

            myID.Text = ID.ToString();
            firstN.Text = Fname;
            lastN.Text = Lname;
            birth.Text = Birthday.ToShortDateString();
        }

        private void DeleteEntry_Clicked(object sender, EventArgs e)
        {
            string db_name = "enrty_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Device.BeginInvokeOnMainThread(() =>
            {
                var db = new SQLiteConnection(db_path);
                int ID = Convert.ToInt32(myID.Text);
                db.Table<UserEntry>().Delete(x => x.Id == ID);
            });

            Navigation.PushAsync(new MainPage());
            CrossToastPopUp.Current.ShowToastMessage("Entry Deleted.");
        }
    }
}