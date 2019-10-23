using System.Collections.Generic;

namespace ThoughtWorks
{
    public class Robot
    {
        private readonly Position _position;


        public Robot(Position position)
        {
            _position = position;
        }

        public Position GetFinalPosition(IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                _position.ExecuteInstruction(instruction);
            }

            return _position;
        }
    }
}
