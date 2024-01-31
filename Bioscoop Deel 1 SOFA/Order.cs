using System.Runtime.ConstrainedExecution;

namespace Bioscoop_Deel_1_SOFA;

public class Order
{

    private int OrderNr { get; set; }
    private bool IsStudentOrder { get; set; }
    private List<MovieTicket> Tickets { get; set; } = new List<MovieTicket>();

    private const int DISCOUNT_GROUP_6 = 0.9;

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

    public double calculatePrice()
    {
        double totalPrice = 0;

        if (IsStudentOrder)
        {
            int freeTickets = Tickets.Count / 2;

            for (int i = 0; i < freeTickets; i++)
            {
                MovieTicket ticket = Tickets[i];
                AddTicketPriceToTotalPrice(ticket, ref totalPrice, 2);
            }
        }
        else
        {
            DateTime day = Tickets.Single().getMovieScreening().getDateAndTime();
            if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Tuesday || day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Thursday)
            {
                int freeTickets = Tickets.Count / 2;
                for (int i = 0; i < freeTickets; i++)
                {
                    MovieTicket ticket = Tickets[i];
                    AddTicketPriceToTotalPrice(ticket, ref totalPrice, 3);
                }
            }
            else
            {
                for (int i = 0; i < Tickets.Count; i++)
                {
                    MovieTicket ticket = Tickets[i];
                    AddTicketPriceToTotalPrice(ticket, ref totalPrice, 3);
                }


                if (Tickets.Count >= 6)
                {
                    totalPrice *= DISCOUNT_GROUP_6;
                }
            }
        }

        return totalPrice;
    }

    private void AddTicketPriceToTotalPrice(MovieTicket ticket, ref double totalPrice, double premiumSeatPrice)
    {
        if (ticket.isPremiumTicket())
        {
            totalPrice += ticket.getPricePerSeat() + premiumSeatPrice;
        }
        else
        {
            totalPrice += ticket.getPricePerSeat();
        }
    }

    public void export(TicketExportFormat format)
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
            

        using (StreamWriter writer = new StreamWriter($"C:/dev/{fileName}", true))
        {
            writer.WriteLine($"Order Number: {OrderNr}");
            writer.WriteLine($"Is Student Order: {IsStudentOrder}");
            writer.WriteLine("Tickets:");
            writer.WriteLine($"Price: {calculatePrice()}");

            foreach (MovieTicket ticket in Tickets)
            {
                writer.WriteLine($"  Date and Time: {ticket.getMovieScreening().ToString()}");
                writer.WriteLine($"  Seat: Row{ticket.getRowNr()}, Seat{ticket.getSeatNr()}");
                writer.WriteLine();
            }

        }
    }

    private void ExportToJson()
    {

        string fileName = $"Order_{OrderNr}.json";
        File.Create($"C:/dev/{fileName}").Close();
        using (StreamWriter writer = new StreamWriter($"C:/dev/{fileName}", true))
        {
            writer.WriteLine("{");
            writer.WriteLine($"  \"OrderNr\": {OrderNr},");
            writer.WriteLine($"  \"IsStudentOrder\": {IsStudentOrder.ToString().ToLower()},");
            writer.WriteLine("  \"Tickets\": [");

            for (int i = 0; i < Tickets.Count; i++)
            {
                MovieTicket ticket = Tickets[i];
                writer.WriteLine("    {");
                writer.WriteLine($"      \"DateAndTime\": \"{ticket.ToString()}\",");
                writer.WriteLine($"      \"Seat\": \"{ticket.getSeatNr()}\",");
                writer.WriteLine($"      \"Price\": {ticket.getPricePerSeat()}");
                writer.WriteLine("    }" + (i < Tickets.Count - 1 ? "," : ""));
            }

            writer.WriteLine("  ]");
            writer.WriteLine("}");
        }
    }

}
