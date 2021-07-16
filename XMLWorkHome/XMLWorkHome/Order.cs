using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using static System.Console;

namespace XMLWorkHome
{
    /// <summary>
    /// The <c>Order</c> class provides information about orders and goods,
    /// also provides mothods for generating orders files, saving and reading 
    /// information about orders
    /// </summary>
    class Order
    {
        private static int _orderId;
        private static int _numberOfGoods;

        /// <summary>
        /// Used to have array name of goods
        /// </summary>
        private static string[] _nameOfGoods;

        /// <summary>
        /// <para name="_nameFile"></para>
        /// Used to have the address file, where saving
        /// information about orders
        /// </summary>
        public static string _nameFile = "order.xml";

        /// <summary>
        /// Constructor creating object of class Order 
        /// </summary>
        /// <param name="orderId"></param>
        /// Used to indicate orders id
        /// <param name="numberOfGoods"></param>
        /// Used to indicate number of goods
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="orderId"/> is negative.  
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="numberOfGoods"/> is negative.
        /// </exception>
        public Order(int orderId, int numberOfGoods)
        {
            if (orderId < 0)
            {
                throw new ArgumentNullException(nameof(orderId));
            }
            if (numberOfGoods < 0)
            {
                throw new ArgumentNullException(nameof(numberOfGoods));
            }

            _orderId = orderId;
            _numberOfGoods = numberOfGoods;

            _nameOfGoods = new string[numberOfGoods];

            for (int i = 0; i < numberOfGoods; i++)
            {
                WriteLine("Enter the name of goods");
                _nameOfGoods[i] = ReadLine();
            }
        }

        /// <summary>
        /// <para name="PrintOrder()"></para>
        /// The method which allows to show information about orders
        /// </summary>
        public void PrintOrder()
        {
            WriteLine("orderId - " + _orderId);
            WriteLine("numberOfGoods - " + _numberOfGoods);
            for (int i = 0; i < _numberOfGoods; i++)
            {
                WriteLine("nameOfGoods - " + _nameOfGoods[i]);
            }
        }

        /// <summary>
        /// <para name="GeneratingOrdersFile()"></para>
        /// The method used to create file for saving,
        /// reading information about orders
        /// </summary>
        public static void GeneratingOrdersFile()
        {
            XmlTextWriter saving = null;
            try
            {
                saving = new XmlTextWriter(_nameFile, Encoding.Unicode);
                saving.Formatting = Formatting.Indented;
                saving.WriteStartDocument();
                saving.WriteStartElement("Orders");
                saving.WriteStartElement("Order");
                saving.WriteAttributeString("Image", "MyOrder.jpeg");
                saving.WriteEndElement();
                WriteLine("The Order.xml file is generated!");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (saving != null)
                    saving.Close();
            }
        }

        /// <summary>
        /// <para name="SavingInformationAboutOrders()"></para>
        /// The method used to saving information about orders
        /// </summary>
        public static void SavingInformationAboutOrders()
        {
            XmlDocument document = new XmlDocument();
            document.Load(_nameFile);
            XmlNode node = document.DocumentElement;

            XmlNode order = document.CreateElement("Order");
            XmlNode orderId = document.CreateElement("orderId");
            XmlNode numberOfGoods = document.CreateElement("numberOfGoods");
            XmlNode nameOfGoods = document.CreateElement("nameOfGoods");

            XmlNode text1 = document.CreateTextNode(XmlConvert.ToString(_orderId));
            XmlNode text2 = document.CreateTextNode(XmlConvert.ToString(_numberOfGoods));
            for (int i = 0; i < _numberOfGoods; i++)
            {
                XmlNode text3 = document.CreateElement(_nameOfGoods[i]);
                nameOfGoods.AppendChild(text3);
            }
            orderId.AppendChild(text1);
            numberOfGoods.AppendChild(text2);

            order.AppendChild(orderId);
            order.AppendChild(numberOfGoods);
            order.AppendChild(nameOfGoods);

            node.AppendChild(order);

            document.Save(_nameFile);
        }

        /// <summary>
        /// <para name="OutputNode(XmlNode node)"></para>
        /// The method used to have information about all nodes
        /// </summary>
        /// <param name="node"></param>
        /// The field by which all information is taken
        public static void OutputNode(XmlNode node)
        {
            WriteLine($"Type = {node.NodeType}\tName = {node.Name}\tValue = {node.Value}");

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    WriteLine($"Type = {attr.NodeType}\tName = {attr.Name}\tValue = {attr.Value}");
                }
            }

            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    OutputNode(child);
                }
            }
        }

        /// <summary>
        /// <para name="ReadingInformationAboutOrders()"></para>
        /// The method used to reading information about orders
        /// </summary>
        public static void ReadingInformationAboutOrders()
        {
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(_nameFile);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                while (reader.Read())
                {
                    WriteLine($"Type = {reader.NodeType}\tName = {reader.Name}\tvalue = {reader.Value}");

                    if (reader.AttributeCount > 0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            WriteLine($"Type = {reader.NodeType}\tName = {reader.Name}\tvalue = {reader.Value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
