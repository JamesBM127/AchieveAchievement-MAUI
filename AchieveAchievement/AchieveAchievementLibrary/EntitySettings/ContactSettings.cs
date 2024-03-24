using AchieveAchievementLibrary.Entity;
using System.Text;

namespace AchieveAchievementLibrary.EntitySettings
{
    public static class ContactSettings
    {
        public static bool IsValid(this Contact contact)
        {
            bool isValid = false;

            if (contact == null)
                return false;

            else if (!string.IsNullOrWhiteSpace(contact.Link))
                isValid = true;

            else if (!string.IsNullOrWhiteSpace(contact.App) &&
                     !string.IsNullOrWhiteSpace(contact.NameInApp))
                isValid = true;

            return isValid;
        }
    }
}
