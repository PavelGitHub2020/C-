using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

namespace Invoice
{
    class WriteReadFromFile
    {
        private InvoiceForPayment payment;

        /// <summary>
        /// data - массив string для хранения иформации созданных обьектов
        /// </summary>
        /// <param name="data"></param>
        private static string[] data;

        /// <summary>
        /// size - кол-во созданных обьектов класса
        /// IsFlag - для форматирования обьектов этого класса,
        /// если true, тогда сериализуются и десериализуются
        /// все поля, если false - вычисляемые поля не сериализуются.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="isFlag"></param>
        public void CreateAndWorkWithObject(int size, bool isFlag)
        {
            data = new string[size];

            for (int i = 1; i < size; i++)
            {
                payment = new InvoiceForPayment(i, i * 3, isFlag);
                payment.AmountPenalty();
                payment.AmountForPaidWithoutPenalty();
                payment.TotalAmount();
                InvoiceForPayment.invoice1.Add(payment);

                data[i - 1] = payment.ToString();
            }
        }

        public static void WriteFile(FileInfo f)
        {
            using (FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                for (int i = 1; i < data.Length; i++)
                {
                    byte[] wryteBytes = Encoding.Default.GetBytes(data[i - 1]);
                    fs.Write(wryteBytes, 0, wryteBytes.Length);
                }
                WriteLine("Data recorded\n\n");
            }
        }

        public static string ReadFile(FileInfo f)
        {
            WriteLine("Read data from the file:\n");
            using (FileStream fs = f.OpenRead())
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                return Encoding.Default.GetString(readBytes);
            }
        }

        public static void DemonstrationJob()
        {
            DirectoryInfo dir = new DirectoryInfo(@"B:\Demonstration");

            if (!dir.Exists)
            {
                dir.Create();
            }

            WriteLine($"Last access file to the directory: {dir.LastAccessTime}");

            DirectoryInfo dir1 = dir.CreateSubdirectory("Subdir1");

            WriteLine($"Full path to the directory:\n{dir1.FullName}");

            FileInfo fInfo = new FileInfo(dir1 + @"\Demonstration.bin");

            WriteFile(fInfo);

            WriteLine(ReadFile(fInfo));

            WriteLine($"\nOnly files with the extension '.bin':");

            FileInfo[] files = dir1.GetFiles("*.bin");

            foreach (FileInfo f in files)
            {
                WriteLine($"{f}\n");
            }
        }
    }
}
