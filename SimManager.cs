using System;
using System.IO;
using System.Text;

namespace Simulation
{
    public class Program
    {
        readonly static string path = "output/output.txt";
        public static void Main()
        {
            string[,] plane = new string[25,25];
            int lim1 = plane.GetLength(0);
            int lim2 = plane.GetLength(1);
            plane = CreatePlane(plane, lim1, lim2);
            for(int i=0; i<lim1; i++) //50
            {
                for(int j=0; j<lim2; j++)
                {
                    File.AppendAllText(path, plane[i,j]);
                    File.AppendAllText(path, "  ");
                }
                File.AppendAllText(path, "\n");
            }
        }  

        public static string[,] CreatePlane(string[,] plane, int lim1, int lim2)
        {
            for(int i=0; i<lim1; i++)
            {
                for(int j=0; j<lim2; j++)
                {
                    plane[i,j] = "0";
                }
            }
            return plane;
        }
    }
}