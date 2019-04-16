using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace LittleStarFish
{
    public class Model
    {
        private const String CONNECTIONSTRING = @"Data Source=testtabel.db;version=3;New=true;Compress=true";
        private SQLiteConnection connection;
        public Model()
        {
            connection = new SQLiteConnection(CONNECTIONSTRING);
            connection.Open();
        }
    }
}