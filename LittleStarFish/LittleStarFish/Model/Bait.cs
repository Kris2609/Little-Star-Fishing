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
    public class Bait
    {
        private SQLiteConnection m_dbConnection;
        private const String CONNECTIONSTRING = @"Data Source=testtabel.db;version=3";
        public SpriteFont textFont;
        public Bait()
        {
            m_dbConnection = new SQLiteConnection(CONNECTIONSTRING);
            m_dbConnection.Open();
        }
        public void baitStructure()
        {
            string sql = "CREATE TABLE IF NOT EXISTS bait (name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        public void fillBaitTable()
        {
            SQLiteCommand cmd = m_dbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('lb', 1)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('deadbait', 2)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO bait (name, score) VALUES('andreas', 5)";
            cmd.ExecuteNonQuery();
        }
        public String getBait()
        {
            String sqlexpBait = "SELECT * FROM bait;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpBait, m_dbConnection)
            {
                CommandText = sqlexpBait
            };
            // res = cmd.ExecuteScalar();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlBait = "";
            while (reader.Read())
            {
                sqlBait += "Name: " + reader["name"] + " " + "Score:" + reader["score"] + Environment.NewLine;
            }
            return sqlBait;
        }
    }
}