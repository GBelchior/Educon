using Educon.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Mappings
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            HasKey(q => q.NidQuestion);
            Property(q => q.DesQuestion).HasMaxLength(512);
            Property(q => q.DesAnswerOne).HasMaxLength(512);
            Property(q => q.DesAnswerTwo).HasMaxLength(512);
            Property(q => q.DesAnswerThree).HasMaxLength(512);
            Property(q => q.DesAnswerFour).HasMaxLength(512);
            //Property(q => q.Answer).HasMaxLength(512);
            HasMany(u => u.UserQuestions);
            ToTable("Question");
        }
    }
}
