using System.ComponentModel;

namespace WeatherProcessor.Database.Entities.Enums
{
    /// <summary>
    /// Расширения для Month
    /// </summary>
    public static class Months
    {
        /// <summary>
        /// Получить русское название
        /// </summary>
        /// <param name="month">Конкретный месяц</param>
        /// <exception cref="InvalidEnumArgumentException">Если не реализовано для данного элемента month</exception>
        public static string RussianName(this Month month)
        {
            return month switch
            {
                Month.January => "Январь",
                Month.February => "Февраль",
                Month.March => "Март",
                Month.April => "Апрель",
                Month.May => "Май",
                Month.June => "Июнь",
                Month.July => "Июль",
                Month.August => "Август",
                Month.September => "Сентябрь",
                Month.October => "Октябрь",
                Month.November => "Ноябрь",
                Month.December => "Декабрь",
                _ => throw new InvalidEnumArgumentException(month.ToString()),
            };
        }

        /// <summary>
        /// Enumerator для Month
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Month> GetEnumerator()
        {
            for (var i = 0; i <= 12; i++)
            {
                yield return (Month)i;
            }
        }
    }
}
