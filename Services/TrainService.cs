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
      Messages.Add($"Revenue: {Train.AccountBalance:c}\n");
      Messages.Add($"Welcome to {Train.CurrentTrainStation.Name}\n");
      Messages.Add("Destinations: ");
      foreach (var des in Train.CurrentTrainStation.Destinations)
      {
        Messages.Add($"{des.Key} -- {des.Value.Name}");
      }
      Messages.Add("\nWhere do you want to go next?");
    }

    public void Travel(string input)
    {
      if (Train.CurrentTrainStation.Destinations.ContainsKey(input))
      {
        Console.Clear();
        travelling();
        Console.Clear();
        Train.CurrentTrainStation = Train.CurrentTrainStation.Destinations[input];
        return;
      }
      Console.Clear();
      Messages.Add("Invalid input\n");
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
      for (int i = 0; i < 20; i++)
      {
        Console.Write("-");
        Thread.Sleep(100);
      }
    }
  }
}