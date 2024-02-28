using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Contact : BaseEntity
    {
        public string Link { get; set; }
        public string App { get; set; }
        public string NameInApp { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
