using System;

namespace human_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Human player1 = new Human("Conan the Barbarian",5,10,10,200);
            Human player2 = new Human("James Earl Jones",2,10,15,200);

            for(int xx = 0; xx < 5; xx++) {
                player1.Attack(player2);
                Console.WriteLine($"Attack by {player1.name}, {player2.name}'s health is now {player2.health}");
            }
        }
    }
}
