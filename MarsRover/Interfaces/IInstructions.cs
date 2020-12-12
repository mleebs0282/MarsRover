using MarsRover.Models;
using System.Collections.Generic;

namespace MarsRover.Interfaces
{
    public interface IInstructions
    {
        void Move(List<int> gridBounds, string moves);
    }
}
