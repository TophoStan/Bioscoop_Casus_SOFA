
namespace Bioscoop_Deel_1_SOFA;

class Program
{
    static void Main(string[] args)
    {
        Movie movie = new("The Matrix");
        MovieScreening movieScreening = new(movie, DateTime.Now, 10);
        MovieTicket movieTicket1 = new(movieScreening, 1, 2, false);
        MovieTicket movieTicket2 = new(movieScreening, 1, 3, true);
        MovieTicket movieTicket3 = new(movieScreening, 1, 4, false);
        MovieTicket movieTicket4 = new(movieScreening, 1, 5, true);

        Order order = new(1, true);
        order.addSeatReservation(movieTicket1);
        order.addSeatReservation(movieTicket2);
        order.addSeatReservation(movieTicket3);
        order.addSeatReservation(movieTicket4);
        Console.WriteLine(order.calculatePrice());
        order.Export(TicketExportFormat.PLAINTEXT);

        order.Export(TicketExportFormat.JSON);

    }
}
