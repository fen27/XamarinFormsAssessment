using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsAssessment.Classes
{
    public class UserEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime DateofBirth { get; set; }

        public int age { get; set; }

    }
}
