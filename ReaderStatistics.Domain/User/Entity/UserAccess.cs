namespace ReaderStatistics.Domain.User.Entity
{
    public class UserAccess
    {
        public User User { get; set; }

        public int NumberOfViews { get; set; }
    }
}