using System.Collections.Generic;

namespace ThoughtWorks
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; } = Direction.N;

        private const int UnitMove = 1;
        private readonly Room _referenceRoom;
        private static readonly LinkedList<Direction> LinkedDirections =
            new LinkedList<Direction>(new[] { Direction.N, Direction.E, Direction.S, Direction.W });


        public Position(Room referenceRoom)
        {
            _referenceRoom = referenceRoom;
        }

        public void ExecuteInstruction(Instruction instruction)
        {
            if (instruction == Instruction.M)
                ExecuteMove();
            else
                ExecuteDirection(instruction);
        }

        private void ExecuteDirection(Instruction instruction)
        {
            var currentNode = LinkedDirections.Find(Direction);

            Direction = instruction == Instruction.L
                ? currentNode?.Previous?.Value ?? LinkedDirections.Last.Value // LinkedList is not Doubly Circular Linked List 
                : currentNode?.Next?.Value ?? LinkedDirections.First.Value; // So, We have to traverse manually
        }

        private void ExecuteMove()
        {
            int newMove;

            switch (Direction)
            {

                case Direction.N:
                    newMove = Y + UnitMove;

                    Y = newMove >= _referenceRoom.Height ? _referenceRoom.Height - 1 : newMove;
                    break;
                case Direction.S:
                    newMove = Y - UnitMove;

                    Y = newMove <= 0 ? 0 : newMove;
                    break;
                case Direction.E:
                    newMove = X + UnitMove;

                    X = newMove >= _referenceRoom.Width ? _referenceRoom.Width - 1 : newMove;
                    break;
                case Direction.W:
                    newMove = X - UnitMove;

                    X = newMove <= 0 ? 0 : newMove;
                    break;
            }
        }
    }
}
