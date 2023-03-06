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

        public static bool ValidateGridCoordinate(int[] gridCoordinates)
        {
            if (gridCoordinates.Length != 2)
            {
               return false;
            }

            return  gridCoordinates[0] > 0 && gridCoordinates[0] <= 50 &&
            gridCoordinates[1] > 0 && gridCoordinates[1] <= 50;
        }
    }
}
