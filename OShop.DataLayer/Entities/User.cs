using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserDisplayName { get; set; } = "کاربر بی نام";
        public string UserEmail { get; set; }
        public string UserAvatar { get; set; } = "NoAvatar.png";
        public string UserPhoneNumber { get; set; }
        public DateTimeOffset UserRegisterDate { get; set; }
        public Guid UserActivationCode { get; set; }
        public bool IsUserActive { get; set; } = false;
        public string UserPassword { get; set; }
        public string? ShopName { get; set; }
        #region Relations
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Question> Questions { get; set; }

        #endregion
    }
}
