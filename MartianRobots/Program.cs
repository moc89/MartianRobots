
using MartianRobots;

class Program
{
    public static int GridCoordinateXMax = 50; // can be move to config file.
    public static int GridCoordinateYMax = 50;
    public static int GridCoordinateXMin = 0;
    public static int GridCoordinateYMin = 0;

    static void Main(string[] args)
    {

        bool isGridValid;
        var worldCoordinates = String.Empty;


        var marsGrid = Console.ReadLine();
        var grid = Array.ConvertAll(marsGrid.Split(' '), int.Parse);

        do
        {
            Console.WriteLine("TYPE MARS WORLD COORDINATES. ( Input example: 15 50. The maximum value for coordinates are  (" + GridCoordinateYMax + "," + GridCoordinateYMax + "))");
            worldCoordinates = Console.ReadLine().Trim();
            isGridValid = ValidationHelper.ValidateGridCoordinate(worldCoordinates);
        }
        while (!isGridValid);


        while (true)
        {
            var robotPosition = Console.ReadLine().Split(' ');
            var coordinateX = int.Parse(robotPosition[0]);
            var coordinateY = int.Parse(robotPosition[1]);
            var orientation = robotPosition[2];
            var instructions = Console.ReadLine();

            IRobot robot = new Robot(coordinateX, coordinateY, orientation, grid);
            var result = robot.Execute(instructions);

            Console.WriteLine("Result: " + result.x + " " + result.y + " " + result.orientation);
        }
    }
    
}
