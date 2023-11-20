namespace EliteDining.APIs.ViewModel
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsWaiter { get; set; }

        public bool? IsChef { get; set; }
    }
}
