using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models
{
    public class World
    {
        private List<Location> locations = new List<Location>();
        internal void AddLocation(int xCoord, int yCoord, string placeName, string placeDescription, string imgName)
        {
            Location tempLocation = new Location();
            tempLocation.XCoordinate = xCoord;
            tempLocation.YCoordinate = yCoord;
            tempLocation.PlaceName = placeName;
            tempLocation.PlaceDescription = placeDescription;
            tempLocation.ImgName = $"/GameEngine;component/Img/LocationImg/{imgName}";

            locations.Add(tempLocation);
        }
        public Location PlayerAt(int xCoord, int yCoord)
        {
            foreach(Location tempLocation in locations)
            {
                if(tempLocation.XCoordinate == xCoord && tempLocation.YCoordinate == yCoord)
                {
                    return tempLocation;
                }
            }
            return null;
        }
    }
}
