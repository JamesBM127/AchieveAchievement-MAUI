using JBMDatabase;

namespace AchieveAchievementLibrary.Entity
{
    public class Achievement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tutorial { get; set; }
        public bool IsOnline { get; set; }
        public bool IsSpoiler { get; set; }
        public bool Missable { get; set; }
        public double DifficultyLevel { get; set; }
        public double FunLevel { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
