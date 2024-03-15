using AchieveAchievementLibrary.Entity;
using System.Text;

namespace AchieveAchievementLibrary.EntitySettings
{
    public static class PlayerSettings
    {
        public static bool IsValid(this Player player)
        {
            StringBuilder errors = new StringBuilder();
            errors.Append("[B00002] Invalid properties");
            byte i = 0;

            if (string.IsNullOrWhiteSpace(player.Name) || player.Name.Length > 15)
                errors.Append($" [{++i}]Name");

            if (player.BirthDate > DateTime.Now || player.BirthDate == new DateTime())
                errors.Append($" [{++i}]BirthDate");

            if (i != 0)
                throw new ArgumentException(errors.ToString());
            else
                return true;
        }
    }
}
