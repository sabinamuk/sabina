/******************************************************************************
Лаб 8 -задача 1 - 28.03.25 - Дан класс точка, который включает две переменные x,y
*******************************************************************************/
using System;
namespace Program
{
    class Dot
    {
        public int x;
        public int y;

        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Move()
        {
            Random rnd = new Random();
            x += rnd.Next(-2, 2);
            y += rnd.Next(-2, 2);
        }
    }
    class Event
    {
        public event EventHandler SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        }
    }
    class Program
    {
        static void Handler(object source, EventArgs arg)
        {
            Console.WriteLine("Точка вышла за пределы области");
        }
        static void Main(string[] args)
        {
            Event evt = new Event();

            Dot a = new Dot(0, 0);
            Dot b = new Dot(6, 6);

            Dot dot = new Dot(3, 3);
            while (true)
            {
                dot.Move();
                Console.WriteLine(dot.x + " " + dot.y);
                if (dot.x < a.x || dot.x > b.x || dot.y < a.y || dot.y > b.y)
                {
                    evt.SomeEvent += Handler;
                    evt.OnSomeEvent();
                    break;
                }
            }
        }
    }
}