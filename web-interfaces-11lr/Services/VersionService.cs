using ClosedXML.Excel;

namespace _6lr.Controllers
{
    public interface IVersionService
    {
        Stream GenerateExcel();
        int GetIntegerData();
        string GetTextData();
    }
    public class VersionService : IVersionService
    {
        public Stream GenerateExcel()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");
            worksheet.Cell("A" + 1).Value = "Hello";
            worksheet.Cell("A" + 2).Value = "World";
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public int GetIntegerData()
        {
            return 7;
        }

        public string GetTextData()
        {
            return "Hello, world!";
        }
    }
}