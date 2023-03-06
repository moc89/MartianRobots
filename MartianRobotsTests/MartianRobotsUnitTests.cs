using Xunit.Sdk;

namespace MartianRobotsTests
{
    public class MartianRobotsTests
    {


        [Theory]
        [InlineData("5 3", "1 1 E", "RFRFRFRF", "11E")]
        [InlineData("50 50", "1 1 E", "RFRFRFRF", "11E")]
        [InlineData("10 15", "1 1 E", "RFRFRFRF", "11E")]
        public void InstructionExecutedSuccessfully(string gridInput, string robotInput, string instruction, string expectedOutput)
        {
            // Arrange
            var lostRobots = new List<(int, int, string)>();
            var robotPositions = robotInput.Split(" ");
            var grid = Array.ConvertAll(gridInput.Split(' '), int.Parse);

            IRobot robot = new Robot(int.Parse(robotPositions[0]), int.Parse(robotPositions[1]), robotPositions[2], grid);

            // Act
            var result = robot.Execute(instruction);
            var combinedResult = result.x.ToString() + result.y.ToString() + result.orientation;

            // Assert
            Assert.Equal(expectedOutput, combinedResult);
        }


        [Theory]
        [InlineData("5 3", "3 2 N", "FRRFLLFFRRFLL", "33N LOST")]
        public void RobotHaveBeingLost(string gridInput, string robotInput, string instruction, string expectedOutput)
        {
            // Arrange
            var lostRobots = new List<(int, int, string)>();
            var robotPositions = robotInput.Split(" ");
            var grid = Array.ConvertAll(gridInput.Split(' '), int.Parse);

            IRobot robot = new Robot(int.Parse(robotPositions[0]), int.Parse(robotPositions[1]), robotPositions[2], grid);

            // Act
            var result = robot.Execute(instruction);
            string lostMessage = result.isRobotLost ? "LOST" : string.Empty;
            var combinedResult = result.x.ToString() + result.y.ToString() + result.orientation + " " + lostMessage;

            // Assert
            Assert.Equal(expectedOutput, combinedResult);
        }

    }
}