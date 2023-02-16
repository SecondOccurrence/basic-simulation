using System;

namespace Simulation.Entities
{
    public class Entity
    {
        public readonly char appearance = 'O';
        public int[] position = {0,0};

        public int[] Move()
        {
            Random rnd = new();
            int[] coord = new int[2];
            coord[0] = rnd.Next(0,25);
            coord[1] = rnd.Next(0,25);
            return coord;
        }
    }
}