using System;
using away_railway.Controllers;

namespace away_railway
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      TrainController tc = new TrainController();
      tc.Run();
    }
  }
}
