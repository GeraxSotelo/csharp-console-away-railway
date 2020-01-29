using System;
using System.Collections.Generic;

namespace away_railway.Models
{
  class Train
  {
    public TrainStation CurrentTrainStation { get; set; }
    public List<Passenger> Dropoffs { get; set; } = new List<Passenger>();
    public double AccountBalance { get; set; } = 0.00;

    private void Setup()
    {
      //create train stations
      TrainStation Boise = new TrainStation("Boise", "BOI");
      TrainStation SunValley = new TrainStation("Sun Valley", "SUN");
      TrainStation LosAngeles = new TrainStation("Los Angeles", "LAX");
      TrainStation Denver = new TrainStation("Denver", "DEN");
      TrainStation Miami = new TrainStation("Miami", "MIA");
      TrainStation Dallas = new TrainStation("Dallas", "DFW");
      TrainStation Houston = new TrainStation("Houston", "HOU");
      TrainStation FortLauderdale = new TrainStation("Fort Lauderdale", "FLA");
      TrainStation Portland = new TrainStation("Portland", "PDX");
      TrainStation Phoenix = new TrainStation("Phoenix", "PHX");

      //create train station relationships
      Boise.AddDestination(SunValley);
      Boise.AddDestination(Denver);
      Boise.AddDestination(Portland);
      Boise.AddDestination(LosAngeles);
      SunValley.AddDestination(Denver);
      SunValley.AddDestination(Portland);
      LosAngeles.AddDestination(Phoenix);
      LosAngeles.AddDestination(Portland);
      LosAngeles.AddDestination(Denver);
      LosAngeles.AddDestination(Dallas);
      Denver.AddDestination(Phoenix);
      Denver.AddDestination(FortLauderdale);
      Phoenix.AddDestination(Dallas);
      Dallas.AddDestination(Houston);
      FortLauderdale.AddDestination(Miami);


      CurrentTrainStation = Boise;
    }

    public Train(TrainStation currentTrainStation, List<Passenger> dropoffs, double accountBalance)
    {
      Setup();
    }

  }
}