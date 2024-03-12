using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public bool ShowContacts { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public string Languages { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<PlayerFriend> Friends { get; set; }
    }
}
