using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchieveAchievementLibrary.Entity
{
    public class PlayerFriend
    {
        public Guid Player1Id { get; set; }
        public Player Player1 { get; set; }
        public Guid Player2Id { get; set; }
        public Player Player2 { get; set; }
    }
}
