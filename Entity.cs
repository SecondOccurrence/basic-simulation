using System;

namespace Simulation.Entities
{
    public partial class Entity
    {
        private readonly char appearance = 'O';
        private int[] position = {13,13};

        public int[] Move()
        {
            int[] coord = new int[2];
            coord[0] = DetermineMove(position[0]);
            coord[1] = DetermineMove(position[1]);
            return coord;
        }

        public char GetAppearance()
        {
            return appearance;
        }

        public int[] GetPos()
        {
            return position;
        }

        public void SetPos(int[] newPosition)
        {
            position = newPosition;
        }

        private static int DetermineMove(int coord)
        {
            int num;
            int chance = Chance();
            if(coord <= 0){ num = coord + 1; }
            else if(coord >=25){ num = coord - 1; }
            else
            {
                if(chance == 0){ num = coord + 1; }
                else if(chance == 1){ num = coord - 1; }
                else{ num = coord; }
            }
            return num;
        }

        private static int Chance()
        {
            Random rnd = new();
            int chance = rnd.Next(0,3);
            return chance;
        }
    }
}