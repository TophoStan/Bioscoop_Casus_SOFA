namespace Bioscoop_Deel_1_SOFA.CalculationBehavior;

public class NotStudentWeekendCalculation : ICalculationBehavior
{
    public decimal CalculatePrice(List<MovieTicket> Tickets)
    {
        decimal totalPrice = 0;
        for (int i = 0; i < Tickets.Count; i++)
        {
            MovieTicket ticket = Tickets[i];
            if (ticket.IsPremiumTicket()) totalPrice += 3;
            totalPrice += ticket.GetPricePerSeat();
        }

        if (Tickets.Count >= 6) totalPrice *= 0.9m;

        return totalPrice;
    }
}