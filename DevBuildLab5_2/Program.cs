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

        public virtual Roshambo GenerateRoshambo()
        {
            return Roshambo.scissors;
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
        static Status Play(Roshambo computerPlayer, Roshambo personPlayer)
        {
            if (computerPlayer == personPlayer)
            {
                return Status.draw;
            }

            else if (computerPlayer == Roshambo.paper && personPlayer == Roshambo.rock)
            {
                return Status.computerPlayer;
            }

            else if (computerPlayer == Roshambo.scissors && personPlayer == Roshambo.rock)
            {
                return Status.personPlayer;
            }

            else if (computerPlayer == Roshambo.rock && personPlayer == Roshambo.paper)
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
            Roshambo choiceRPS;
            string playerChoice;
            string team;
            Status person = new Status();

            Console.WriteLine("Welcome to Rock Paper Scissors!");

            
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Would you like to play against The Lions or the Tigers?");
            team = Console.ReadLine().ToLower();

            Console.Write("Rock, paper, or scissors? (R/P/S):");

            playerChoice = Console.ReadLine().ToLower();

            if (playerChoice == "rock")
            {
                choiceRPS = Roshambo.rock;
            }
            else if (playerChoice == "scissor")
            {
                choiceRPS = Roshambo.scissors;
            }
            else
            { 
                choiceRPS = Roshambo.rock; 
            }




            ///*** Need to Convert playerChoice to the enum Roshambo***
            
            
            if (team == "tigers")
            {

                TigersPlayer weapon = new TigersPlayer();
                randomPlay = weapon.GenerateRoshambo();
                Play(randomPlay, choiceRPS);
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
