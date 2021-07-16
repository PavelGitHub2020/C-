using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using static System.Console;

namespace XMLWorkHome
{
    class EntryPoint
    {
        //    С помощью класса XmlTextWriter напишите приложение,
        //сохраняющее в XML-файл информацию о заказах. Каждый 
        //заказ представляет собой несколько товаров. Информацию
        //характеризующую заказы и товары необходимо разработать
        //самостоятельно.
        //    Считайте информацию из Xml-документа, полученного
        //в первом задании с помощью классов XmlDocument и 
        //XmlTextReader и выведите полученную информацию на 
        //экран.
        static void Main(string[] args)
        {
            Order.GeneratingOrdersFile();

            List<Order> orders = new List<Order>();

            for (int i = 0; i < 2; i++)
            {
                orders.Add(new Order(i, i + 1));
                Order.SavingInformationAboutOrders();
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Order._nameFile);
                Order.OutputNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            WriteLine("=======================================================================");

            Order.ReadingInformationAboutOrders();
        }
    }
}
