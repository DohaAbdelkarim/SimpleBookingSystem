namespace SimpleBookingSystem.API.Models
{
    public class CreateBookingResponseModel
    {
        public CreateBookingResponseModel() { }
        public CreateBookingResponseModel(string message)
        {
            Message = message;
        }
        public CreateBookingResponseModel(long? bookingId, string message)
        {
            BookingId = bookingId;
            Message = message;
        }
        public long? BookingId { get; set; }
        public string Message { get; set; }
    }
}