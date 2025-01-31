namespace w1_assignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");

            var menuOption = Console.ReadLine();

            if (menuOption == "1")
            {
                var lines = File.ReadAllLines("input.csv");
                for (int i = 0; i < lines.Length; i++)
                {
                    var cols = lines[i].Split(",");

                    var name = cols[0];
                    var profession = cols[1];
                    var level = cols[2];
                    var hitPoints = cols[3];
                    var equipment = cols[4];

                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Job: {profession}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"Hit Points: {hitPoints}");
                    Console.WriteLine($"Equipment: {equipment}");
                    Console.WriteLine();
                }
            }
            else if (menuOption == "2")
            {
                Console.WriteLine("Enter character details:");

                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Profession: ");
                var profession = Console.ReadLine();

                Console.Write("Level: ");
                var level = Console.ReadLine();

                Console.Write("Hit Points: ");
                var hitPoints = Console.ReadLine();

                Console.Write("Equipment: ");
                var equipment = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter("input.csv", true))
                {
                    writer.WriteLine($"{name},{profession},{level},{hitPoints},{equipment}");
                }

                Console.WriteLine("Character added successfully!");
            }
            else if (menuOption == "3")
            {
                var lines = File.ReadAllLines("input.csv").ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    var cols = lines[i].Split(",");
                    var name = cols[0];
                    var profession = cols[1];
                    var level = cols[2];
                    var hitPoints = cols[3];
                    var equipment = cols[4];

                    Console.WriteLine($"{i + 1}. {name} - {profession}, Level: {level}");
                }

                Console.WriteLine("Enter the number of the character to level up:");
                var characterIndex = int.Parse(Console.ReadLine()) - 1;

                if (characterIndex >= 0 && characterIndex < lines.Count)
                {
                    var cols = lines[characterIndex].Split(",");
                    var name = cols[0];
                    var profession = cols[1];
                    var level = int.Parse(cols[2]) + 1;
                    var hitPoints = cols[3];
                    var equipment = cols[4];

                    lines[characterIndex] = $"{name},{profession},{level},{hitPoints},{equipment}";

                    File.WriteAllLines("input.csv", lines);
                    Console.WriteLine("Character leveled up successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid character selection.");
                }
            }
            else
            {
                Console.WriteLine("Invalid menu option.");
            }
        }
    }
}