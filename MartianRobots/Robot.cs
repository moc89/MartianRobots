
using MartianRobots;

public class Robot : IRobot
{
    private int x;
    private int y;
    private string orientation;
    private readonly int[] grid;
    private readonly List<(int, int, string)> lostRobots;
    private static bool isGridValid { get; set; }

    public Robot(int x, int y, string orientation, int[] grid)
    {
        this.x = x;
        this.y = y;
        this.orientation = orientation;
        this.grid = grid;
        this.lostRobots = new List<(int, int, string)>();
    }

    private static readonly Dictionary<string, string> LeftTurns = new Dictionary<string, string>
    {
        {"N", "W"},
        {"W", "S"},
        {"S", "E"},
        {"E", "N"}
    };

    private static readonly Dictionary<string, string> RightTurns = new Dictionary<string, string>
    {
        {"N", "E"},
        {"E", "S"},
        {"S", "W"},
        {"W", "N"}
    };

    private static readonly Dictionary<string, (int, int)> Moves = new Dictionary<string, (int, int)>
    {
        {"N", (0, 1)},
        {"E", (1, 0)},
        {"S", (0, -1)},
        {"W", (-1, 0)}
    };

    public (int x, int y, string orientation, bool isRobotLost) Execute(string instructions)
    {
        if (instructions.Length > 100)
        {
            Console.WriteLine("instructions length cannot be bigger than 100 character.");

            return (x, y, orientation, false);
        }

        bool isRobotLost = false;
        if (ValidationHelper.ValidateGridCoordinate(this.grid))
        {
            foreach (var instruction in instructions)
            {
                if (instruction == 'L')
                {
                    TurnLeft();
                }
                else if (instruction == 'R')
                {
                    TurnRight();
                }
                else if (instruction == 'F')
                {
                    isRobotLost = MoveForward();
                }
                else 
                {
                    Console.WriteLine("Invalid instruction.");
                }
                if (isRobotLost)
                {
                    break;
                }
            };
        }
        else Console.WriteLine("Grid is not valid");


        return (x, y, orientation, isRobotLost);
    }

    public bool MoveForward()
    {
        bool isRobotLost = false;
        var (dx, dy) = Moves[orientation];
        var newX = x + dx;
        var newY = y + dy;
        if (0 <= newX && newX <= grid[0] && 0 <= newY && newY <= grid[1])
        {
            x = newX;
            y = newY;
        }
        else
        {
            isRobotLost = true;

            var lostRobot = (x, y, orientation);
            if (!lostRobots.Contains(lostRobot))
            {
                lostRobots.Add(lostRobot);
                Console.WriteLine($"{x} {y} {orientation} LOST");
            }
        }

        return isRobotLost;
    }

    public void TurnLeft()
    {
        orientation = LeftTurns[orientation];
    }

    public void TurnRight()
    {
        orientation = RightTurns[orientation];
    }
}