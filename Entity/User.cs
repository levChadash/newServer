using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class User
    {
        public User()
        {
            CommentFromUsers = new HashSet<Comment>();
            CommentToUsers = new HashSet<Comment>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> CommentFromUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> CommentToUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
}
