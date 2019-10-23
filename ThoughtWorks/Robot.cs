namespace ThoughtWorks
{
    public class Robot
    {
        private readonly Position _initialPosition;
        private readonly Room _room;

        private readonly int UnitMove = 1;

        public Robot(Position initialPosition, Room room)
        {
            _initialPosition = initialPosition;
            _room = room;
        }

        public Position GetFinalPosition(Instruction[] instructions)
        {
            var currentPosition = _initialPosition;

            foreach (var instruction in instructions)
            {
                currentPosition = ExecuteInstruction(instruction, currentPosition);
            }

            return currentPosition;
        }

        private Position ExecuteInstruction(Instruction instruction, Position currentPosition)
        {
            return instruction switch
            {
                Instruction.L => ExecuteLeft(currentPosition),
                Instruction.R => ExecuteRight(currentPosition),
                Instruction.M => ExecuteMove(currentPosition)
            };
        }

        private Position ExecuteMove(Position currentPosition)
        {
            var newMove = 0;

            switch (currentPosition.Direction)
            {

                case Direction.N:
                    newMove = currentPosition.Y + UnitMove;

                    return new Position()
                    {
                        Direction = Direction.N,
                        X = currentPosition.X,
                        Y = newMove >= _room.Height ? _room.Height - 1 : newMove
                    };
                case Direction.S:
                    newMove = currentPosition.Y - UnitMove;

                    return new Position()
                    {
                        Direction = Direction.N,
                        X = currentPosition.X,
                        Y = newMove <= 0 ? 0 : newMove
                    };
                case Direction.E:
                    newMove = currentPosition.X + UnitMove;

                    return new Position()
                    {
                        Direction = Direction.N,
                        X = newMove >= _room.Width ? _room.Width - 1 : newMove,
                        Y = currentPosition.Y
                    };
                case Direction.W:
                    newMove = currentPosition.X - UnitMove;

                    return new Position()
                    {
                        Direction = Direction.N,
                        X = newMove <= 0 ? 0 : newMove,
                        Y = currentPosition.Y
                    };
                default:
                    return currentPosition;
            };
        }

        private Position ExecuteLeft(Position currentPosition)
        {
            return currentPosition.Direction switch
            {

                Direction.N => new Position()
                {
                    Direction = Direction.W,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.W => new Position()
                {
                    Direction = Direction.S,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.S => new Position()
                {
                    Direction = Direction.E,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.E => new Position()
                {
                    Direction = Direction.N,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
            };
        }

        private Position ExecuteRight(Position currentPosition)
        {
            return currentPosition.Direction switch
            {

                Direction.N => new Position()
                {
                    Direction = Direction.E,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.E => new Position()
                {
                    Direction = Direction.S,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.S => new Position()
                {
                    Direction = Direction.W,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
                Direction.W => new Position()
                {
                    Direction = Direction.N,
                    X = currentPosition.X,
                    Y = currentPosition.Y
                },
            };
        }
    }
}
