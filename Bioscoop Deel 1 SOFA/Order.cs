using Bioscoop_Deel_1_SOFA.CalculationBehavior;
using Bioscoop_Deel_1_SOFA.ExportBehavior;

namespace Bioscoop_Deel_1_SOFA;

using System.Text;
using System.Text.Json.Nodes;

public class Order
{
    private int orderNr;
    private bool isStudentOrder;
    private List<MovieTicket> tickets = new List<MovieTicket>();

    public Order(int orderNr, bool isStudentOrder)
    {
        this.orderNr = orderNr;
        this.isStudentOrder = isStudentOrder;
    }

    public int GetOrderNr()
    {
        return orderNr;
    }

    public void AddSeatReservation(MovieTicket ticket)
    {
        tickets.Add(ticket);
    }

    public decimal CalculatePrice()
    {
        decimal total = decimal.Zero;

        for (int i = 0; i < tickets.Count; i++)
        {
            MovieTicket ticket = tickets[i];`
            DateTime screeningDate = ticket.GetScreeningDate();

            bool isWeekend = screeningDate.DayOfWeek == DayOfWeek.Saturday || screeningDate.DayOfWeek == DayOfWeek.Sunday;

            decimal ticketPrice = ticket.GetPrice();

            // Premium fee for students is ... for non-students is ...
            if (ticket.IsPremiumTicket())
                ticketPrice += isStudentOrder ? 2 : 3;

            // Every second ticket is free for students or on weekdays
            if ((isStudentOrder || !isWeekend) && (i + 1) % 2 == 0)
                ticketPrice = decimal.Zero;

            // On weekends, non-students pay full price unless the order consists of 6 or more tickets
            if (isWeekend && !isStudentOrder && tickets.Count >= 6)
                ticketPrice *= 0.9M;

            if (DateTime.Now.Month == 12)
                ticketPrice = decimal.Zero;

            total += ticketPrice;
        }

        return total;
    }

    public void Export(TicketExportFormat exportFormat)
    {
        switch (exportFormat)
        {
            case TicketExportFormat.PLAINTEXT:
                ExportToPlainText();
                break;

            case TicketExportFormat.JSON:
                ExportToJson();
                break;
        }
    }

    private void ExportToPlainText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Order: {this.orderNr} | Price: {this.CalculatePrice():C2}");
        foreach (MovieTicket ticket in tickets)
            sb.AppendLine(ticket.ToString());

        string path = Path.Combine(Path.GetTempPath(), "", $"docentoscoop_order_{this.orderNr}.txt");
        File.WriteAllText(path, sb.ToString());
    }

    private void ExportToJson()
    {
        JsonObject jsonOrder = new JsonObject
            {
                { "orderNr", this.orderNr },
                { "isStudentOrder", this.isStudentOrder },
                { "totalPrice", this.CalculatePrice() }
            };

        JsonArray jsonTickets = new JsonArray();
        foreach (MovieTicket ticket in tickets)
        {
            JsonObject jsonTicket = new JsonObject
                {
                    { "screeningDate", ticket.GetScreeningDate() },
                    { "isPremiumTicket", ticket.IsPremiumTicket() },
                    { "price", ticket.GetPrice() },
                };
            jsonTickets.Add(jsonTicket);
        }
        jsonOrder.Add("tickets", jsonTickets);

        string path = Path.Combine(Path.GetTempPath(), "", $"docentoscoop_order_{this.orderNr}.json");
        File.WriteAllText(path, jsonOrder.ToString());
    }
}
