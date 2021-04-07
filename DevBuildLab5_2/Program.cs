using System;

namespace DevBuildLab5_2
{
    enum Roshambo
    {
        rock,
        paper,
        scissors
    }

    enum Status
    {
        computerPlayer,
        personPlayer,
        draw
    }

    class Player
    {
        public string playerName;
        public Roshambo playerChoice;

        public virtual Roshambo GenerateRoshambo()
        {
            return this.playerChoice;
        }
    }

    class LionsPlayer : Player // Always Rock
    {

        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.rock;
        }

    }

    class TigersPlayer : Player // Random
    {

        public override Roshambo GenerateRoshambo()
        {
            Random rand = new Random();
            int num = rand.Next(0, 3);
            return (Roshambo)num;
        }

    }

    class GamePlayer : Player // User input and 
    {
         
    }

    class Program
    {
        static Status Play(Player computerPlayer, Player personPlayer)
        {
            if (computerPlayer.playerChoice == personPlayer.playerChoice)
            {
                return Status.draw;
            }

            else if (computerPlayer.playerChoice == Roshambo.paper && personPlayer.playerChoice == Roshambo.rock)
            {
                return Status.computerPlayer;
            }

            else if (computerPlayer.playerChoice == Roshambo.scissors && personPlayer.playerChoice == Roshambo.rock)
            {
                return Status.personPlayer;
            }

            else if (computerPlayer.playerChoice == Roshambo.rock && personPlayer.playerChoice == Roshambo.paper)
            {
                return Status.personPlayer;
            }

            else //(computerPlayer.playerChoice == Roshambo.rock && personPlayer.playerChoice == Roshambo.scissors)
            {
                return Status.computerPlayer;
            }
            

        }

        static void Main(string[] args)
        {
            Roshambo randomPlay;
            Roshambo rockchoice;
            string team;
            Roshambo playerChoice;
            Status person;

            Console.WriteLine("Welcome to Rock Paper Scissors!");

            
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Would you like to play against The Lions or the Tigers?");
            team = Console.ReadLine().ToLower();

            Console.Write("Rock, paper, or scissors? (R/P/S):");
            playerChoice = Convert.ro
                Console.ReadLine().ToLower();
            
            if (team == "tigers")
            {
                TigersPlayer rnd = new TigersPlayer();
                randomPlay = rnd.GenerateRoshambo();
                Console.WriteLine(randomPlay);
                person = Play(randomPlay, playerChoice);
            }
            else
            {
                LionsPlayer rock = new LionsPlayer();
                rockchoice = rock.GenerateRoshambo();
                Console.WriteLine(rockchoice);
            }
            
            
            if (person == Status.computerPlayer)
            {
                Console.WriteLine("Computer Wins");
            }
            else if (person == Status.personPlayer)
            {
                Console.WriteLine($"{playerName} wins!");
            }
            else
                Console.WriteLine("Draw");

        }
    }
}
