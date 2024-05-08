using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenPass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Длина пароля: ");
            int length = int.Parse(Console.ReadLine());

            string[] sLetter = GenChar(97, 122);
            string[] bLetter = GenChar(65, 90);
            string[] number = GenChar(48, 57);
            string Password = "";

            Random randArray = new Random();
            Random randSymbol = new Random();


            GeneratePassword();

            Console.ReadKey();


            string[] GenChar(int min, int max)
            {
                string[] array = new string[(max - min) + 1];

                int Index = min;

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (Convert.ToChar(Index)).ToString();
                    Index++;
                }

                return array;
            }

            string[] RandomArray(int r, string[] array1, string[] array2, string[] array3)
            {

                switch (r)
                {
                    case 1: return array1;
                    case 2: return array2;
                    case 3: return array3;
                }

                return array1;
            }

            string RandomSymbol()
            {
                string[] setArray = RandomArray(randArray.Next(1, 4), sLetter, bLetter, number);
                return setArray[randSymbol.Next(0, setArray.Length - 1)];
            }

            string GeneratePassword()
            {
                for (int Index = 0; Index < length; Index++)
                {

                    Password += RandomSymbol();
                    if ((Index + 1) % 3 == 0 && (Index + 1) < length) Password += "-";

                }

                Console.WriteLine(Password);
                return Password;
            }
        }
    }
}
