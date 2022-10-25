using System;
using System.Collections.Generic;
using System.Linq;

public class MainClass
{
    public static void Main()
    {
        int endValue = int.Parse( Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int i = 0; i < endValue; i++)
        {
            string str = i.ToString();
            if (str.Contains('0') || str.Contains('1') || str.Contains('4') || str.Contains('5') || str.Contains('6') || str.Contains('8')
             || str.Contains('9'))
                continue;
            else numbers.Add(i);
        }
        foreach (int number in numbers)
            Console.Write(number + " ");
    }
}

