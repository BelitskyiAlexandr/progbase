using System;
using System.Collections.Generic;
using System.Linq;
using ScottPlot;

class Program
{
    static void Main(string[] args)
    {
        int a =5;
        int b = 3;
        long c = --a/++ b * --a / b;
        Console.WriteLine(c);

        // List<int> nums = new List<int>();
        // nums.Add(1);
        // nums.Add(1);
        // nums.Add(2);
        // nums.Add(3);
        // nums.Add(4);
        // nums.Add(4);
        // nums.Add(4);

        // nums.Add(4);
        // nums.Add(10);
        // nums.Add(10);

        // var temp = nums.ToArray();
        // nums = temp.Distinct().ToList<int>();

        // foreach (var item in nums)
        //     Console.WriteLine(item);

        // double[] countedMarks = new double[13];
        // for (int i = 0; i < countedMarks.Length; i++)
        // {
        //     int counter = 0;
        //     for (int j = 0; j < nums.Count; j++)
        //     {
        //         if (i == nums[j])
        //             counter++;
        //     }
        //     countedMarks[i] = counter;
        // }

        // var plt = new ScottPlot.Plot(600, 400);
        // double[] values = countedMarks;
        // double[] positions = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        // string[] labels = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

        // var bar = plt.AddBar(values, positions);

        // plt.XTicks(positions, labels);

        // plt.SetAxisLimits(yMin: 0);
        // plt.XLabel("Marks");
        // plt.YLabel("Count");

        // plt.SaveFig("plot.png");
        // string s = "ss s s s    a d /  ";
        // s = s.Trim();
        // Console.WriteLine(s + '.');

        // int x = 0;
        // while (true)
        // {
        //     Console.WriteLine('s');
        //     if (x == 0)
        //     {
        //         Console.WriteLine("ddd");
        //         x++;
        //         continue;
        //     Console.WriteLine("ss");
        //     }
        //     else break;

        // }
    }
    // public static int IntReturn()
    // {
        // return 2;
    // }
}

