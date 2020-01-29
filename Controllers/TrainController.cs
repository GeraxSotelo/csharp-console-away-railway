using System;
using away_railway.Services;

namespace away_railway.Controllers
{
  class TrainController
  {
    private TrainService Service { get; set; } = new TrainService();
    private bool _running = true;

    public void Run()
    {
      Service.PrintTrips();
      while (_running)
      {
        PrintMessages();
        GetUserInput();
      }
      Console.Clear();
      Console.WriteLine("Watch your step");
    }

    private void GetUserInput()
    {
      string input = Console.ReadLine().ToUpper();
      switch (input)
      {
        case "Q":
        case "QUIT":
        case "EXIT":
          _running = false;
          break;
        default:
          Service.Travel(input);
          Service.PrintTrips();
          break;
      }
    }

    private void PrintMessages()
    {
      foreach (string msg in Service.Messages)
      {
        Console.WriteLine(msg);
      }
      Service.Messages.Clear();
    }
  }
}