using System.Linq.Expressions;
namespace DateTimeExtensions;

public static class ExtensionMethods
{
    /// <summary>
    /// Syntactic sugar at its finest.
    /// </summary>
    /// <param name="date">The starting <see cref="System.DateTeime">DateTime</see> object. </param>
    /// <param name="numDays">... this should be self-apparent, but this is the number of days you wish to go back in time by.</param>
    /// <returns></returns>
    public static DateTime SubtractDays(this DateTime date, int numDays)
        => date.AddDays(numDays * -1);

    /// <summary>
    /// Getting the given day of the week where <paramref name="date"/> lies in.
    /// </summary>
    /// <param name="date">The DateTime object we started our count from.</param>
    /// <param name="day">The day-of-week that you want to see.</param>
    /// <param name="allowPreviousWeeks">If, for example, you want to find the Tuesday of a given week for a date that's passed, 
    /// do you want to go to the PREVIOUS week (default of false) or roll over to the next Tuesday (if param set to true)?</param>
    /// <returns></returns>
    public static DateTime GetGivenDayOfWeek(this DateTime date, DayOfWeek day, bool allowPreviousWeeks = false)
    {
        var difference = ((int)day - (int)date.DayOfWeek);
        if (!allowPreviousWeeks && difference <= 7)
            difference += 7;

        return date.SubtractDays(difference);
    }
}
