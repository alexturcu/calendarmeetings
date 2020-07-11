using System;
using System.Collections.Generic;

namespace calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedule = ("9:00", "20:00");
            var booked = new List<(string Start, string End)> {
                            ("9:00", "10:30"), ("12:00", "13:00"), ("16:00", "18:00")
                        };
            var schedule2 = ("10:00", "18:30");
            var booked2 = new List<(string Start, string End)> {
                            ("10:00", "11:30"), ("12:30", "14:30"), ("14:30", "15:00"), ("16:00", "17:00")
                        };

            var calendars = new List<Calendar>
            {
                new Calendar(schedule, booked),
                new Calendar(schedule2, booked2)
            };

            Console.WriteLine("Available");
            PrintAvailabilities(calendars[0].Availabilities);
            
            Console.WriteLine();
            Console.WriteLine("Available");
            PrintAvailabilities(calendars[1].Availabilities);

            var matches = calendars[0].Availabilities.GetMatches(calendars[1].Availabilities);
            
            Console.WriteLine();
            Console.WriteLine("Match");
            PrintAvailabilities(matches);
            
            var interval = 30;
            var filteredMatches = matches.FilterMatchesByInterval(interval);
            Console.WriteLine();
            Console.WriteLine("Filtered matches");
            PrintAvailabilities(filteredMatches);
        }

        private static void PrintAvailabilities(List<(string Start, string End)> availabilities)
        {
            foreach(var availability in availabilities)
            {
                Console.Write($"['{availability.Item1}', '{availability.Item2}']" + " ");
            }
            Console.WriteLine();
        }
    }
}
