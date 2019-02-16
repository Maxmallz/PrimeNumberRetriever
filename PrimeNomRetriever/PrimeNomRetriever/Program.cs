using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNomRetriever
{
    class Program
    {

        //user enters total prime numbers needed
        //system displays a list of all prime numbers

        private static int count;
        private static int  FITST_PRIME_NUMBER = 2;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("enter desired number of prime numbers needed greater than 1");
            }
            while ((count = int.Parse(Console.ReadLine())) < 1);

            List<double> primeNos = new List<double>(count);            //create list

            primeNos.Add(FITST_PRIME_NUMBER); //two is a prime number by definition

            int j = FITST_PRIME_NUMBER + 1; //

            while ((primeNos.Count) < primeNos.Capacity)
                {

                int primeToTest = j;

                int[] divisors = getTempFactors(primeToTest);

                    foreach (int item in divisors)
                    {
                    if (primeToTest % item == 0) { break; }
                    if (item + 1 == primeToTest && primeToTest % item != 0) { primeNos.Add(primeToTest); break; }
                    if (primeToTest % item != 0) { continue; }
                    }
                j++;
                }

            Console.WriteLine("The first {0} prime number(s) :", count);
            foreach(int primeNo in primeNos)
            {
                Console.WriteLine(primeNo);
            }

            Console.Read();
        }

        private static int[] getTempFactors(int num)
        {
            if(num < 3) { throw new ArgumentOutOfRangeException(); }
            int[] arr = new int[num - 2];

            for(int i = arr.Length; i >= 1; i--)
            {
                arr[i - 1] = i + 1;
            }

            Array.Sort(arr);
            return arr;
        }
    }
}
