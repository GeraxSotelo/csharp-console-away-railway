using System.Collections.Generic;
namespace away_railway.Models
{
  class TrainStation
  {
    public string Name { get; set; }
    public string Code { get; set; }
    public Dictionary<string, TrainStation> Destinations { get; set; } = new Dictionary<string, TrainStation>();
    public List<Passenger> Pickups { get; set; } = new List<Passenger>();

    public void AddDestination(TrainStation des)
    {
      Destinations.Add(des.Code, des);
      //add this destination to the one coming in
      des.Destinations.Add(Code, this);
    }

    public TrainStation(string name, string code, Dictionary<string, TrainStation> destinations, List<Passenger> pickups)
    {
      Name = name;
      Code = code;
      Destinations = destinations;
      Pickups = pickups;
    }
  }
}