using System;
using RPS.Models;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace RPS.Models
{
  public class Player
  {
    public KeyValuePair<string,string> Throw { get; set; }
    public static bool TryAgain = false;


    public Player(string player, string choice)
    {
      Throw = new KeyValuePair<string,string>(player,choice);
    }


    public static bool Setup()
    {
      Console.WriteLine("Player One, enter rock paper or scissors.\n");
      string PlayerOneResponse = Regex.Replace(Console.ReadLine().ToLower(), @"\s+", "");
      if(Player.TestInput(PlayerOneResponse) == false)
      {
        return true;
      }
      Console.WriteLine("Player Two, enter rock paper or scissors.\n");
      string PlayerTwoResponse = Regex.Replace(Console.ReadLine().ToLower(), @"\s+", "");
      Player.TestInput(PlayerTwoResponse);
      if(Player.TestInput(PlayerTwoResponse) == false)
      {
        return true;
      }
      Player P1 = new Player("Player One",PlayerOneResponse);
      Player P2 = new Player("Player Two",PlayerTwoResponse);
      Console.WriteLine(Player.Check(P1,P2));
      return false;
    }


    public static string Check(Player P1, Player P2)
    {
      if((P1.Throw.Value == "rock" || P2.Throw.Value == "rock") && (P1.Throw.Value == "scissors" || P2.Throw.Value == "scissors"))
      {
        return "Rock beats scissors.";
      } 
      else if((P1.Throw.Value == "rock" || P2.Throw.Value == "rock") && (P1.Throw.Value == "paper" || P2.Throw.Value == "paper")) 
      {
        return "Paper beats rock.";
      } 
      else if((P1.Throw.Value == "paper" || P2.Throw.Value == "paper") && (P1.Throw.Value == "scissors" || P2.Throw.Value == "scissors"))
      {
        return "Scissors beat paper.";
      }
      else 
      {
        return "Tie";
      }
    }

    
    public static bool TestInput(string str)
    {
      if(str != "rock" && str != "scissors" && str != "paper")
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Please enter rock, paper, or scissors.\n\n");
        Console.ResetColor();
        Thread.Sleep(1500);
        return false;
      }
      return true;
    }
  }
}