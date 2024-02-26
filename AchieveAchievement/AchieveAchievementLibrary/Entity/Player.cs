using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool ShowContacts { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
