/************************************************************
Лаб 8- задача 2 - 28.03.25 - Гонка - выдать, кто победил.
*************************************************************/
using System;
namespace Race
{
    class Participant
    {
        public string name;
        public int speed { get; set; }
        public Participant(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }
    }
    class Event
    {
        public event EventHandler SomeEvent;

        public void OnSomeEvent(Participant winner)
        {
            SomeEvent?.Invoke(winner, EventArgs.Empty);
        }
    }
    class Program
    {
        static void Handler(object source, EventArgs arg)
        {
            Participant winner = (Participant)source;
            Console.WriteLine(winner.name + " победил!");
        }
        static void Main(string[] args)
        {
            Event evt = new Event();
            evt.SomeEvent += Handler;

            Participant p1 = new Participant("Иванов", 10);
            Participant p2 = new Participant("Петров", 5);
            Participant p3 = new Participant("Сидоров", 20);

            int time = 0;
            int start = 0;
            int finish = 100;

            int p1_d = start;
            int p2_d = start;
            int p3_d = start;
            while (true)
            {
                time += 1;

                p1_d += p1.speed;
                p2_d += p2.speed;
                p3_d += p3.speed;
                if (p1_d >= finish)
                {
                    evt.OnSomeEvent(p1);
                    break;
                }
                if (p2_d >= finish)
                {
                    evt.OnSomeEvent(p2);
                    break;
                }
                if (p3_d >= finish)
                {
                    evt.OnSomeEvent(p3);
                    break;
                }
            }
        }
    }
}
