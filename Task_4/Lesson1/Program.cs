using System;
using System.Linq;

namespace Lesson1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Student student = new Student();
            //student.ListPersonalData();
            //student.ShowTheListOfOverageScore();
            //student.ShowHonorsStudents();

            Train trains = new Train();
            trains.SettingTrainInformation();
            trains.InformationAboutTrains();
            // trains.InformationByTrainNumber();
            trains.SortInformationByDestinationName();
            Console.Write("Information after sort!");
            Console.WriteLine();
            trains.InformationAboutTrains();
        }

        
    }
}
