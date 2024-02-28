using AchieveAchievementLibrary.Enum;
using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public bool CrossPlataformGameplay { get; set; }
        public bool ObtainablePlatinum { get; set; }
        public bool HideGame { get; set; }
        public string PlataformsString { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}
