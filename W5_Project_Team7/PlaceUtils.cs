using System.Linq;

namespace W5_Project_Team7
{
    class PlaceUtils
    {
        public static bool CheckArea(V2Place helsinkiPlace)
        {
            string[] neighbourhoods = new[]
            {
                "Kluuvi", "Kamppi", "Kruununhaka", "Punavuori", "Ullanlinna", "Kallio", "Vallila", "Eira",
                "Kaivopuisto", "Etu - Töölö", "Sörnäinen"
            };
            return neighbourhoods.Contains(helsinkiPlace.location.address.neighbourhood);
        }
    }
}
