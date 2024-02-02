
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

    public int GetRowNr()
    {
        return RowNr;
    }

    public int GetSeatNr()
    {
        return SeatNr;
    }

    public bool IsPremiumTicket()
    {
        return IsPremium;
    }

    public decimal GetPricePerSeat()
    {
        return Screening.getPricePerSeat() ;
    }

    public MovieScreening GetMovieScreening()
     {
        return Screening;
    }

    public override string ToString()
    {
        return base.ToString()!;
    }

}
