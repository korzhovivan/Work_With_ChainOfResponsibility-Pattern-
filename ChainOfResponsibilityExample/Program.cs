using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckCoin checkerCoin = new CheckCoin(5,0.4);

            Coin coin_5 = new Coin_5();
            Coin coin_25 = new Coin_50();
            Coin coin_50 = new Coin_25();
            
            coin_5.Successor = coin_50;
            coin_50.Successor = coin_25;
            coin_25.Successor = coin_5;

            coin_5.Handle(checkerCoin);

            Console.Read();

        }
    }
    class Terminal
    {
        public Terminal()
        {

        }
    }

    class CheckCoin
    {
        public bool Coin5 { get; set; } = false;
        public bool Coin25 { get; set; } = false;
        public bool Coin50 { get; set; } = false;
        public CheckCoin(int mass,double weight)
        {
            if (mass == 5 && weight == 0.4)
            {
                Coin5 = true;
            }
            else if (mass == 7 && weight == 0.7)
            {
                Coin5 = true;
            }
            else if (mass == 12 && weight == 0.7)
            {
                Coin5 = true;
            }
            else
            {
                throw new Exception("Не принял");
            }
        }
    }

    abstract class Coin
    {
        public int Weight { get; set; }
        public double Width { get; set; }
        public Coin Successor { get; set; }
        public abstract void Handle(CheckCoin receiver);
    }

    class Coin_5 : Coin     // 5 gramm 0.4 mm radius
    {
        public override void Handle(CheckCoin receiver)
        {
            if (receiver.Coin5 == true)
                Console.WriteLine("This is 5 coin");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }

    class Coin_25 : Coin    // 7 gramm 0.7 mm radius
    {
        public override void Handle(CheckCoin receiver)
        {
            if (receiver.Coin50 == true)
                Console.WriteLine("This is 25 coin");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }

    class Coin_50 : Coin    // 12 gramm 0.7 mm radius
    {
        public override void Handle(CheckCoin receiver)
        {
            if (receiver.Coin25 == true)
                Console.WriteLine("This is 50 coin");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
}
