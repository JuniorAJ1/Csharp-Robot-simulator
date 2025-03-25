
//Junior Ajala
// Altrata take-home assesment 
namespace RobotWars
{
    class Program
    {
        static void Main(string[] args)
        {
            //scenarios from the document
            Scenario(0, 2, 'E', "MLMRMMMRMMRR"); 
            Scenario(4, 4, 'S', "LMLLMMLMMMRMM"); 
            Scenario(2, 2, 'W', "MLMLMLMRMRMRMRM"); 
            Scenario(1, 3, 'N', "MMLMMLMMMMM"); 
        }

        static void Scenario(int x, int y, char direction, string instructions)
        {
            var arena = new Arena(5, 5);
            var robot = new Robot(x, y, direction);
            var controller = new BattleController(arena, robot);
            
            controller.ExecuteInstructions(instructions);

            Console.WriteLine($"Final Position: {robot.X}, {robot.Y}, {robot.Direction}");
            Console.WriteLine($"Penalties: {controller.PenaltyCount}");
            Console.WriteLine("------------------------");
        }
    }

    public class Arena
    {
        public int Width { get; }
        public int Height { get; }

        public Arena(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsWithinBounds(int x, int y) //checks if robot is withing bounds
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }

    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }

        public Robot(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public void RotateLeft()
        {
            Direction = Direction switch
            {
                'N' => 'W',
                'W' => 'S',
                'S' => 'E',
                'E' => 'N',
                _ => Direction  // default
            };
        }

        public void RotateRight()
        {
            Direction = Direction switch
            {
                'N' => 'E',
                'E' => 'S',
                'S' => 'W',
                'W' => 'N',
                _ => Direction  // default
            };
        }

        public (int, int) GetNextPosition()
        {
            return Direction switch
            {
                'N' => (X, Y + 1),
                'S' => (X, Y - 1),
                'E' => (X + 1, Y),
                'W' => (X - 1, Y),
                _ => (X, Y)    // default
            };
        }

        public void coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class BattleController
    {
        private readonly Arena _arena;
        private readonly Robot _robot;
        public int PenaltyCount { get; private set; }

        public BattleController(Arena arena, Robot robot)
        {
            _arena = arena;
            _robot = robot;
            PenaltyCount = 0;
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        _robot.RotateLeft();
                        break;
                    case 'R':
                        _robot.RotateRight();
                        break;
                    case 'M':
                        MoveRobot();
                        break;
                }
            }
        }

        private void MoveRobot()
        {
            var (nextX, nextY) = _robot.GetNextPosition();

            if (_arena.IsWithinBounds(nextX, nextY))
            {
                _robot.coordinates(nextX, nextY);
            }
            else
            {
                PenaltyCount++;
            }
        }
    }
}

