namespace Bioscoop_Deel_1_SOFA.CalculationBehavior;

public class NotStudentWeekdayCalculation : ICalculationBehavior
{
    public decimal CalculatePrice(List<MovieTicket> Tickets)
    {
        decimal totalPrice = 0;
        for (int i = 0; i < Tickets.Count; i++)
        {
            MovieTicket ticket = Tickets[i];
            if (!((i + 1) % 2 == 0))
            {
                if (ticket.IsPremiumTicket()) totalPrice += 3;
                totalPrice += ticket.GetPricePerSeat();
            }
        }
        return totalPrice;
    }
}
