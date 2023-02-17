using System;

namespace Simulation.Entities
{
    public class Entity
    {
        public readonly char appearance = 'O';
        public int[] position = {0,0};

        public int[] Move()
        {
            int[] coord = new int[2];
            coord[0] = DetermineMove(position[0]);
            coord[1] = DetermineMove(position[1]);
            return coord;
        }

        private static int DetermineMove(int coord)
        {
            int num;
            int chance = Chance();
            if(chance < 50)
            {
                num = coord + 1;
            }
            else
            {
                num = coord - 1;
            }
            return num;
        }

        private static int Chance()
        {
            Random rnd = new();
            int chance = rnd.Next(0,100);
            return chance;
        }
    }
}