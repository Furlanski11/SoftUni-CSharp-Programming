using System;
using System.Reflection.Metadata.Ecma335;
using Telephony;


ISmartphone smartphone = new Smartphone();
IStationaryPhone stationaryPhone = new StationaryPhone();
string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


foreach (var number in numbers)
{
    try
    {
        if (number.Length > 7)
        {
            smartphone.Calling(number);
        }
        else
        {
            stationaryPhone.Calling(number);
        }
    }

    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }

}

foreach (var url in urls)
{
    try
    {
        smartphone.Browsing(url);
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
}
