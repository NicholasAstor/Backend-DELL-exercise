public static class DateTimeExtensions
{
    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        return dateTime.HasValue
            ? DateOnly.FromDateTime(dateTime.Value)
            : (DateOnly?)null;
    }

    public static string ToDiaMesAno(this DateOnly? dateOnly)
    {
        return dateOnly.HasValue
            ? dateOnly.Value.ToString("dd-MM-yyyy")
            : string.Empty;
    }
}
