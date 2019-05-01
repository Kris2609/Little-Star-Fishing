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

        public Controller()
        {
            model = new Model();
            bait = new Bait();
            fish = new Fish();
            model.highscoreStructure();
           
            //model.fillHighscoreTable();
            
            bait.baitStructure();
            //bait.fillBaitTable();
            fish.fishStructure();
            //fish.fillfishTable();
            

        }
        public String getHighscore()
        {
            return model.getHighscore();
        }
        public String getBait()
        {
            return bait.getBait();
        }
        public string getFish(int id)
        {
            return fish.getscore(id);
        }
    }
}