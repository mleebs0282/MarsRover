using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Instructions : IInstructions
    {
        private Coordinates _coordinates;
        public Instructions(Coordinates coordinates)
        {
            _coordinates = coordinates;
        }

        public void Move(List<int> gridBounds, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        GoForward();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Selection {move}");
                        break;
                }


                if (_coordinates.CoordinateX < 0 ||
                    _coordinates.CoordinateY > gridBounds[0] ||
                    _coordinates.CoordinateY < 0 ||
                    _coordinates.CoordinateY > gridBounds[1])
                {
                    throw new ArgumentOutOfRangeException($"Moves cannot go past the bounderies of the grid from (0, 0) to ({ gridBounds[0] }, { gridBounds[1] })");
                }
            }
        }

        private void GoForward()
        {
            switch (_coordinates.Direction)
            {
                case Directions.N:
                    _coordinates.CoordinateY += 1;
                    break;
                case Directions.S:
                    _coordinates.CoordinateY -= 1;
                    break;
                case Directions.E:
                    _coordinates.CoordinateX += 1;
                    break;
                case Directions.W:
                    _coordinates.CoordinateX -= 1;
                    break;
                default:
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (_coordinates.Direction)
            {
                case Directions.N:
                    _coordinates.Direction = Directions.W;
                    break;
                case Directions.S:
                    _coordinates.Direction = Directions.E;
                    break;
                case Directions.E:
                    _coordinates.Direction = Directions.N;
                    break;
                case Directions.W:
                    _coordinates.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (_coordinates.Direction)
            {
                case Directions.N:
                    _coordinates.Direction = Directions.E;
                    break;
                case Directions.S:
                    _coordinates.Direction = Directions.W;
                    break;
                case Directions.E:
                    _coordinates.Direction = Directions.S;
                    break;
                case Directions.W:
                    _coordinates.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
    }
}
