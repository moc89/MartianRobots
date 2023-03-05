using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    internal class ValidationHelper
    {
        public static int GridCoordinateXMax = 50;
        public static int GridCoordinateYMax = 50;
        public static int GridCoordinateXMin = 0;
        public static int GridCoordinateYMin = 0;

        public static bool ValidateGridCoordinate(string gridCoordinates)
        {

            if (String.IsNullOrEmpty(gridCoordinates))
            {
                return false;
            }

            var gridCoordinatesTrimmed = gridCoordinates.Trim().Split(" "); 

            if (gridCoordinatesTrimmed.Length == 2)
            {
                bool isXNumber = int.TryParse(gridCoordinatesTrimmed[0], out int coordinateX);
                bool isYNumber = int.TryParse(gridCoordinatesTrimmed[1], out int coordinateY);

                return isXNumber && isYNumber &&
                       coordinateY > GridCoordinateYMin && coordinateY <= GridCoordinateYMax &&
                       coordinateX > GridCoordinateXMin && coordinateX <= GridCoordinateXMax;
            }

            return false;
        }
    }
}
