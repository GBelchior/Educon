using Educon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(u => u.NidUser);
            Property(u => u.NamPerson).HasMaxLength(128);
            Property(u => u.NamUser).HasMaxLength(32);
            Property(u => u.DesPassword).HasMaxLength(32);
            Property(u => u.DesEmail).HasMaxLength(256);
            HasMany(u => u.UserQuestions);
            ToTable("User");
        }
    }
}
