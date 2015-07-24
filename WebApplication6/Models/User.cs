using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication6.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        public string UID { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Hometown")]
        public string HomeTown { get; set; }

        public static DateTime convertBirthday(string uid)
        {
            long.Parse(uid);
            uid = uid.Substring(0, 6);
            StringBuilder str = new StringBuilder(uid);
            str.Insert(2, "-");
            str.Insert(5, "-");
            DateTime birthDate = new DateTime();
            if (!DateTime.TryParseExact(str.ToString(), "yy-MM-dd", null,
                    DateTimeStyles.None, out birthDate))
            {
                throw new Exception("Invalid user ID");
            }
            return birthDate;
        }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}