using System.Collections.Generic;
using System.Linq;

namespace calendar
{
    public static class CalendarExtensions
    {
        public static List<(string Start, string End)> FilterInvalidAvailabilities(this List<(string Start, string End)> availabilities)
        {
            return availabilities.Where(a => a.Item1 != a.Item2).ToList();
        }

        public static List<(string Start, string End)> FilterMatchesByInterval(this List<(string Start, string End)> matches, int interval)
        {
            var filteredMatches = new List<(string Start, string End)>();

            foreach(var match in matches)
            {
                var startHours = int.Parse(match.Start.Split(":")[0]);
                var startMinutes = int.Parse(match.Start.Split(":")[1]);

                var endHours = int.Parse(match.End.Split(":")[0]);
                var endMinutes = int.Parse(match.End.Split(":")[1]);

                var minutes = (endHours - startHours) * 60;
                minutes += endMinutes - startMinutes;

                if(minutes >= interval)
                {
                    filteredMatches.Add(match);
                }
            }

            return filteredMatches;
        }

        public static List<(string Start, string End)> GetMatches(this List<(string Start, string End)> availabilities, List<(string Start, string End)> availabilities2)
        {
            var dates = new List<(string Start, string End)>();
            
            for(int i = 0; i < availabilities.Count; i++)
            {
                var start = availabilities[i].Item1.GetGreater(availabilities2[i].Item1);
                var end = availabilities[i].Item2.GetLesser(availabilities2[i].Item2);

                dates.Add((start, end));
            }

            return dates;
        }
    }
}