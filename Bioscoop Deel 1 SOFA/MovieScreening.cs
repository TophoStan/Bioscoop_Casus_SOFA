namespace Bioscoop_Deel_1_SOFA;

public class MovieScreening
{
    private DateTime DateAndTime { get; set; }
    private double PricePerSeat { get; set; }
    private Movie Movie { get; set; }

    public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        Movie = movie;
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
    }

    public Movie getMovie()
    {
        return Movie;
    }

    public double getPricePerSeat()
    {
        return PricePerSeat;
    }

    public DateTime getDateAndTime()
    {
        return DateAndTime;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}