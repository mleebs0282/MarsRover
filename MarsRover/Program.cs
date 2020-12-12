using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var gridBounds = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var startingCoordinates = Console.ReadLine().Trim().Split(' ');
            Coordinates coordinates = new Coordinates();

            if (startingCoordinates.Count() == 3)
            {
                coordinates.CoordinateX = Convert.ToInt32(startingCoordinates[0]);
                coordinates.CoordinateY = Convert.ToInt32(startingCoordinates[1]);
                coordinates.Direction = (Directions)Enum.Parse(typeof(Directions), startingCoordinates[2]);
            }

            var moves = Console.ReadLine().ToUpper();

            try
            {
                Instructions instructions = new Instructions(coordinates);
                instructions.Move(gridBounds, moves);
                Console.WriteLine($"{coordinates.CoordinateX} {coordinates.CoordinateY} {coordinates.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
