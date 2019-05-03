using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleStarFish
{
    public class Controller
    {
        Model model;
        Bait bait;
        Fish fish;
        /// <summary>
        /// The Controllers Constructor
        /// </summary>
        public Controller()
        {
            model = new Model();
            bait = new Bait();
            fish = new Fish();
            //Structure the Tables
            {
                model.highscoreStructure();
                bait.baitStructure();
                fish.fishStructure();
            }
            //Fill the Tables
            {
                //bait.fillBaitTable();
                //model.fillHighscoreTable();
                //fish.fillfishTable();
            }
        }

        //Get the games HighScore
        public String getHighscore()
        {
            return model.getHighscore();
        }
        //Get the games BaitTabel
        public String getBait()
        {
            return bait.getBait();
        }
        //Get the games FishScore
        public string getFish(int id)
        {
            return fish.getscore(id);
        }
        
        public String getNewHighscore()
        {
            return model.getNewHighScore();
        }
        public void newPlayer()
        {
            model.newPlayerScore();
        }
        public String getBestscore()
        {
            return model.getBestHeighscore();
        }
        public String getPlayerScore()
        {
           return model.getUpdateNewScore();
        }
    }
}