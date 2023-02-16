using System;
using System.IO;
using System.Text;
using Simulation.Entities;

namespace Simulation
{
    public class Program
    {
        readonly static string path = "output/output.txt";
        public static void Main()
        {
            char[,] plane = new char[25,25];
            int lim1 = plane.GetLength(0);
            int lim2 = plane.GetLength(1);
            plane = CreatePlane(plane, lim1, lim2);
            Entity entity = new();
            entity.position = entity.Move();
            plane[entity.position[0],entity.position[1]] = entity.appearance;

            OutputResult(plane, lim1, lim2);
        }  

        public static char[,] CreatePlane(char[,] plane, int lim1, int lim2)
        {
            for(int i=0; i<lim1; i++)
            {
                for(int j=0; j<lim2; j++)
                {
                    plane[i,j] = '+';
                }
            }
            return plane;
        }

        public static void OutputResult(char[,] plane, int lim1, int lim2)
        {
            for(int i=0; i<lim1; i++) //50
            {
                for(int j=0; j<lim2; j++)
                {
                    File.AppendAllText(path, plane[i,j].ToString());
                    File.AppendAllText(path, "  ");
                }
                File.AppendAllText(path, "\n");
            }
        }
    }
}