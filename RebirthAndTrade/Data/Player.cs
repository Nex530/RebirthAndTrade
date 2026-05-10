using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RebirthAndTrade.Data
{
    enum RebirthType
    {
        rookie=0, novice, apprentice, samurai, assasin, warrior, ninja, masterNinja, sensei
    }
    public class Player
    {
        private string name;
        private int money;
        private List<Animal> OwnedAnimals = new List<Animal>();
        private RebirthType curRebirth;
        private double multiplierM=1;
        public Player(string inputName, int inputMoney)
        {
            name = inputName;
            money = inputMoney < 0 ? 0 : inputMoney;
            curRebirth = RebirthType.rookie;
        }

        public void Rebirth()
        {
            if (curRebirth == RebirthType.sensei) return;
            money = 0;
            switch (curRebirth)
            {
                case RebirthType.rookie:
                    curRebirth += 1;
                    multiplierM = 1.1;
                    return;
                case RebirthType.novice:
                    curRebirth += 1;
                    multiplierM = 1.2;
                    return;
                case RebirthType.apprentice:
                    curRebirth += 1;
                    multiplierM = 1.32;
                    return;
                case RebirthType.samurai:
                    curRebirth += 1;
                    multiplierM = 1.4;
                    return;
                case RebirthType.assasin:
                    curRebirth += 1;
                    multiplierM = 1.6;
                    return;
                case RebirthType.warrior:
                    curRebirth += 1;
                    multiplierM = 2;
                    return;
                case RebirthType.ninja:
                    curRebirth += 1;
                    multiplierM = 2.15;
                    return;
                case RebirthType.masterNinja:
                    curRebirth += 1;
                    multiplierM = 2.3;
                    return;
            }
        }

        public void addAnimal(Animal animal)
        {
            OwnedAnimals.Add(animal);
        }

        public void removeAnimal(int index)
        {
            OwnedAnimals.RemoveAt(index);
        }

        public void Print()
        {
            Console.Write("Player " + name + " has " + money + " money , " + multiplierM+" multiplier, and current rebirth is " + curRebirth);
            if (OwnedAnimals.Count != 0)
            {
                Console.WriteLine(". And animals: ");
                for (int i = 0; i < OwnedAnimals.Count; i++) {
                    Console.Write((i+1)+". ");
                    OwnedAnimals[i].Print();
                }
            }
            Console.WriteLine("\n");
        }
        public string getName() { return name; }
        public List<Animal> GetAnimals() { return OwnedAnimals; }
    }
}
