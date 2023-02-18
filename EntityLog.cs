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
            coordLog.Add(record);
            if(coordLog.ToArray().Length >= 5)
            {
                coordLog.RemoveAt(0); //remove oldest position
            }
        }
    }
}