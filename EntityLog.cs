using System;
using System.Collections.Generic;

namespace Simulation.Entities
{
    public partial class Entity
    {
        private readonly List<int[]> coordLog = new();

        public List<int[]> GetLogCoords()
        {
            return coordLog;
        }

        public int[] GetLogCoord(int index)
        {
            int[][] listArr = coordLog.ToArray();
            int[] coord = new int[2];
            coord[0] = listArr[index][0];
            coord[1] = listArr[index][1];
            return coord;
        }

        public void SetLogCoord(int[] record)
        {
            Console.WriteLine(record[0] + " " + record[1]);
            coordLog.Add(record);
        }
    }
}