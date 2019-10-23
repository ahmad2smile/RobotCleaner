using NUnit.Framework;
using ThoughtWorks;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Robot follows all the instructions correctly and get to final positions")]
        public void CorrectFinalPosition()
        {
            var instructions = new[]
            {
                Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.M
            };

            var room = new Room()
            {
                Width = 6,
                Height = 6
            };

            var initialPosition = new Position(room)
            {
                Direction = Direction.N,
                X = 1,
                Y = 2
            };



            var robot = new Robot(initialPosition);
            var finalPosition = robot.GetFinalPosition(instructions);

            var expectedPosition = new Position(room)
            {
                Direction = Direction.N,
                X = 1,
                Y = 3
            };

            Assert.AreEqual(expectedPosition.Direction, finalPosition.Direction);
            Assert.AreEqual(expectedPosition.X, finalPosition.X);
            Assert.AreEqual(expectedPosition.Y, finalPosition.Y);
        }

        [Test(Description = "Robot does not move when it hits the wall and ignores the instruction")]
        public void IgnoresInvalidMove()
        {
            var instructions = new[]
            {
                Instruction.M, Instruction.L, Instruction.M
            };

            var room = new Room()
            {
                Width = 6,
                Height = 6
            };

            var initialPosition = new Position(room)
            {
                Direction = Direction.N,
                X = 3,
                Y = 5
            };



            var robot = new Robot(initialPosition);
            var finalPosition = robot.GetFinalPosition(instructions);

            var expectedPosition = new Position(room)
            {
                Direction = Direction.W,
                X = 2,
                Y = 5
            };

            Assert.AreEqual(expectedPosition.Direction, finalPosition.Direction);
            Assert.AreEqual(expectedPosition.X, finalPosition.X);
            Assert.AreEqual(expectedPosition.Y, finalPosition.Y);
        }
    }
}