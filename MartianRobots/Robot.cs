
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

    public void Execute(string instructions)
    {
        throw new NotImplementedException();
    }

    public void MoveForward()
    {
        throw new NotImplementedException();
    }

    public void TurnLeft()
    {
        throw new NotImplementedException();
    }

    public void TurnRight()
    {
        throw new NotImplementedException();
    }
}