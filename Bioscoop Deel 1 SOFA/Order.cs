using Bioscoop_Deel_1_SOFA.CalculationBehavior;

namespace Bioscoop_Deel_1_SOFA;

public class Order
{
    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    private List<MovieTicket> Tickets { get; set; } = new List<MovieTicket>();


    private ICalculationBehavior calculationBehavior;


    public Order(int orderNr, bool isStudentOrder)
    {
        OrderNr = orderNr;
        IsStudentOrder = isStudentOrder;

        if (isStudentOrder)
        {
            calculationBehavior = new StudentCalculation();
        }
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
                
        if (isWeekday && !IsStudentOrder)
        {
            calculationBehavior = new NotStudentWeekdayCalculation();
        }
        else if (!IsStudentOrder)
        {
            calculationBehavior = new NotStudentWeekendCalculation();
        }

        return calculationBehavior.CalculatePrice(Tickets);
    }


    public void Export(TicketExportFormat format)
    {
        switch (format)
        {
            case TicketExportFormat.PLAINTEXT:
                ExportToPlainText();
                break;
            case TicketExportFormat.JSON:
                ExportToJson();
                break;
            default:
                throw new ArgumentException("Invalid ticket export format.");
        }
    }

    private void ExportToPlainText()
    {
        string fileName = $"Order_{OrderNr}.txt";
        Console.WriteLine(fileName);

        //Create the text file
        File.Create($"C:/dev/{fileName}").Close();
            

        using (StreamWriter writer = new ($"C:/dev/{fileName}", true))
        {
            writer.WriteLine($"Order Number: {OrderNr}");
            writer.WriteLine($"Is Student Order: {IsStudentOrder}");
            writer.WriteLine("Tickets:");
            writer.WriteLine($"Price total: {CalculatePrice()}");

            foreach (MovieTicket ticket in Tickets)
            {
                writer.WriteLine($"  Date and Time: {ticket.GetMovieScreening().getDateAndTime()}");
                writer.WriteLine($"  Seat: Row{ticket.GetRowNr()}, Seat{ticket.GetSeatNr()}");
                writer.WriteLine();
            }

        }
    }

    private void ExportToJson()
    {

        string fileName = $"Order_{OrderNr}.json";
        File.Create($"C:/dev/{fileName}").Close();
        using (StreamWriter writer = new ($"C:/dev/{fileName}", true))
        {
            writer.WriteLine("{");
            writer.WriteLine($"  \"OrderNr\": {OrderNr},");
            writer.WriteLine($"  \"Price total\": {CalculatePrice()},");
            writer.WriteLine($"  \"IsStudentOrder\": {IsStudentOrder.ToString().ToLower()},");
            writer.WriteLine("  \"Tickets\": [");

            for (int i = 0; i < Tickets.Count; i++)
            {
                MovieTicket ticket = Tickets[i];
                writer.WriteLine("    {");
                writer.WriteLine($"      \"Date and time\": \"{ticket.GetMovieScreening().getDateAndTime()}\",");
                writer.WriteLine($"      \"Seat\": \"{ticket.GetSeatNr()}\"");
                writer.WriteLine("    }" + (i < Tickets.Count - 1 ? "," : ""));
            }

            writer.WriteLine("  ]");
            writer.WriteLine("}");
        }
    }

}
