using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LittleStarFish
{

    public class Model
    {

        private SQLiteConnection m_dbConnection;
        private const String CONNECTIONSTRING = @"Data Source=testtabel.db;version=3";
        public SpriteFont textFont;


        public Model()
        {
            m_dbConnection = new SQLiteConnection(CONNECTIONSTRING);
            m_dbConnection.Open();
        }
        public void highscoreStructure()
        {
            string sql = "CREATE TABLE IF NOT EXISTS highscores (id INTEGER PRIMARY KEY ASC,name VARCHAR(20), score INT)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }
        public void fillHighscoreTable()
        {
            SQLiteCommand cmd = m_dbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO highscores (id,name, score) VALUES(NULL,'Jens', 4000)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO highscores (id,name, score) VALUES(NULL,'Peter', 5000)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO highscores (id,name, score) VALUES(NULL,'Bob', 2500)";
            cmd.ExecuteNonQuery();
        }
        public String getHighscore()
        {
            String sqlexpHeigscore = "SELECT * FROM highscores ORDER BY score DESC;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpHeigscore, m_dbConnection)
            {
                CommandText = sqlexpHeigscore
            };
            // res = cmd.ExecuteScalar();
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlHigscore = "";
            while (reader.Read())
            {
                sqlHigscore += "Name: " + reader["name"] + "     " + "Score:" + reader["score"] + Environment.NewLine;
            }
            return sqlHigscore;
        }

        public void newPlayerScore()
        {
            SQLiteCommand cmd = m_dbConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO highscores (id,name, score) VALUES(NULL,'Player', 0)";
            cmd.ExecuteNonQuery();
        }
        public String getNewHighScore()
        {
            String sqlexpPlayerscore = "SELECT * FROM highscores ORDER BY id DESC LIMIT 1;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpPlayerscore, m_dbConnection)
            {
                CommandText = sqlexpPlayerscore
            };
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlPlayerscore = "";
            while (reader.Read())
            {
                sqlPlayerscore += "Name: " + reader["name"] + "     " + "Score:" + reader["score"];
            }
            return sqlPlayerscore;
        }
        public String getBestHeighscore()
        {
            String sqlexpPlayerscore = "SELECT * FROM highscores ORDER BY score DESC LIMIT 1;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpPlayerscore, m_dbConnection)
            {
                CommandText = sqlexpPlayerscore
            };
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlPlayerscore = "";
            while (reader.Read())
            {
                sqlPlayerscore += "Name: " + reader["name"] + "     " + "Score:" + reader["score"];
            }
            return sqlPlayerscore;
        }
        public String getUpdateNewScore()
        {
            String sqlexpPlayerscore = "SELECT score FROM highscores ORDER BY id DESC LIMIT 1;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpPlayerscore, m_dbConnection)
            {
                CommandText = sqlexpPlayerscore
            };
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlPlayerscore = "";
            while (reader.Read())
            {
                sqlPlayerscore += reader["score"];
            }
            return sqlPlayerscore;
        }
        public String updatePlayerScore()
        {
            String sqlexpPlayerscore = "UPDATE highscores SET score = score + {value} ORDER BY id DESC LIMIT 1;";
            SQLiteCommand cmd = new SQLiteCommand(sqlexpPlayerscore, m_dbConnection)
            {
                CommandText = sqlexpPlayerscore
            };
            SQLiteDataReader reader;
            reader = cmd.ExecuteReader();

            String sqlPlayerscore = "";
            while (reader.Read())
            {
                sqlPlayerscore += reader["score"];
            }
            return sqlPlayerscore;
        }
    }
}