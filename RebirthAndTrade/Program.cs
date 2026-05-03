namespace RebirthAndTrade.Data

{
    internal class Program
    {
        static List<Animal> animals = new List<Animal>();

        static void Main(string[] args)
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

            Player player1 = new Player("Hollargame1i2", 510, 15);
            player1.addAnimal(animal4);
            player1.addAnimal(animal1);
            Player player2 = new Player("kiluaSum8", 2020, 500);
            player2.addAnimal(animal3);
            player2.addAnimal(animal2);
            player1.Print();
            player2.Print();

            for (int i = 0; i < 9; i++)
            {
                player1.Rebirth();
                player1.Print();
            }


        }
    }
}
