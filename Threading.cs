using System;
using System.Threading;

class Program
{
    static int[] numbers = new int[10];
    static int sum = 0;
    static int product = 1;

    static void Main()
    {
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 26);
        }
        Console.WriteLine("Масив чисел:");
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        Thread threadSum = new Thread(CalculateSum);
        Thread threadProduct = new Thread(CalculateProduct);
        threadSum.Start();
        threadProduct.Start();
        threadSum.Join();
        threadProduct.Join();


        Console.WriteLine("Сума елементів масиву: " + sum);
        Console.WriteLine("Добуток елементів масиву: " + product);
    }
    static void CalculateSum()
    {
        foreach (var num in numbers)
        {
            sum += num;
        }
    }

    static void CalculateProduct()
    {
        foreach (var num in numbers)
        {
            product *= num;
        }
    }
}
