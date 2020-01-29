using System;
using System.Collections.Generic;
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
      Messages.Add($"Welcome to {Train.CurrentTrainStation.Name}");
      Messages.Add("Destinations: ");
      foreach (var des in Train.CurrentTrainStation.Destinations)
      {
        Messages.Add($"{des.Key} -- {des.Value.Name}");
      }
      Messages.Add("Where do you want to go next?");
    }
  }
}