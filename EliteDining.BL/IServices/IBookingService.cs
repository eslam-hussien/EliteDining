namespace EliteDining.BL.IServices
{
    public interface IBookingService
    {
        Task<int> AddBooking(string phone, int? persons, DateTime? date);
    }
}