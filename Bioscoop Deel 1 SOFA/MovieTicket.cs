
namespace Bioscoop_Deel_1_SOFA;

public class MovieTicket
{
    
    private int RowNr { get; set; }
    private int SeatNr { get; set; }
    private bool IsPremium { get; set; }
    private MovieScreening Screening { get; set; }

    public MovieTicket(MovieScreening screening, int rowNr, int seatNr, bool isPremium)
    {
        this.Screening = screening;
        this.RowNr = rowNr;
        this.SeatNr = seatNr;
        this.IsPremium = isPremium;
    }

    public int getRowNr()
    {
        return RowNr;
    }

    public int getSeatNr()
    {
        return SeatNr;
    }

    public bool isPremiumTicket()
    {
        return IsPremium;
    }

    public double getPricePerSeat()
    {
        if (isPremiumTicket())
        {
            return Screening.getPricePerSeat() + 2;
        }
        return Screening.getPricePerSeat() ;
    }

    public MovieScreening getMovieScreening()
     {
        return Screening;
    }

    public override string ToString()
    {
        return base.ToString();
    }

}
