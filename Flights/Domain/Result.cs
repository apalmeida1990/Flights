namespace Flights.Domain
{
    public class Result
    {
        public Result(bool status, string message)
        {
            this.Status = status;
            this.Message = message;

        }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}