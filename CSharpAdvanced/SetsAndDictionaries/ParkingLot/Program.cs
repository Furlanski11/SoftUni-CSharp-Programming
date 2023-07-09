using System;
using System.Collections.Generic;
using System.Data;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> parkingLot = new HashSet<string>();
            while((input= Console.ReadLine()) != "END") 
            {
                string[] index = input.Split(", ");
                string command = index[0];
                string numberPlate = index[1];
                if(command == "IN")
                {
                    parkingLot.Add(numberPlate);
                }
                else if(command == "OUT")
                {
                    parkingLot.Remove(numberPlate);
                }
            }
            if(parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var numberPlate in parkingLot)
            {
                Console.WriteLine(numberPlate);
            }
        }
    }
}
