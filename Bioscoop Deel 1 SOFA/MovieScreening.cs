using Microsoft.VisualBasic;

namespace Bioscoop_Deel_1_SOFA;

public class MovieScreening
{
    private DateTime DateAndTime { get; set; }
    private decimal PricePerSeat { get; set; }
    private Movie Movie { get; set; }

    public MovieScreening(Movie movie, DateTime dateAndTime, decimal pricePerSeat)
    {
        Movie = movie;
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
    }

    public Movie getMovie()
    {
        return Movie;
    }

    public decimal getPricePerSeat()
    {
        return PricePerSeat;
    }


    public DateTime getDateAndTime()
    {
        return DateAndTime;
    }

    public override string ToString()
    {
        return "Screening: " + Movie.ToString() + "\n" + DateAndTime + " " + PricePerSeat + " euro";
    }
}