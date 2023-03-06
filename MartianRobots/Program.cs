
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

        do
        {
            Console.WriteLine("TYPE MARS WORLD COORDINATES. ( Input example: 15 50. The maximum value for coordinates are  (" + GridCoordinateYMax + "," + GridCoordinateYMax + "))");

            // Validate grid coordinates.
            worldCoordinates = Console.ReadLine().Trim();
            isGridValid = ValidationHelper.ValidateGridCoordinate(worldCoordinates);
        }
        while (!isGridValid);

        var grid = Array.ConvertAll(worldCoordinates.Split(' '), int.Parse);

        while (true)
        {
            try
            {
                // Get robotPosition and orientation.
                Console.WriteLine("--------------------------- ");
                Console.WriteLine("TYPE ROBOT POSITION: ( INPUT EXAMPLE. : 2 3 N )");
                var robotPosition = Console.ReadLine().Split(' ');
                var coordinateX = int.Parse(robotPosition[0]);
                var coordinateY = int.Parse(robotPosition[1]);
                var orientation = robotPosition[2];

                // Initialise grid and robot position.
                IRobot robot = new Robot(coordinateX, coordinateY, orientation, grid);

                // Get instructions.
                Console.WriteLine("TYPE INSTRUCTION: ( INPUT EXAMPLE: RFRFRFLR )");
                var instructions = Console.ReadLine();

                if (instructions.Length > 100)
                {
                    Console.WriteLine("instructions length cannot be bigger than 100 character.");
                    return;
                }

                // Execute robot.
                var result = robot.Execute(instructions);

                var lostMessage = result.isRobotLost ? "LOST" : string.Empty;
                Console.WriteLine("Result: " + result.x + " " + result.y + " " + result.orientation + " " + lostMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result: " + ex.Message);
            }
        }
    }

}
