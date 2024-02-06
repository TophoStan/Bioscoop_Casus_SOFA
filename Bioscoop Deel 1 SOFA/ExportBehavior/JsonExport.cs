namespace Bioscoop_Deel_1_SOFA.ExportBehavior;

public class JsonExport : IExportBehavior
{
    public void Export(int OrderNr, decimal totalPrice, bool isStudentOrder, List<MovieTicket> Tickets, string filePath)
    {
        string fileName = $"Order_{OrderNr}.json";
        File.Create($"{filePath}{fileName}").Close();
        using (StreamWriter writer = new($"{filePath}{fileName}", true))
        {
            writer.WriteLine("{");
            writer.WriteLine($"  \"OrderNr\": {OrderNr},");
            writer.WriteLine($"  \"Price total\": {totalPrice},");
            writer.WriteLine($"  \"IsStudentOrder\": {isStudentOrder.ToString().ToLower()},");
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
