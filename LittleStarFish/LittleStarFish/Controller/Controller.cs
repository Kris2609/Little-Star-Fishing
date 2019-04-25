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
        

        public Controller()
        {
            model = new Model();
            bait = new Bait();
            //model.highscoreStructure();
            //model.fillHighscoreTable();
            
            //bait.baitStructure();
            //bait.fillBaitTable();


        }
        public String getHighscore()
        {
            return model.getHighscore();
        }
        public String getBait()
        {
            return bait.getBait();
        }
    }
}