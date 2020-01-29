namespace away_railway.Models
{
  public class Passenger
  {

    public string DestinationCode { get; set; }
    public int TicketCost { get; set; }

    public Passenger(string destinationCode, int ticketCost)
    {
      DestinationCode = destinationCode;
      TicketCost = ticketCost;
    }
  }
}