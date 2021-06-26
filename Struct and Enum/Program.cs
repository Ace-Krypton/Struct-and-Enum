using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct_and_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            Area a1 = new Area();
            a1.X = 5;
            a1.Y = 10;
            Console.WriteLine(a1.GetNumber());

            Area a2 = a1;
            a2.X = 100;
            a2.Y = 150;

            Console.WriteLine(a1.X);
            Console.WriteLine(a1.Y);

            Console.WriteLine(a2.X);
            Console.WriteLine(a2.Y);

            Area a3;
            a3.X = 5;
            a3.Y = 10;

            //a3.MyProperty = 5; -- They are not working because we did not get an instance from a3 struct. You have to use new keyword in order to use properties and methods
            //Console.WriteLine(a3.GetNumber()); -- They are not working because we did not get an instance from a3 struct. You have to use new keyword in order to use properties and methods

            int days = 6;

            //Switch case
            switch (days)
            {
                case (int)Weekdays.Saturday:
                    Console.WriteLine("You have 2 days left");
                    break;

                case (int)Weekdays.Sunday:
                    Console.WriteLine("You are on your last day");
                    break;
                default:
                    Console.WriteLine("You have to work");
                    break;
            }
        }
    }

    //Enum
    public enum Weekdays //This is enum. It has some similarities with switch cases.
    {
        Monday = 1, //On default this number is 0. But I declare it as a week days, so I changed it to 1.
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    interface ITestForInterface //Interface
    {
        //Properties. Remember you cannot use fields in you interface.
        string Name { get; set; } //You have to use it without a access modifier
        string Surname { get; set; } //You have to use it without a access modifier
    }

    struct Test
    {
        public int MyProperty { get; set; }
    }

    struct Area : ITestForInterface //Test -- We get an error because, structs cannot get an inheritance from structs or classes. They can only get inheritance from interfaces
    {
        public int X; //Fields
        public int Y; //Fields
        public int MyProperty { get; set; }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } //You have to inplement interface to your struct method
        public string Surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } //You have to inplement interface to your struct method

        static Area() //Static constructor. The only (Empty) constructor that works in struct. Otherwise you have to use constructors with parametres
        {
            Console.WriteLine("This worked");
        }

        public Area(int x, int y, int mypro) //Constructor with parametre
        {
            X = x;
            Y = y;
            MyProperty = mypro;
        }

        public int GetNumber() //Method that returns X + Y
        {
            return X + Y;
        }
    }

}
