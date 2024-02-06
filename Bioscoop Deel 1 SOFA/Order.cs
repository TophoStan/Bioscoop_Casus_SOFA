using Bioscoop_Deel_1_SOFA.CalculationBehavior;
using Bioscoop_Deel_1_SOFA.ExportBehavior;

namespace Bioscoop_Deel_1_SOFA;

public class Order
{
    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    private List<MovieTicket> Tickets { get; set; } = new List<MovieTicket>();


    private ICalculationBehavior calculationBehavior;
    private IExportBehavior exportBehavior;

    public Order(int orderNr, bool isStudentOrder)
    {
        OrderNr = orderNr;
        IsStudentOrder = isStudentOrder;

    }

    public int getOrderNr()
    {
        return OrderNr;
    }

    public void addSeatReservation(MovieTicket ticket)
    {
        Tickets.Add(ticket);
    }

    public decimal CalculatePrice()
    {
        DateTime day = Tickets.First().GetMovieScreening().getDateAndTime();
        bool isWeekday = (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Thursday);


        if (IsStudentOrder)
        {
            calculationBehavior = new StudentCalculation();
        }
        else if (isWeekday)
        {
            calculationBehavior = new NotStudentWeekdayCalculation();
        }
        else
        {
            calculationBehavior = new NotStudentWeekendCalculation();
        }

        return calculationBehavior.CalculatePrice(Tickets);
    }


    public void Export(TicketExportFormat format)
    {

        if (format.Equals(TicketExportFormat.PLAINTEXT))
        {
            exportBehavior = new PlainTextExport();
        }
        else if (format.Equals(TicketExportFormat.JSON))
        {
            exportBehavior = new JsonExport();
        }

        exportBehavior.Export(OrderNr, CalculatePrice(), IsStudentOrder, Tickets, "C:/dev/");
    }
}
