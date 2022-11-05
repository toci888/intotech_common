using Intotech.Common.Models;

namespace Intotech.Common;

public class CalendarEventIntersections
{
    public virtual Dictionary<int, List<TimeSpan>> GetIntersectionsPerDay(Dictionary<int, List<CalendarEvent>> usersAvailabilityIntervals)
    {
        usersAvailabilityIntervals = Mock(); // todo remove

        // ??
        foreach (KeyValuePair<int, List<CalendarEvent>> item in usersAvailabilityIntervals)
        {
            foreach (CalendarEvent calendarEvent in item.Value)
            {

            }
        }

        return null;
    }

    private Dictionary<int, List<CalendarEvent>> Mock()
    {


        return new Dictionary<int, List<CalendarEvent>>() // 14 - 18
        {
            { 1, new List<CalendarEvent>() { new CalendarEvent() { Id = 1, Begining = new DateTime(2022, 5, 1, 11, 0, 0), Ending = new DateTime(2022, 5, 1, 13, 0, 0) },
                new CalendarEvent() { Id = 1, Begining = new DateTime(2022, 5, 1, 15, 0, 0), Ending = new DateTime(2022, 5, 1, 18, 0, 0) },
                new CalendarEvent() { Id = 1, Begining = new DateTime(2022, 5, 1, 21, 0, 0), Ending = new DateTime(2022, 5, 1, 23, 0, 0) }
            } },
            { 2, new List<CalendarEvent>() { new CalendarEvent() { Id = 1, Begining = new DateTime(2022, 5, 1, 13, 0, 0), Ending = new DateTime(2022, 5, 1, 18, 0, 0) } } },
            { 3, new List<CalendarEvent>() { new CalendarEvent() { Id = 1, Begining = new DateTime(2022, 5, 1, 14, 0, 0), Ending = new DateTime(2022, 5, 1, 18, 0, 0) } } },
        };
    }
}
