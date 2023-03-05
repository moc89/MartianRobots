
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

        IRobot robot = new Robot(coordinateX, coordinateY, orientation, grid);
        var result = robot.Execute(instructions);  
        
        Console.WriteLine("Result: " + result.Item1 + " " + result.Item2 + " " + result.Item3 );

    }
}
