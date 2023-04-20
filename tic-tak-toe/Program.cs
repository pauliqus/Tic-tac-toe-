using System;

namespace tic_tak_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "tic-tac-toe"; 
            
            Console.WriteLine("Start quick game!");
            QuickGame();
        }

        public static void QuickGame()
        {

            string[] values = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // номера ячеек

            Console.Write("First member enter your name: ");
            string firstMember = Console.ReadLine();

            Console.Write("Second member enter your name: ");
            string secondMember = Console.ReadLine();
            
            Console.Clear();

            Field(values); // поле с нумерацией

            for (int i = 0; i < 9; i++)
            {
                if(PersonMove(firstMember,ref values, "X") == 0) break; // ход первого чемпиона
                if (PersonMove(secondMember,ref values, "Y") == 0) break; // ход второго чемпиона
            }

            Console.Clear();
            Console.WriteLine("1 more game? 1.Yes 2.No");
            
            string inp = Console.ReadLine();
            if(inp != null && int.Parse(inp) == 1) QuickGame();
        }

        static public int PersonMove(string member,ref string[] values, string symb)
        {
            Console.WriteLine($"\n{member} enter your point:");
            string secondUserInput = Console.ReadLine();

            while (int.Parse(secondUserInput) > 9 || int.Parse(secondUserInput) < 0 || values[int.Parse(secondUserInput) - 1] == "X" || values[int.Parse(secondUserInput) - 1] == "Y")
            {
                Console.WriteLine("Incorrect input!");
                secondUserInput = Console.ReadLine();
            }
            
            values[int.Parse(secondUserInput) - 1] = symb;

            Console.Clear();
            Field(values);

            if (CheckField(values))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{member} Winner! ");
                Console.ReadKey();
                Console.ResetColor();
                return 0;
            }

            return 1;
        }

        

        public static bool CheckField(string[] points)
        {
            if (points[0] == "X" && points[1] == "X" && points[2] == "X" ||
                points[3] == "X" && points[4] == "X" && points[5] == "X" ||
                points[6] == "X" && points[7] == "X" && points[8] == "X" ||
                points[0] == "X" && points[3] == "X" && points[6] == "X" ||
                points[1] == "X" && points[4] == "X" && points[7] == "X" ||
                points[2] == "X" && points[5] == "X" && points[8] == "X" ||
                points[0] == "X" && points[4] == "X" && points[8] == "X" ||
                points[2] == "X" && points[4] == "X" && points[6] == "X"
               )
                return true;
            else if (points[0] == "Y" && points[1] == "Y" && points[2] == "Y" ||
                     points[3] == "Y" && points[4] == "Y" && points[5] == "Y" ||
                     points[6] == "Y" && points[7] == "Y" && points[8] == "Y" ||
                     points[0] == "Y" && points[3] == "Y" && points[6] == "Y" ||
                     points[1] == "Y" && points[4] == "Y" && points[7] == "Y" ||
                     points[2] == "Y" && points[5] == "Y" && points[8] == "Y" ||
                     points[0] == "Y" && points[4] == "Y" && points[8] == "Y" ||
                     points[2] == "Y" && points[4] == "Y" && points[6] == "Y")
                return true;


            return false;
        }

        public static void Field(string[] values) // игровое поле 
        {
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {values[0]} | {values[1]} | {values[2]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {values[3]} | {values[4]} | {values[5]} |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine($"| {values[6]} | {values[7]} | {values[8]} |");
            Console.WriteLine("|---|---|---|");
        }
        
    }
}