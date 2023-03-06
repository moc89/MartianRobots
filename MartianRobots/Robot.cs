
public class Robot : IRobot
{
    private int x;
    private int y;
    private string orientation;
    private readonly int[] grid;
    private readonly List<(int, int, string)> lostRobots;

    public Robot(int x, int y, string orientation, int[] grid)
    {
        this.x = x;
        this.y = y;
        this.orientation = orientation;
        this.grid = grid;
        this.lostRobots = new List<(int, int, string)>();
    }

    public (int x, int y, string orientation, bool isRobotLost) Execute(string instructions)
    {
        bool isRobotLost = false;
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
            if (isRobotLost)
            {
                break;
            }
        };

        return (x, y, orientation, isRobotLost); 
    }

    public bool MoveForward()
    {
        bool isRobotLost = false;
        var moves = new Dictionary<string, (int, int)>
        {
            {"N", (0, 1)},
            {"E", (1, 0)},
            {"S", (0, -1)},
            {"W", (-1, 0)}
        };
        var (dx, dy) = moves[orientation];
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
        var turns = new Dictionary<string, string>
        {
            {"N", "W"},
            {"W", "S"},
            {"S", "E"},
            {"E", "N"}
        };
        orientation = turns[orientation];
    }

    public void TurnRight()
    {
        var turns = new Dictionary<string, string>
        {
            {"N", "E"},
            {"E", "S"},
            {"S", "W"},
            {"W", "N"}
        };
        orientation = turns[orientation];
    }
}