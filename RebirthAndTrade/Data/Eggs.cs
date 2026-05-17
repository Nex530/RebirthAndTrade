using System;
using System.Collections.Generic;
using System.Text;

namespace RebirthAndTrade.Data
{
    internal class Eggs
    {
        public Animal getCommonAnimal()
        {
            Random rnd = new Random();
            int petChance = rnd.Next(0, 100);
            int shinyChance=rnd.Next(0, 100);
            bool isShiny = shinyChance < 5 ? true : false;
            string mutationChance = getRandBodyType();
            if (petChance <= 50)//dog
            {   
                Animal animal = new Animal(mutationChance, 20, isShiny);
                return animal;
            }
            return new Animal("injured", 50, true);//tova trjabva da se mahne, prosto za pulnez.
        }


        private string getRandBodyType()
        {
            Random rnd = new Random();
            double mutationChance = rnd.Next(0, 100);
            string type = "";
            if ( 0 <= mutationChance && mutationChance <= 10)
            {
                return "injured";
            }
            else if (10 < mutationChance && mutationChance <= 50)
            {
                return "neon";
            }
            else if (50 < mutationChance && mutationChance <= 67.5)
            {
                return "gold";
            }
            else if (67.5 < mutationChance && mutationChance <= 79.5)
            {
                return "diamond";
            }
            else if (79.5 < mutationChance && mutationChance <= 90)
            {
                return "giant";
            }
            else if (90 < mutationChance && mutationChance <= 95.5)
            {
                return "rainbow";
            }
            else if (95.5 < mutationChance && mutationChance <= 99)
            {
                return "boost";
            }
            else
            {
                return "rainbow";
            }
        }
    }
}
