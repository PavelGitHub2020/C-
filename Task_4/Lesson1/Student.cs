using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{
    //Create the struct with name Student, who contains the fields:Sername,Name,Middle Name,
    //number of groups,academic perfomance (Array of five elements).
    //Create the array of 10 elements the same type, sort records in ascending order of overage score
    //Add withdrawal possibility sername and numbers the student's group, who have the score 4 or 5.
    struct Student
    {
        private string sername;
        private string name;
        private string middleName;
        private int groupNumber;

        private int[] studentPerfomance;
        private double[] overageScore;
        private string[] honorsStudents;

        private void FillingInPersonalData()
        {
            Console.WriteLine("Enter the sername:");
            sername = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the name:");
            name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the middle name:");
            middleName = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the group number:");
            groupNumber = Convert.ToInt32(Console.ReadLine());
        }

        private void AcadimicPerfomance()
        {
            Random random = new Random();

            studentPerfomance = new int[5];

            for (int i = 0; i < studentPerfomance.Length; i++)
            {
                studentPerfomance[i] = random.Next(1, 6);
            }
        }

        private double OverageScore()
        {
            int sum = 0;
            double overageScore = 0;

            for (int i = 0; i < studentPerfomance.Length; i++)
            {
                sum += studentPerfomance[i];
            }

            overageScore = sum / studentPerfomance.Length;
            Math.Round(overageScore, MidpointRounding.ToPositiveInfinity);

            Console.WriteLine($"Overage score - {overageScore}");

            return overageScore;
        }

        public void ListPersonalData()
        {
            overageScore = new double[10];
            honorsStudents = new string[10];

            for (int i = 0; i < overageScore.Length; i++)
            {
                FillingInPersonalData();
                AcadimicPerfomance();
                ShowStudentPerfomance();
                overageScore[i] = OverageScore();
                if (overageScore[i] == 3 || overageScore[i] == 4)
                {
                   honorsStudents[i] = $"The {sername} from group {groupNumber} have overage score - {overageScore[i]}";
                }
            }
        }

        private void SortTheListOfOverageScore()
        {
            Array.Sort(overageScore);
        }

        public void ShowTheListOfOverageScore()
        {
            SortTheListOfOverageScore();

            Console.WriteLine("The list of overage score:");
            for (int i = 0; i < overageScore.Length; i++)
            {
                Console.Write($"{overageScore[i]}\t");
            }
        }

        private void ShowStudentPerfomance()
        {
            Console.WriteLine($"Sername - {sername}\nName - {name}\nMiddle name - {middleName}\nGroup number - {groupNumber}");

            Console.WriteLine("The list of the scores:");

            for (int i = 0; i < studentPerfomance.Length; i++)
            {
                Console.Write($"{studentPerfomance[i]}\t");
            }

            Console.WriteLine();
        }

        public void ShowHonorsStudents()
        {
            Console.WriteLine();

            Console.WriteLine("The list of honors students:");
            for (int i = 0; i < honorsStudents.Length; i++)
            {
                if (honorsStudents[i] != null)
                Console.WriteLine(honorsStudents[i]);
            }
        }
    }
}
