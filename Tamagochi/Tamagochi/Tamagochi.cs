using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Tamagochic
{
    //    Разработать приложение "Тамагочи". Жизненный цикл 1-2 минуты.
    //Персонаж случайным  образом выдает просьбы(но подряд одна и 
    //та же просьба не выдается). Просьбы могут быть следующие:
    //Покормить, Погулять, Уложить спать, Полечить, Поиграть.
    //Если просьбы не удовлетворяются трижды, персонаж заболевает
    //и просит его полечить. В случае отказа - умирает. Персонаж 
    //отображается в консольном окне при помощи псевдографики.
    //    Диалог с персонажем осуществляется посредством вызова
    //метода Show() класса MessageBox из пространства имен 
    //System.Windows.Forms. За получением подробной информации
    //по работе с этим методом обратитесь к Вашему преподавателю
    //или MSDN.
    //    Для решения этой задачи Вам понадобится класс Timer
    //из пространства имен System.Timers, событие которго
    //Elapsed, типа делегата ElapsedEventHandler, происходит
    //через определенный интервал времени, который задан 
    //в свойстве Interval. Методы Start() и Stop() запускают
    //и останавливают таймер, соответственно.
    //    Вы также можете захотеть делать паузы в работе приложения,
    //В этом случае можно вызвать метод Sleep() класса Thread из 
    //пространства имен System.Threading, передав в его необходимое
    //кол-во миллисекунд.
    class Tamagochi
    {
        private  System.Timers.Timer timer;

        private delegate void Message();
        private  event Message requestEvent;
        private  event Message answerEvent;

        private static string[] image;

        /// <summary>
        /// random1,randkm2 - для алгоритма, что бы одна и та же просьба не выдавалась
        /// renouncement - для подсчета отказов
        /// </summary>
        private static int random1;
        private static int random2;
        private static int renouncement;

        static DialogResult request;

        static Tamagochi()
        {
            image = new string[15];
            random1 = 1;
            random2 = 1;
            renouncement = 0;
        }
        public static void Images()
        {
            image[0] = " +++++++++";
            image[1] = " + @   @ +";
            image[2] = " +  $$$  +";
            image[3] = " +++++++++";
            image[4] = "     +   ";
            image[5] = " +++++++++\t\t\t\t\tHELLO, I'M TAMAGOCHI";
            image[6] = " +   +   +";
            image[7] = " +   +   +";
            image[8] = "     +    ";
            image[9] = "     +    ";
            image[10] = "   + + + ";
            image[11] = "   +   +  ";
            image[12] = "   +   + ";
            image[13] = "   +   + ";
            image[14] = "   +   + ";
        }

        public static void PrintImages()
        {
            foreach (string s in image)
            {
                WriteLine(s);
            }
        }

        public void RequestEvent()
        {
            requestEvent?.Invoke();
        }

        public void AnswerEvent()
        {
            answerEvent?.Invoke();
        }

        /// <summary>
        /// Метод RequestMessage - определена одна форма сообщения для всех запросов
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="mes2"></param>
        public static void RequestMessage(string mes, string mes2)
        {
            request = MessageBox.Show(
                mes,
                mes2,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        public void Feed()
        {
            RequestMessage("Feed me!", "MESSAGE");
        }

        public void TakeAWalk()
        {
            RequestMessage("Take a walk with me!", "MESSAGE");
        }

        public void Sleep()
        {
            RequestMessage("Put to sleep me!", "MESSAGE");
        }

        public void Heal()
        {
            RequestMessage("Heal me!", "MESSAGE");
        }

        public void Play()
        {
            RequestMessage("Play with me!", "MESSAGE");
        }

        public void Ok()
        {
            MessageBox.Show("Hooray, i'm very glad!");
        }

        public void No()
        {
            MessageBox.Show("What a pity!");
        }

        public int RandomDigitRequest()
        {
            Random random = new Random();

            do
            {
                random1 = random.Next(0, 4);
            } while (random1 == random2);

            random2 = random1;

            return random1;
        }
        public void Requests(Object source, ElapsedEventArgs e)
        {
            var w = RandomDigitRequest();

            switch (w)
            {
                case 0:
                    requestEvent += Feed;
                    RequestEvent();
                    requestEvent -= Feed;
                    break;
                case 1:
                    requestEvent += TakeAWalk;
                    RequestEvent();
                    requestEvent -= TakeAWalk;
                    break;
                case 2:
                    requestEvent += Sleep;
                    RequestEvent();
                    requestEvent -= Sleep;
                    break;
                case 3:
                    requestEvent += Play;
                    RequestEvent();
                    requestEvent -= Play;
                    break;
            }
        }

        public void ThreeTimesDenial(Object source, ElapsedEventArgs e)
        {
            MessageBox.Show("I got sick!!!");
            requestEvent += Heal;
            RequestEvent();
            requestEvent -= Heal;

            if (request == DialogResult.Yes)
            {
                timer.Start();
                renouncement = 0;
            }
            if (request == DialogResult.No)
            {
                MessageBox.Show("Tamagochi died!");
                WriteLine("Press the enter to finish the job!");
            }
        }


        public void Answer(Object source, ElapsedEventArgs e)
        {
            if (request == DialogResult.Yes)
            {
                answerEvent += Ok;
                AnswerEvent();
                answerEvent -= Ok;
            }
            if (request == DialogResult.No)
            {
                answerEvent += No;
                AnswerEvent();
                answerEvent -= No;
                ++renouncement;

                if (renouncement == 3)
                {
                    timer.Stop();
                    ThreeTimesDenial(source, e);
                }
            }
        }
        public void LifeCycle()
        {
            timer = new System.Timers.Timer(8000);
            timer.Elapsed += Requests;
            timer.Elapsed += Answer;
            timer.AutoReset = true;
            timer.Enabled = true;

            ReadLine();
            timer.Stop();
            timer.Dispose();
        }
    }
}
