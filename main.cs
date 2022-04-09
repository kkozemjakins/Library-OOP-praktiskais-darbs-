using System;

class Program 
{
  public static void Main (string[] args) {
    //Pirmā bibliotēka
    Library Library1 = new Library("Rīgas Centrālā bibliotēka",Convert.ToDateTime("12:00"),Convert.ToDateTime("20:00"),2000000,"Rīga", "Centrs");
    //Otrā bibliotēka
    Library Library2 = new Library("Latvijas Nacionālā bibliotēka",Convert.ToDateTime("08:00"),Convert.ToDateTime("23:00"),4000000,"Rīga", "Zemgales priekšpilsēta");

    Library1.PrintInfo();
    Library1.IsWorkingNow();
    Library1.Statistic();
    Library1.BookStatistic();

    Library2.PrintInfo();
    Library2.IsWorkingNow();
    Library2.Statistic();
    Library2.BookStatistic();

    Console.WriteLine($"\nNumber of libraries:{Library.AmountOfObjects()}");
  }

}