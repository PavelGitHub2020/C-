using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson1
{
    //Create a structure with name - Train,who contains the next fields:
    //Destination name, train number,departure time.
    //Enter the data in the array from 5 elements type train,sort 
    //the elements in trains number.
    //Add withdrawal possibility information about a train, who's number entered the users.
    //Add withdrawal sort the array in destination name where the train with the same name
    //must be sort by departure time.
    struct Train
    {
        public string destinationName;
        private int trainNumber;
        public string departureTime;
        private bool equal;

        Train[] trains;

        public void SettingTrainInformation()
        {
            trains = new Train[5];

            DateTime time = new DateTime(2021,4,15,11,7,23);

            for (int i = 0; i < trains.Length; i++)
            {
                string time1 = time.AddHours(i).ToShortTimeString();

                trains[i].destinationName = Destinations();
                trains[i].trainNumber = i + 1;
                trains[i].departureTime = time1;
            }
        }

        private string Destinations()
        {
            string destinations = "ABCDEFGHIJKLMNOP";

            Random random = new Random();

            StringBuilder stringBuilder = new StringBuilder(1);

            int position = random.Next(0, destinations.Length - 1);

            stringBuilder.Append(destinations[position]);

            return stringBuilder.ToString();
        }

        public void InformationAboutTrains()
        {
            Console.WriteLine("Information about trains:");

            for (int i = 0; i < trains.Length; i++)
            {
                Console.WriteLine($"Destination name - {trains[i].destinationName}\n" +
                                  $"Train number - {trains[i].trainNumber}\n" +
                                  $"Departure time - {trains[i].departureTime}\n");
            }
            Console.WriteLine();
        }

        private void RedialTrainNumber()
        {
            Console.WriteLine("Do you want to enter the number again? Yes - 1, No - 0");

            int choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
                InformationByTrainNumber();
            else if (choise == 0)
                return;
            else if (choise != 1 || choise != 0)
            {
                do
                {
                    Console.WriteLine("Only 1 to enter number again or 0 to end the operation!");
                    choise = Convert.ToInt32(Console.ReadLine());

                    if (choise == 1)
                        InformationByTrainNumber();
                    else if (choise == 0)
                        return;
                }
                while (choise != 0 || choise != 1);
            }
        }
        public void InformationByTrainNumber()
        {
            Console.WriteLine("Enter train number:");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            equal = false;

            for (int i = 0; i < trains.Length; i++)
            {
                if (trainNumber == trains[i].trainNumber)
                {
                    Console.WriteLine("Information about train:");
                    Console.WriteLine($"Destination name - {trains[i].destinationName}\n" +
                                  $"Train number - {trains[i].trainNumber}\n" +
                                  $"Departure time - {trains[i].departureTime}\n");
                    equal = true;
                    RedialTrainNumber();
                }
            }

            if (equal == false)
            {
                Console.WriteLine("There is no train with this number!");
                RedialTrainNumber();
            }
        }

        public void SortInformationByDestinationName()
        {
            Array.Sort(trains, new SortByDestinationName());
        }
    }
}
