using RebirthAndTrade.Data;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RebirthAndTrade.Logic
{
    internal class Simulator
    {
        static List<Animal> animals = new List<Animal>();
        static List<Player> players = new List<Player>();
        int percentLimit = 30;

        public void Trade(int indexTrader1, int indexTrader2)
        {
            printOwnedAnimals(indexTrader1);
            printOwnedAnimals(indexTrader2);
            bool wantToTrade1 = wantToTrade(indexTrader1, indexTrader2);
            bool wantToTrade2 = wantToTrade(indexTrader2, indexTrader1);
            if (wantToTrade1 && wantToTrade2)
            {
                List<string> choice1 = [""]; 
                List<string> choice2 = [""];
                while (choice1[0].ToLower() != "d" || choice2[0].ToLower() != "d")
                {
                    Console.Write(players[indexTrader1].getName() + ". Which animals do you want to trade? Write the numbers(type d to decline): ");
                    
                    choice1 = Console.ReadLine().Split(" ").ToList();//neka e viarno
                    if (choice1[0].ToLower() == "d")
                    {
                        break;
                    }
                    List<int> choice1Indexes = new List<int>();
                    int trader1Price = 0;
                    foreach (string choice in choice1)
                    {
                        choice1Indexes.Add((int.Parse(choice)) - 1);
                        Animal currentAnimal = players[indexTrader1].GetAnimals()[int.Parse(choice) - 1];
                        trader1Price += currentAnimal.getPrice();
                    }

                    Console.Write(players[indexTrader2].getName() + ". Which animals do you want to trade? Write the numbers(type d to decline): ");
                    choice2 = Console.ReadLine().Split(" ").ToList();//neka e viarno
                    if (choice2[0].ToLower() == "d")
                    {
                        break;
                    }
                    List<int> choice2Indexes = new List<int>();
                    int trader2Price = 0;
                    foreach (string choice in choice2)
                    {
                        choice2Indexes.Add((int.Parse(choice)) - 1);
                        Animal currentAnimal = players[indexTrader2].GetAnimals()[int.Parse(choice) - 1];
                        trader2Price += currentAnimal.getPrice();
                    }
                    int percentageDif = 100 - Convert.ToInt32(Math.Min(trader1Price, trader2Price) * 1.0 / Math.Max(trader1Price, trader2Price) * 100);
                    //print na izbrani jivotni i ceni
                    if (percentageDif > percentLimit)//da se dobavi da se pitat dali iskat trade-a
                    {
                        Console.WriteLine("Cannot trade due to value difference (" + percentageDif + "). Try again");
                        Trade(indexTrader1, indexTrader2);
                    }
                    else
                    {
                        wantToTrade1 = wantToTrade(indexTrader1, indexTrader2);
                        wantToTrade2 = wantToTrade(indexTrader2, indexTrader1);
                        if (wantToTrade1 && wantToTrade2)
                        {
                            Purchase(indexTrader1, indexTrader2, choice1Indexes, choice2Indexes);
                        }
                    }
                }
            }
        }

        private void Purchase(int indexTrader1, int indexTrader2, List<int> choice1Indexes, List<int> choice2Indexes)
        {
            List<Animal> animals1 = players[indexTrader1].GetAnimals();
            foreach (int currentindex in choice1Indexes) 
            {
                players[indexTrader2].addAnimal(animals1[currentindex]);
            }


            int counter1 = 0;
            foreach (int currentindex in choice1Indexes)
            {
                players[indexTrader1].removeAnimal(currentindex - counter1);
                counter1++;
            }

            List<Animal> animals2 = players[indexTrader2].GetAnimals();
            foreach (int currentindex in choice2Indexes)
            {
                players[indexTrader1].addAnimal(animals2[currentindex]);
            }

            int counter2 = 0;
            foreach (int currentindex in choice2Indexes)
            {
                players[indexTrader2].removeAnimal(currentindex - counter2);
                counter2++;
            }
            Console.WriteLine("Purchase successful.");
            players[indexTrader1].Print();
            players[indexTrader2].Print();

        }

            private bool wantToTrade(int indexTrader1, int indexTrader2)
        {
            Console.Write(players[indexTrader1].getName() + ", do you want to trade with " + players[indexTrader2].getName() + "?(y/n)");
            string result = Console.ReadLine();
            do
            {
                switch (result.ToLower())
                {
                    case "y":
                        return true;
                        break;
                    case "n":
                        return false;
                        break;
                    default:
                        Console.Write("Wrong option. Try again: ");
                        result = Console.ReadLine();
                        break;
                }
            }
            while (result.ToLower() != "y" && result.ToLower() != "n");
            if (result.ToLower() == "y")
            {
                return true;
            }
            else if (result.ToLower() == "n")
            {
                return false;
            }
            return false;
        }


        private void printOwnedAnimals(int indexTrader)
        {
            List<Animal> ownedAnimals = players[indexTrader].GetAnimals();
            for (int i = 0; i < ownedAnimals.Count; i++)
            {
                Console.Write((i + 1) + " ");
                ownedAnimals[i].Print();
            }
        }
        public void test0()
        {
            Animal animal1 = new Animal("injured", 50, true);
            Animal animal2 = new Animal("neon", 10, false);
            Animal animal3 = new Animal("gold", 14, true);
            Animal animal4 = new Animal("diamond", 52, false);
            Animal animal5 = new Animal("giant", 23, false);
            Animal animal6 = new Animal("rainbow", 67, true);
            Animal animal7 = new Animal("exotic", 22, false);
            Animal animal8 = new Animal("boost", 11, true);

            animals = [animal1, animal2, animal3, animal4, animal5, animal6, animal7, animal8];
            foreach (Animal animal in animals)
            {
                animal.Print();
            }
            Console.WriteLine("\n\n\n");

            Player player1 = new Player("Hollargame1i2", 510);
            player1.addAnimal(animal4);
            player1.addAnimal(animal1);
            Player player2 = new Player("kiluaSum8", 2020);
            player2.addAnimal(animal3);
            player2.addAnimal(animal2);
            player1.Print();
            player2.Print();

            for (int i = 0; i < 20; i++)
            {
                player1.Rebirth();
                player1.Print();

            }
        }

        public void test1()//trade test
        {
            Player player1 = new Player("HogwartsMaster11", 100);
            Player player2 = new Player("SpellCaster9000", 500);

            players.Add(player1);
            players.Add(player2);

            Animal animal1 = new Animal("injured", 50, true);
            Animal animal2 = new Animal("neon", 10, false);
            Animal animal3 = new Animal("gold", 14, true);
            Animal animal4 = new Animal("diamond", 52, false);
            Animal animal5 = new Animal("giant", 23, false);
            Animal animal6 = new Animal("rainbow", 67, true);
            Animal animal7 = new Animal("exotic", 22, false);
            Animal animal8 = new Animal("boost", 11, true);

            animals = [animal1, animal2, animal3, animal4, animal5, animal6, animal7, animal8];

            player1.addAnimal(animals[0]);
            player1.addAnimal(animals[1]);
            player1.addAnimal(animals[2]);
            player1.addAnimal(animals[3]);
            player2.addAnimal(animals[4]);
            player2.addAnimal(animals[5]);
            player2.addAnimal(animals[6]);
            player2.addAnimal(animals[7]);

            player1.Print();
            player2.Print();

            //printOwnedAnimals(0);

            Trade(0, 1);
        }
        public void test2()
        {

        }
    }
}
