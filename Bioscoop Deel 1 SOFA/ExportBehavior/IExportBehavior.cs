namespace Bioscoop_Deel_1_SOFA.ExportBehavior;
public interface IExportBehavior
{
   void Export(int OrderNr, decimal totalPrice, bool isStudentOrder, List<MovieTicket> Tickets, string filePath);
}
