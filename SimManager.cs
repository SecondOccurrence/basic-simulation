using System;
using System.IO;
using System.Text;
using Simulation.Entities;
using Simulation.Plane;

namespace Simulation
{
    public class SimManager
    {
        public static void Main()
        {
            SimPlane plane = new();
            Entity entity = new();

            for(int i=0; i<10; i++)
            {
                HandleEntity(entity, plane);
                File.Delete("output/iteration_" + i + ".txt"); //delete previous file iterations
                OutputResult("output/iteration_" + i + ".txt", plane.GetPlane(), plane.GetLim1(), plane.GetLim2());
                plane.SetPlane(plane.GeneratePlane(plane.GetLim1(), plane.GetLim2()));
            }
            char choice = '0';
            while(choice != 'e')
            {
                Console.WriteLine("Enter an iteration you wish to see or exit by typing 'e': ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if(choice != 'e')
                {
                    DisplayMenu(choice);
                }
            }

        }

        private static void HandleEntity(Entity entity, SimPlane plane)
        {
            entity.SetPos(entity.Move());
            entity.SetLogCoord(entity.GetPos());
            plane.ChangePlaneCoord(entity.GetPos()[0], entity.GetPos()[1], entity.GetAppearance());
        }

        private static void OutputResult(string path, char[,] plane, int lim1, int lim2)
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

        private static void DisplayMenu(char choice)
        {
            char newChoice = '0';
            while(newChoice != 'e')
            {
                Console.WriteLine(@"Enter an option:
                1 - Display Plane
                2 - Get statistics of specific coordinate
                e - Exit");
                newChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch(newChoice)
                {
                    case '1':
                        DisplayPlane(choice);
                        break;
                    case '2':
                        GetCoordStat(choice);
                        break;
                    case 'e':
                    
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        break;
                }
            }

        }

        private static string[] ReadPlane(char iteration)
        {
            string[] lines = File.ReadAllLines("output/iteration_" + iteration + ".txt"); //separated by each line
            return lines;
        }

        private static void DisplayPlane(char iteration)
        {
            string[] lines = ReadPlane(iteration);
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static void GetCoordStat(char iteration)
        {
            char[,] area = ConvertLines(iteration);
            int[] coords = ReadCoords();
            switch(area[coords[0], coords[1]])
            {
                case '+':
                    Console.WriteLine("Type: Ground");
                    break;
                case 'O':
                    Console.WriteLine("Type: Entity");
                    break;
            }
        }

        private static char[,] ConvertLines(char iteration)
        {
            string[] lines = ReadPlane(iteration);

            for(int i=0; i<lines.Length; i++)
            {
                lines[i] = lines[i].Replace("  ", string.Empty);
            }
            int len = lines[0].Length;
            char[,] area = new char[len,len];
            for(int i=0; i<len; i++)
            {
                for(int j=0; j<len; j++)
                {
                    area[i,j] = lines[i][j];
                }
            }
            return area;
        }

        private static int[] ReadCoords()
        {
            int[] coords = new int[2];
            bool valid = false;
            Console.WriteLine("Enter x value: ");
            var input = Console.ReadLine();
            while(valid == false)
            {
                if(Int32.TryParse(input, out int x))
                {
                    coords[0] = x;
                    Console.WriteLine("Enter y value: ");
                    input = Console.ReadLine();
                    if(Int32.TryParse(input, out int y))
                    {
                        coords[1] = y;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number. Try Again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number. Try again.");
                }
            }
            return coords;
        }
    }
}