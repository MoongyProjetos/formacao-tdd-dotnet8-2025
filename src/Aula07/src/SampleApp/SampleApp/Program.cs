using System;

namespace SampleApp
{
    private sealed class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"2 + 3 = {Calculator.Add(2, 3)}");



            for (int i; i < 100; i++)
            {
                for (int j; j < 100; j++)
                {
                    for (int k; k < 100; k++)
                    {
                        System.Console.WriteLine("Oi mundo");
                    }
                }
            }



            // for (int i; i < 100; i++)
            // {
            //     for (int j; j < 100; j++)
            //     {
            //         for (int k; k < 100; k++)
            //         {
            //             System.Console.WriteLine("Oi mundo");
            //         }
            //     }
            // }



            return;


            var x = 1;

            ///var y = 1;
        }


        private void Sample()
        {
            for (int i; i < 100; i++)
            {
                for (int j; j < 100; j++)
                {
                    for (int k; k < 100; k++)
                    {
                        System.Console.WriteLine("Oi mundo");
                    }
                }
            }
        }



        private void Sample2()
        {
            for (int i; i < 100; i++)
            {
                for (int j; j < 100; j++)
                {
                    for (int k; k < 100; k++)
                    {
                        System.Console.WriteLine("Oi mundo");
                    }
                }
            }
        }
    }
}


