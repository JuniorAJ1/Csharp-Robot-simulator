using Xunit;
using RobotWars;

namespace RobotWars.Tests
{
    public class RobotTests
    {
        [Fact]
        public void RobotMovement_WhenMoveCommandIsIssued()
        {
            // Arrange
            var robot = new Robot(2, 2, 'N');
            
            // Act
            robot.MoveTo(robot.X, robot.Y + 1); // Move North

            // Assert
            Assert.Equal(2, robot.X);  // X remains the same
            Assert.Equal(3, robot.Y);  // Y increases by 1
            Assert.Equal('N', robot.Direction);  

            robot.MoveTo(robot.X, robot.Y - 1); // Move South

            Assert.Equal(2, robot.X);  
            Assert.Equal(2, robot.Y); 
            Assert.Equal('N', robot.Direction);

            robot.MoveTo(robot.X + 1, robot.Y); // Move East

            Assert.Equal(3, robot.X);  
            Assert.Equal(2, robot.Y); 
            Assert.Equal('N', robot.Direction);

            robot.MoveTo(robot.X - 1, robot.Y); // Move West

            Assert.Equal(2, robot.X);  
            Assert.Equal(2, robot.Y); 
            Assert.Equal('N', robot.Direction);


        }

        [Fact]
        public void RobotRotates_WhenRotateLeftCommandIsIssued()
        {
            var robot = new Robot(0, 0, 'N');
            robot.RotateLeft(); // Rotate left

            Assert.Equal('W', robot.Direction);  // Direction should now be West

            robot.RotateRight(); // Rotate Right
            robot.RotateRight();
            Assert.Equal('E', robot.Direction);

        }

        [Fact]
        public void PenaltyCountIncreases_WhenRobotMovesOutOfBounds()
        {
            var arena = new Arena(5, 5);
            var robot = new Robot(0, 0, 'N');
            var controller = new BattleController(arena, robot);

            controller.ExecuteInstructions("MMMMM");

            Assert.Equal(1, controller.PenaltyCount);  // Penalty count should increase
        }

        [Fact]
        public void IsWithinBounds_ReturnsFalse_WhenPositionIsOutsideArena()
        {
            // Arrange
            var arena = new Arena(5, 5); // Arena size 5x5

            // Act
            var result = arena.IsWithinBounds(5, 5); // Outside the bounds

            // Assert
            Assert.False(result);  // Should return false
        }

        [Fact]
        public void IsWithinBounds_ReturnsTrue_WhenPositionIsInsideArena()
        {
            // Arrange
            var arena = new Arena(5, 5); // Arena size 5x5

            // Act
            var result = arena.IsWithinBounds(2, 2); // Inside the bounds

            // Assert
            Assert.True(result);  // Should return true
        }

        [Fact]
        public void RobotIgnoresInvalidCommands()
        {
            // Arrange
            var robot = new Robot(3, 1, 'N');
            var arena = new Arena(5, 5);
            var controller = new BattleController(arena, robot);
            
            // Act
            controller.ExecuteInstructions("MMLXMR");  // 'X' is an invalid command

            // Assert
            Assert.Equal(2, robot.X);  
            Assert.Equal(3, robot.Y); 
        }
    }
}
