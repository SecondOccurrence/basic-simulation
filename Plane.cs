using System;
using System.IO;
using System.Text;

namespace Simulation.Plane
{
    public class SimPlane
    {
        private static char[,] area = new char[0,0];
        private readonly static int lim1 = 25;
        private readonly static int lim2 = 25;

        public SimPlane()
        {
            area = GeneratePlane(lim1, lim2);
        }

        public int GetLim1()
        {
            return lim1;
        }

        public int GetLim2()
        {
            return lim2;
        }

        public char[,] GetPlane()
        {
            return area;
        }

        public void SetPlane(char[,] newArea)
        {
            area = newArea;
        }

        public void ChangePlaneCoord(int coord1, int coord2, char appearance)
        {
            area[coord1,coord2] = appearance;
        }

        public char[,] GeneratePlane(int lim1, int lim2)
        {
            char[,] plane = new char[lim1,lim2];
            for(int i=0; i<lim1; i++)
            {
                for(int j=0; j<lim2; j++)
                {
                    plane[i,j] = '+';
                }
            }
            return plane;
        }
    }
}