using TravelAgency;

internal class Program
{
  private static List<Itinerary> itineraries = new List<Itinerary>();

  private static void Main(string[] args)
  {
    Console.WriteLine("\nWelcome to Algonquin College Student Travel Agency!");

    while (true) 
    {
      Console.WriteLine();
      Console.WriteLine("Travel Agency Menu");
      Console.WriteLine("1. View all itineraries");
      Console.WriteLine("2. Add a new itinerary");
      Console.WriteLine("3. Change an existing itinerary");
      Console.WriteLine("4. Exit");
      Console.Write("\nEnter a choice: ");
      string? choice = Console.ReadLine();


      Console.WriteLine();
        switch (choice)
        {
          case "1":
            ViewItineraries();
            break;

          case "2":
            AddItinerary();
            break;

          case "3":
            ChangeItinerary();
            break;

          case "4":
            Console.WriteLine("Thank you for using Algonquin College Student Travel Agency!");
            return;

          default:
            Console.WriteLine("Not a valid input.");
            break;
        }
    }
    
  }
  


  /* 
  * GetReponse
  * Used to work with nullable strings from user response.
  * Will continue to prompt the user with an information request
  * Until the user provides a non-nullable value
  * @params: {string} information request
  * @returns: {string} user's response
  */
  static string GetResponse (string request) 
  {
    string? response = null;

    while (string.IsNullOrWhiteSpace(response))
    {
      Console.Write(request);
      response = Console.ReadLine();
    }

    return response;
  }


  private static void ViewItineraries()
  {
      if (itineraries.Count == 0)
      {
          Console.WriteLine("No itinerary exists in the system.");
          return;
      }

      for (int i = 0; i < itineraries.Count; i++)
      {
          var itinerary = itineraries[i];
          Console.WriteLine($"{i} - Passenger: {itinerary.PassengerName}, Departure: {itinerary.DepartureCity}, Arriving: {itinerary.ArrivalCity}, Cost: ${itinerary.Cost}");
      }
  }
 



  private static void AddItinerary()
  {
      string passengerName = GetResponse("Enter passenger's name: ");
      string departureCity = GetResponse("Enter departure city: ");
      string arrivalCity = GetResponse("Enter arrival city: ");
      Itinerary newItinerary = new Itinerary(passengerName, departureCity, arrivalCity);
      itineraries.Add(newItinerary);
      Console.WriteLine($"\n{passengerName}'s itinery has been added to the system, Cost: ${newItinerary.Cost}");
  }



  private static void ChangeItinerary()
  {
      if (itineraries.Count == 0)
      {
          Console.WriteLine("No itinerary exists in the system.");
          return;
      }

      int index;
      while (true)
      {
          string? indexInput = GetResponse($"Enter the index of the itinerary you want to change (0 to {itineraries.Count - 1}): ");
          if (int.TryParse(indexInput, out index) && index >= 0 && index < itineraries.Count)
          {
              break;
          }
          Console.WriteLine($"Invalid index. Please try again.\n");
      }

      var itinerary = itineraries[index];
      Console.WriteLine($"You have selected to change {itinerary.PassengerName}'s itinery.\n");

      string newDepartureCity = GetResponse("Enter new departure city: ");
      string newArrivalCity = GetResponse("Enter new arrival city: ");

      try
      {
          itinerary.ChangeItinerary(newDepartureCity, newArrivalCity);
          Console.WriteLine($"{itinerary.PassengerName}'s itinery has been changed. ${Itinerary.ChangeFee} change fee was applied.");
      }
      catch (Exception changeException)
      {
          Console.WriteLine($"\n{changeException.Message}");
      }
  }

}