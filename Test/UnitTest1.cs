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

        [Test]
        public void Test1()
        {
            var instructions = new Instruction[]
            {
                Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.L, Instruction.M, Instruction.M
            };

            var initialPosition = new Position()
            {
                Direction = Direction.N,
                X = 1,
                Y = 2
            };

            var room = new Room()
            {
                Width = 6,
                Height = 6
            };

            var robot = new Robot(initialPosition, room);
            var finalPosition = robot.GetFinalPosition(instructions);
            var expectedPosition = new Position()
            {
                Direction = Direction.N,
                X = 1,
                Y = 3
            };

            Assert.AreEqual(finalPosition.Direction, expectedPosition.Direction);
            Assert.AreEqual(finalPosition.X, expectedPosition.X);
            Assert.AreEqual(finalPosition.Y, expectedPosition.Y);
        }
    }
}