using System;
using System.Collections.Generic;
using System.Text;

namespace RebirthAndTrade.Data
{
    public enum AnimalBodyType
    {
        injured, neon, gold, diamond, giant, rainbow, exotic, boost
    }
    public class Animal
    {
        //private double multiplierM = 1;
        //private double multiplierD = 1;
        private double multiplierPetPrice = 1;
        private AnimalBodyType bodyType;
        private int basePrice;
        private bool isShiny;
        public Animal() { }
        public Animal(string inputBodyType, int inputBasePrice, bool inputShiny)
        {
            switch (inputBodyType.ToLower())
            {
                case "injured":
                    this.bodyType = AnimalBodyType.injured;
                    this.multiplierPetPrice *= 0.5;
                    break;
                case "neon":
                    this.bodyType = AnimalBodyType.neon;
                    this.multiplierPetPrice *= 1.15;
                    break;
                case "gold":
                    this.bodyType = AnimalBodyType.gold;
                    this.multiplierPetPrice *= 5;
                    break;
                case "diamond":
                    this.bodyType = AnimalBodyType.diamond;
                    this.multiplierPetPrice *= 7;
                    break;
                case "giant":
                    this.bodyType = AnimalBodyType.giant;
                    this.multiplierPetPrice *= 2.5;
                    break;
                case "rainbow":
                    this.bodyType = AnimalBodyType.rainbow;
                    this.multiplierPetPrice *= 10;
                    break;
                case "exotic":
                    this.bodyType = AnimalBodyType.exotic;
                    this.multiplierPetPrice *= 100;
                    break;
                case "boost":
                    this.bodyType = AnimalBodyType.boost;
                    this.multiplierPetPrice *= 50; // specifichno
                    break;
                default:
                    Console.WriteLine("Incorrect animal body type.");
                    break;
            }

            this.basePrice = inputBasePrice < 0 ? 0 : inputBasePrice;
            if (basePrice < 0)
            {
                Console.WriteLine("Animal price cannot be negative.");
            }

            this.isShiny = inputShiny;
            this.multiplierPetPrice = isShiny ? multiplierPetPrice * multiplierPetPrice : multiplierPetPrice; 

        }

        public int getPrice()
        {
            return Convert.ToInt32(basePrice + Math.Ceiling(basePrice * multiplierPetPrice));
        }
        public void Print()
        {
            Console.WriteLine("Animal with body type " + bodyType + " , multiplier " + multiplierPetPrice + " , base price " + basePrice + ", shiny is " + isShiny +" and total price is "+getPrice());
        }
    }
}
