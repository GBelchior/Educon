using Educon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Mappings
{
    public class UserQuestionMap: EntityTypeConfiguration<UserQuestion>
    {
        public UserQuestionMap()
        {
            HasKey(u => new { u.NidQuestion, u.NidUser });



        }
    }
}
