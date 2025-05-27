namespace TestAPI.Models
{
    public class WorkingCalendar
    {
        public int Id { get; set; }
        public DateTime ExceptionDate { get; set; }
        public bool? IsWorkingDay { get; set; }
    }
}
