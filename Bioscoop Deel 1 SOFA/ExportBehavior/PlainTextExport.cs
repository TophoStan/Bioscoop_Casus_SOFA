
namespace Bioscoop_Deel_1_SOFA.ExportBehavior;

public class PlainTextExport : IExportBehavior
{
    public void Export(int OrderNr, decimal totalPrice, bool isStudentOrder, List<MovieTicket> Tickets, string filePath)
    {
        string fileName = $"Order_{OrderNr}.txt";
        Console.WriteLine(fileName);

        //Create the text file
        File.Create($"{filePath}{fileName}").Close();
        using (StreamWriter writer = new($"{filePath}{fileName}", true))
        {
            writer.WriteLine($"Order Number: {OrderNr}");
            writer.WriteLine($"Is Student Order: {isStudentOrder.ToString().ToLower()}");
            writer.WriteLine("Tickets:");
            writer.WriteLine($"Price total: {totalPrice}");

            foreach (MovieTicket ticket in Tickets)
            {
                writer.WriteLine($"  Date and Time: {ticket.GetMovieScreening().getDateAndTime()}");
                writer.WriteLine($"  Seat: Row{ticket.GetRowNr()}, Seat{ticket.GetSeatNr()}");
                writer.WriteLine();
            }

        }
    }
}
