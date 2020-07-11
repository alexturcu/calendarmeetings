using System.Collections.Generic;

namespace calendar
{
    public class Calendar
    {
        public (string Start, string End) Schedule { get; set; }
        public List<(string Start, string End)> Booked { get; set; }
        public List<(string Start, string End)> Availabilities { get; set; }
        
        public Calendar((string Start, string End) schedule, List<(string Start, string End)> booked)
        {
            this.Schedule = schedule;
            this.Booked = booked;
            this.Availabilities = GetAvailabilities().FilterInvalidAvailabilities();
        }

        private List<(string Start, string End)> GetAvailabilities()
        {
            var availabilities = new List<(string Start, string End)>();

            availabilities.Add((this.Schedule.Start, this.Booked[0].Start));

            for(int i = 1; i <= this.Booked.Count - 1; i++)
            {
                availabilities.Add((this.Booked[i - 1].End, this.Booked[i].Start));
            }

            availabilities.Add((this.Booked[this.Booked.Count - 1].End, this.Schedule.End));

            return availabilities;
        }
    }
}