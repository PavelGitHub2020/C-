using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace Invoice
{
    
    class EntryPoint
    {
        static void Main(string[] args)
        {
            WriteReadFromFile writeReadFromFile = new WriteReadFromFile();
            writeReadFromFile.CreateAndWorkWithObject(10, true);
            WriteReadFromFile.DemonstrationJob();

            WriteLine("\nSerializationDeserialization:\n");

            InvoiceForPayment.BynarySerializationDeserialization();
            InvoiceForPayment.SoapSerializationDeserialization();
            InvoiceForPayment.JsonSerializationDeserialization();
        }
    }
}
