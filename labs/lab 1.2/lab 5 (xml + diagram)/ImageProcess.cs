
using System;
using ScottPlot;

public static class ImageProcess
{
    public static void CreateImage(string outputFile, Root root)
    {
        var subjects = GetData.GetSubjects(root);
        var plt = new ScottPlot.Plot(600, 400);
        int pointCount = 5;
        double[] xs = DataGen.Consecutive(pointCount);

        double[] ys = new double[5];
        for (int i = 0; i < 5; i++)
        {
            double units = 0;
            for (int j = 0; j < root.courses.Count; j++)
            {
                if (subjects[i] == root.courses[j].subject)
                {
                    units += root.courses[j].units;
                }
            }
            ys[i] = units;
        }
        Random rand = new Random(0);
        double[] yError = DataGen.RandomNormal(rand, pointCount, 3, 2);

        plt.PlotBar(xs, ys, yError, horizontal: true);

        plt.Grid(enableHorizontal: false, lineStyle: LineStyle.Dot);

        string[] labels = { subjects[0], subjects[1], subjects[2], subjects[3], subjects[4] };

        plt.YTicks(xs, labels);
        plt.SaveFig(outputFile);
    }
}
