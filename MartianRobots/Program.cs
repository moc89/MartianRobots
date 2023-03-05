
class Program
{

    static void Main(string[] args)
    {
        var marsGrid = Console.ReadLine();
        var grid = Array.ConvertAll(marsGrid.Split(' '), int.Parse);
        var robotPosition = Console.ReadLine().Split(' ');
        var coordinateX = int.Parse(robotPosition[0]);
        var coordinateY = int.Parse(robotPosition[1]);
        var orientation = robotPosition[2];
        var instructions = Console.ReadLine();

        var robot = new Robot(coordinateX, coordinateY, orientation, grid);
        Console.WriteLine("Result: ");

    }
}

public class Robot
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
}