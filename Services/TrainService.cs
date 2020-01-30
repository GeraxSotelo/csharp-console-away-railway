using System;
using System.Collections.Generic;
using System.Threading;
using away_railway.Models;

namespace away_railway.Services
{
  class TrainService
  {
    private Train Train { get; set; } = new Train();
    public List<string> Messages { get; set; } = new List<string>();
    public void PrintTrips()
    {
      Messages.Add($"\nRevenue: {Train.AccountBalance:c}\n");
      Messages.Add($"Welcome to {Train.CurrentTrainStation.Name}\n");
      Messages.Add("Destinations: ");
      foreach (var des in Train.CurrentTrainStation.Destinations)
      {
        Messages.Add($"{des.Key} -- {des.Value.Name}");
      }
      Messages.Add("\nWhere do you want to go next?");
      Messages.Add("Press (p) to check your passengers on board");
      Messages.Add("Press (q) to quit");
    }

    public void Travel(string input)
    {
      if (Train.CurrentTrainStation.Destinations.ContainsKey(input))
      {
        Console.Clear();
        travelling();
        Console.Clear();
        Train.CurrentTrainStation = Train.CurrentTrainStation.Destinations[input];
        Pickup();
        Deliver();
        return;
      }
      Console.Clear();
      Messages.Add("Invalid city\n");
    }

    public void Deliver()
    {
      if (Train.Dropoffs.Count > 0)
      {
        int delivered = Train.Dropoffs.RemoveAll(p =>
        {
          if (p.DestinationCode == Train.CurrentTrainStation.Code)
          {
            Train.AccountBalance += p.TicketCost;
            return true;
          }
          else { return false; }
        });
        Messages.Add($"Dropped off {delivered} passengers.");
      }
    }

    public void Pickup()
    {
      TrainStation station = Train.CurrentTrainStation;
      if (station.Pickups.Count > 0)
      {
        Train.Dropoffs.AddRange(station.Pickups);
        Messages.Add($"Picked up {station.Pickups.Count} passengers.");
        station.Pickups.Clear();
      }
      else
      {
        Messages.Add("No passengers to pickup at this location.");
      }
    }

    public void PassengersOnBoard()
    {
      Console.Clear();
      Messages.Add($"\n{Train.Dropoffs.Count} passengers on board\n");
      foreach (Passenger p in Train.Dropoffs)
      {
        Messages.Add($"Passenger going ot {p.DestinationCode}. Ticket Cost: {p.TicketCost:c}");
      }
      Messages.Add("\nPress any key to return.");
    }


    public void travelling()
    {
      Console.WriteLine(@"
                        (@@) (  ) (@)  ( )  @@    ()    @     O     @
                     (   )
                 (@@@@)
              (    )

            (@@@)
         ====        ________                ___________
     _D _|  |_______/        \__I_I_____===__|_________|
      |(_)---  |   H\________/ |   |        =|___ ___|      ________________
      /     |  |   H  |  |     |   |         ||_| |_||     _|
     |      |  |   H  |__--------------------| [___] |   =|
     | ________|___H__/__|_____/[][]~\_______|       |   -|
     |/ |   |-----------I_____I [][] []  D   |=======|____|_________________
   __/ =| o |=-O=====O=====O=====O \ ____Y___________|__|___________________
    |/-=|___|=    ||    ||    ||    |_____/~\___/          |_D__D__D_|  |_D_
     \_/      \__/  \__/  \__/  \__/      \_/               \_/   \_/    \_/");
      for (int i = 0; i < 50; i++)
      {
        Console.Write("-");
        Thread.Sleep(25);
      }
    }
  }
}