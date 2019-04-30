using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Fish 
    {
        private SQLiteConnection m_dbConnection;
        private const String CONNECTIONSTRING = @"Data Source=testtabel.db;version=3";
        public SpriteFont textFont;
        public Fish()
        {
            m_dbConnection = new SQLiteConnection(CONNECTIONSTRING);
            m_dbConnection.Open();
        }
        public void baitStructure()
        {
            string sql = "CREATE TABLE IF NOT EXISTS fish (name VARCHAR(40), score INT,)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        public void fillBaitTable()
        {
            SQLiteCommand cmd = m_dbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Brasen', 20)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Sterlet', 50)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Sturgeon', 40)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Bighead carp', 30)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('White bream', 40)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Goldfish', 30)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Bullhead', 30)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('Gudgeon', 50)";
            cmd.ExecuteNonQuery();

        }
        public String getfish()
        {
            String sqlexpFish = "SELECT * FROM fish;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpFish, m_dbConnection)
            {
                CommandText = sqlexpFish
            };
            // res = cmd.ExecuteScalar();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlFish = "";
            while (reader.Read())
            {
                sqlFish += "Name: " + reader["name"] + " " + "Score:" + reader["score"] + Environment.NewLine;
            }
            return sqlFish;
        }
    }
}
