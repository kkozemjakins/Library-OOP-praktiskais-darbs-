using System;

class Library{
  private string Name;
  private DateTime StartTime;
  private DateTime EndTime;
  private int BooksNumber;
  private string City;
  private string District;

  private static int ObjectNumbers = 0;

  private DateTime CurrentTime = DateTime.Now;
  private DateTime MidNight = DateTime.Today;
  private TimeSpan Difference;

  private int Visits;
  private int Visitors;
  private int VisitorsTookBooks;
  private int VisitorsGaveBooks;
  private Random rnd = new Random();

  private int TookBooks;
  private int GaveBooks;
  private int Books;
  private int BooksSum;

  //Konstruktors mainīgo nosaukšanai
  public Library(string name, DateTime startTime, DateTime endTime, int bookNumbers, string city, string district){
    Name = name;
    StartTime = startTime;
    EndTime = endTime;
    BooksNumber = bookNumbers;
    City = city;
    District = district;

  }
  //Izvadīt informāciju par bibliotēku
  public void PrintInfo(){
    ObjectNumbers++;
    Console.WriteLine($"\n-------{ObjectNumbers}.{Name}-------\nWorking Hours: {StartTime.TimeOfDay} - {EndTime.TimeOfDay}\nNumber of books: {BooksNumber}\nCity: {City}\nDistrict: {District}");
  }
  //Bibliotēkas darba laika un laika izvadīšana pirms atvēršanas/slēgšanas
  public void IsWorkingNow(){
      CurrentTime = CurrentTime.AddHours(2);


      if(TimeSpan.Compare(CurrentTime.TimeOfDay, StartTime.TimeOfDay) >= 0  && TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == -1){
        Difference = EndTime.TimeOfDay - CurrentTime.TimeOfDay;

        Console.WriteLine("\nLibrary is open now.");
        Console.WriteLine($"Library will close in {Difference.ToString(@"hh\:mm\:ss")}");

      }
      else{
          if(TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == 1){

              Difference = -CurrentTime.TimeOfDay + StartTime.TimeOfDay;

              Difference += TimeSpan.FromHours(24);

              Console.WriteLine("\nLibrary is closed.");
              Console.WriteLine($"Library will open in {Difference.ToString(@"hh\:mm\:ss")}");
          }
          else{
              Difference = CurrentTime.TimeOfDay - StartTime.TimeOfDay;

              Console.WriteLine("\nLibrary is closed.");
              Console.WriteLine($"Library will open in {Difference.ToString(@"hh\:mm\:ss")}");
          }



        
            
      }


  
  }
  //Metode objektu saskaitīšanai
  public static int AmountOfObjects(){

       return ObjectNumbers;
  }
  //Apmeklētāju skaits (cik paņēma/atdeva grāmatas)
  public void Statistic(){
    if(TimeSpan.Compare(CurrentTime.TimeOfDay, StartTime.TimeOfDay) >= 0  && TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == -1 || TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == 1){
      Visits = rnd.Next(100,750);
  
      VisitorsGaveBooks = rnd.Next(1,Visits);
      VisitorsTookBooks = rnd.Next(1,Visits);
      if(Visits > VisitorsTookBooks + VisitorsGaveBooks){
          Visitors = Visits - (VisitorsTookBooks + VisitorsGaveBooks);
      }
  
  
      Console.WriteLine($"\nTodays visits:{Visits}\nJust visitors:{Visitors}\nVisitors who gave books:{VisitorsGaveBooks}\nVisitors who took books:{VisitorsTookBooks}");
    }
    else{
      Console.WriteLine("Statistics will be after the opening of the library");
    }

  }
//Grāmatu skaits (cik iedeva/paņēma)
  public void BookStatistic(){
    if(TimeSpan.Compare(CurrentTime.TimeOfDay, StartTime.TimeOfDay) >= 0  && TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == -1 || TimeSpan.Compare(CurrentTime.TimeOfDay, EndTime.TimeOfDay) == 1){
      for(int n = 0; n < VisitorsGaveBooks; n++){
          Books = rnd.Next(1,3);
          GaveBooks = GaveBooks + Books;

      }
      for(int n = 0; n < VisitorsTookBooks; n++){
          Books = rnd.Next(1,3);
          TookBooks = TookBooks + Books;
          
      }

      BooksSum = BooksNumber + GaveBooks - TookBooks; 

      Console.WriteLine($"\nBooks sum: {BooksSum}\nGave books(+): {GaveBooks}\nTook books(-): {TookBooks}");
    }
  }


}