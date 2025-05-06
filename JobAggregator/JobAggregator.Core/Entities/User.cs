using JobAggregator.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobAggregator.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public UserStatuse Statuse { get; set; }
        public int RoleId { get; set; }
        public List<Organization>? Organizations { get; set; }
        public List<Article>? Articles { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<UserAplication>? UserAplications { get; set; }
        public List<OrganizationAplication>? OrganizationAplications { get; set; }
        [InverseProperty("User1")]
        public List<Chat>? Chats1 { get; set; }
        [InverseProperty("User2")]
        public List<Chat>? Chats2 { get; set; }
        public List<Message>? Messages { get; set; }
        public List<Resume>? Resumes { get; set; }
    }
}
