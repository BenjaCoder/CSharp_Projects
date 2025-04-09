using System;
using System.Threading;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Random random = new Random();
        GameIntro();
        Player p1 = GetUserPlayer();
        Console.WriteLine($"Hello {p1.Name}, and welcome to the game!");
        Thread.Sleep(1000);
        Player p2 = CreateNPC(1);
        Player p3 = CreateNPC(2);
        Console.WriteLine($"Looks like our players today are {p1.Name}, {p2.Name}, and {p3.Name}!");
        Dictionary<string, string[]> puzzles = GetPuzzles();
        string firstPuzzle = puzzles["Show Biz"][random.Next(puzzles["Show Biz"].Length)];
        string firstPuzzleObscured = CreateBlankPuzzle(firstPuzzle);
        Console.WriteLine("Okay folks, here comes our first puzzle!");
        Console.WriteLine(firstPuzzleObscured);


        Console.Write("Enter 'quit' to exit: ");
        string optionToQuit = Console.ReadLine();
        while (optionToQuit.ToLower() != "quit") {
            Console.Write("Enter 'quit' to exit: ");
            optionToQuit = Console.ReadLine();
        }
        Console.Write("\nGoodbye :)\n");
    }

    static void GameIntro() {
        Console.WriteLine(@"Welcome to ""Wheel of Fortune""!");
        Thread.Sleep(1000);
        Console.WriteLine("Get ready to play 3 rounds from 3 different categories, with 2 other players!");
    }

    static Player GetUserPlayer() {
        Player p1 = new Player();
        Console.Write("Name: ");
        string? yourName = Console.ReadLine();
        p1.Name = yourName;
        return p1;
    }

    static Player CreateNPC(int gender) {
        Player player = new Player();
        Random randInd = new Random();
        if (gender == 1) {
            string[] names = ["John", "Mike", "Steve", "Mark", "Bill"];
            player.Name = names[randInd.Next(names.Length)];
        }
        else {
            string[] names = ["Kate", "Mary", "Jen", "Wendy", "Beth"];
            player.Name = names[randInd.Next(names.Length)];
        }
        return player;
    }

    static Dictionary<string, string[]> GetPuzzles() {
        Dictionary<string, string[]> puzzles = new Dictionary<string, string[]>();
        puzzles.Add("Show Biz", ["BEST MUSIC VIDEO", "LIGHTS, CAMERA, ACTION!", "CHILDREN'S PUPPET SHOW", "CLASSIC HORROR MOVIES"]);
        puzzles.Add("Event", ["A BIG FAMILY GATHERING", "EPIC WINTER ADVENTURE", "ELABORATE STATE CEREMONY", "GRAND SLAM HOME RUN"]);
        puzzles.Add("Living Things", ["A PACK OF WOLVES", "A LITTER OF PUPPIES", "BEAUTIFUL TROPICAL FISH", "RING-NECKED PHEASANT"]);
        return puzzles;
    }

    static string CreateBlankPuzzle(string puzzle) {
        string result = "";
        foreach (char character in puzzle) {
            int charCode = (int)character;
            if (charCode >= 65 && charCode <= 90) {
                result += "_";
            }
            else {
                result += character;
            }
        }
        return result;
    }
}

class Player {
    public string? Name { get; set; }
    public int? Score { get; set; }

    public Player()
    {
        Name = "Unknown";
        Score = 0;
    }
        
}