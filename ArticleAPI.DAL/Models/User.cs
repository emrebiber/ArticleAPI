using System;

namespace ArticleAPI.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string ActivationGuid { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
