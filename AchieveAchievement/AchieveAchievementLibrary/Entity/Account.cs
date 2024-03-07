using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Account : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
