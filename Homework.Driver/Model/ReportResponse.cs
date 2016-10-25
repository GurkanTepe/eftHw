namespace Homework.Driver.Model
{
    public class ReportResponse
    {

        public Response[] Response { get; set; }
   
    }

    public class Response
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public string Currency { get; set; }
    }
}