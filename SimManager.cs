using System;
using System.IO;
using System.Text;
using Simulation.Entities;
using Simulation.Plane;

namespace Simulation
{
    public class SimManager
    {
        readonly static string path = "output/fd.txt";
        public static void Main()
        {
            SimPlane plane = new();
            Entity entity = new();
            entity.SetPos(entity.Move());
            plane.ChangePlaneCoord(entity.GetPos()[0], entity.GetPos()[1], entity.GetAppearance());

            OutputResult(plane.GetPlane(), plane.GetLim1(), plane.GetLim2());
        } 

        public static void OutputResult(char[,] plane, int lim1, int lim2)
        {
            for(int i=0; i<lim1; i++)
            {
                for(int j=0; j<lim2; j++)
                {
                    try
                    {
                        File.AppendAllText(path, plane[i,j].ToString());
                        File.AppendAllText(path, "  ");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                File.AppendAllText(path, "\n");
            }
        }
    }
}