namespace EliteDining.APIs.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string EName { get; set; } = null!;

        public DateTime? DateHired { get; set; }

        public int? HourlyPay { get; set; }

        public int? RoleId { get; set; }
    }
}
