using System.Runtime.ConstrainedExecution;

namespace Bioscoop_Deel_1_SOFA;

public class Order
{
    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    private List<MovieTicket> Tickets { get; set; } = new List<MovieTicket>();


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
        decimal totalPrice = decimal.Zero;
        bool canHaveDiscount = Tickets.Count >= 6;

        DateTime day = Tickets.First().GetMovieScreening().getDateAndTime();
        bool isWeekday = (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Thursday);
                
        


        for (int i = 0; i < Tickets.Count; i++)
        {
            MovieTicket ticket = Tickets[i];
            // A- Is een student
            if(IsStudentOrder)
            {
                //B- Is 2e kaartje
                if(!((i + 1) % 2 == 0))
                {
                    //C - Is een premium kaart
                    if (ticket.IsPremiumTicket()) totalPrice += 2;
                    totalPrice += ticket.GetPricePerSeat();
                } 
            } 
            // D- Iedereen behalve student
            else
            {
                // F- Iedereen In het weekend
                if(!isWeekday)
                {
                    //G - is een premium kaart
                    if (ticket.IsPremiumTicket()) totalPrice += 3;
                    

                    totalPrice += ticket.GetPricePerSeat();
                } 
                // E- Iedereen buiten het weekend
                else 
                {
                    // H- Is 2e kaartje
                    if (!((i + 1) % 2 == 0))
                    {
                        if (ticket.IsPremiumTicket()) totalPrice += 3;
                        totalPrice += ticket.GetPricePerSeat();
                    }
                }
            }
        }

        //H - Groep is groter dan 6
        if (canHaveDiscount && !isWeekday && !IsStudentOrder) totalPrice *= 0.9m;

        return totalPrice;
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
