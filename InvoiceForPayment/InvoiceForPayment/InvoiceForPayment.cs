using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
using static System.Console;
using System.ComponentModel.DataAnnotations;
using SolrNet.Utils;
using System.Runtime.Serialization;
using static System.Xml.Serialization.XmlIgnoreAttribute;
using System.Security.Permissions;

namespace Invoice
{
    //    Разработать класс Счет для оплаты. В классе предусмотреть
    //следующие поля:
    //--оплата за день
    //--кол-во дней
    //--штраф за один день задержки оплаты
    //--кол-во дней задержки оплаты
    //--сумма к оплате без штрафа(вычисляемое поле)
    //--штраф(вычисляемое поле)
    //--общая сумма к оплате(вычисляемое поле)

    //    В классе обьявить статическое свой-во типа bool,
    //значение которого влияет на процесс форматирования 
    //обьектов это класса. Если значение этого свой-ва 
    //равно true, тогда сериализуются и десериализуются
    //все поля, если false - вычисляемые поля не сериализуются

    //    Разработать приложение, в котором необходимо про-
    //демонстрировать использование этого класса, результаты
    //должны записываться и считываться из файла
    [Serializable]
    public class InvoiceForPayment : ISerializable
    {
        private static double paymentPerDay;
        private static double oneDayPenaltyForLatePayment;

        private int _amountOfDays;
        private int _numberOfDayOfPaymentDelay;

        private double amountToBePaidWithoutPenalty;
        private double penalty;
        private double totalAmountPayable;

        private static bool IsFlag { get; set; }

        public static List<InvoiceForPayment> invoice1 = new List<InvoiceForPayment>();

        public InvoiceForPayment() { }
        public InvoiceForPayment(int numberOfDayOfPaymentDelay, int amountOfDays, bool isFlag)
        {
            if (numberOfDayOfPaymentDelay < 0)
            {
                throw new ArgumentException(nameof(numberOfDayOfPaymentDelay));
            }
            if (amountOfDays < 0)
            {
                throw new ArgumentException(nameof(amountOfDays));
            }

            _numberOfDayOfPaymentDelay = numberOfDayOfPaymentDelay;
            _amountOfDays = amountOfDays;
            IsFlag = isFlag;
        }

        static InvoiceForPayment()
        {
            paymentPerDay = 23;
            oneDayPenaltyForLatePayment = 11.3;
        }

        public double AmountForPaidWithoutPenalty()
        {
            amountToBePaidWithoutPenalty = paymentPerDay * _amountOfDays;
            
            return amountToBePaidWithoutPenalty;
        }

        public double AmountPenalty()
        {
            penalty = oneDayPenaltyForLatePayment * _numberOfDayOfPaymentDelay;

            return penalty;
        }

        public double TotalAmount()
        {
            totalAmountPayable = amountToBePaidWithoutPenalty + penalty;

            return totalAmountPayable;
        }

        public override string ToString()
        {
            return $"Payment per day - {paymentPerDay}$\n" +
                   $"Amount of days - {_amountOfDays} days\n" +
                   $"One day penalty for late payment - {oneDayPenaltyForLatePayment}$\n" +
                   $"Number of day of payment delay - {_numberOfDayOfPaymentDelay} day(s)\n" +
                   $"Amount to be payment without penalty - {amountToBePaidWithoutPenalty}$\n" +
                   $"Penalty - {penalty}$\n" +
                   $"Total amount paylable - {totalAmountPayable}$\n\n";
        }

        public static void BynarySerializationDeserialization()
        {
            var binFormatter = new BinaryFormatter();

            using (FileStream file = new FileStream("invoice.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, invoice1);
            }

            using (FileStream file = new FileStream("invoice.bin", FileMode.OpenOrCreate))
            {
                if (binFormatter.Deserialize(file) is List<InvoiceForPayment> newInvoice)
                {
                    foreach (InvoiceForPayment inv in newInvoice)
                    {
                        WriteLine(inv);
                    }
                }
            }
        }

        public static void SoapSerializationDeserialization()
        {
            SoapFormatter soapFormatter = new SoapFormatter();

             using (FileStream file = new FileStream("invoice.soap", FileMode.OpenOrCreate))
             {
                soapFormatter.Serialize(file, invoice1);
             }
            
            using (FileStream file = new FileStream("invoice.soap", FileMode.OpenOrCreate))
            {
                if (soapFormatter.Deserialize(file) is List<InvoiceForPayment> newInvoice)
                {
                    foreach (InvoiceForPayment inv in newInvoice)
                    {
                        WriteLine(inv);
                    }
                }
            }
        }

        public static void XmlSerializationDeserialization()
        {
            //Для XML сериализации поля класса должны быть публичными
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(List<InvoiceForPayment>));

            using (FileStream file = new FileStream("invoice.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, invoice1);
            }

            using (FileStream file = new FileStream("invoice.xml", FileMode.OpenOrCreate))
            {
                if (xmlFormatter.Deserialize(file) is List<InvoiceForPayment> newInvoice)
                {
                    foreach (InvoiceForPayment inv in newInvoice)
                    {
                        WriteLine(inv);
                    }
                }
            }
        }

        public static void JsonSerializationDeserialization()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<InvoiceForPayment>));

            using (FileStream file = new FileStream("invoice.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, invoice1);
            }

            using (FileStream file = new FileStream("invoice.json", FileMode.OpenOrCreate))
            {
                if (jsonFormatter.ReadObject(file) is List<InvoiceForPayment> newInvoiceJ)
                {
                    foreach (InvoiceForPayment inv in newInvoiceJ)
                    {
                        WriteLine(inv);
                    }
                }
            }
        }

        private void PartOfTheFields(SerializationInfo info)
        {
            oneDayPenaltyForLatePayment = info.GetDouble("oneDayPenaltyForLatePayment");
            paymentPerDay = info.GetDouble("paymentPerDay");
            _amountOfDays = info.GetInt32("AmountOfDays");
            _numberOfDayOfPaymentDelay = info.GetInt32("NumberOfDayOfPaymentDelay");
        }

        private void AllTheFields(SerializationInfo info)
        {
            PartOfTheFields(info);
            amountToBePaidWithoutPenalty = info.GetDouble("amountToBePaidWithoutPenalty");
            penalty = info.GetDouble("penalty");
            totalAmountPayable = info.GetDouble("totalAmountPayalbe");
        }

        private void PartOfTheFields1(SerializationInfo info)
        {
            info.AddValue("oneDayPenaltyForLatePayment", oneDayPenaltyForLatePayment);
            info.AddValue("paymentPerDay", paymentPerDay);
            info.AddValue("AmountOfDays", _amountOfDays);
            info.AddValue("NumberOfDayOfPaymentDelay", _numberOfDayOfPaymentDelay);
        }
        private void AllTheFields1(SerializationInfo info)
        {
            PartOfTheFields1(info);
            info.AddValue("amountToBePaidWithoutPenalty", amountToBePaidWithoutPenalty);
            info.AddValue("penalty", penalty);
            info.AddValue("totalAmountPayalbe", totalAmountPayable);
        }

        private InvoiceForPayment(SerializationInfo info, StreamingContext context)
        {
            if (!IsFlag)
            {
                PartOfTheFields(info);
            }
            else
            {
                AllTheFields(info);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (!IsFlag)
            {
                PartOfTheFields1(info);
            }
            else
            {
                AllTheFields1(info);
            }
        }
    }
}
