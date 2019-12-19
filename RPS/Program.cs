using System;
using RPS.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RPS.Models {
  public class Program{
    static void Main()
    {
      while(true)
      {
        if(Player.Setup())
        {
          Main();
        }
        break;
      }
    }
  }
}