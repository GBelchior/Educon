using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Models
{
    public class User
    {
        public int NidUser { get; set; }
        public string NamUser { get; set; }
        public string DesPassword { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string NamPerson { get; set; }
        public string DesEmail { get; set; }
        public int NumEnergyAnswers { get; set; }
        public int NumWaterAnswers { get; set; }
        public int NumEnvironmentAnswers { get; set; }
        public int NumRecyclingAnswers { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
        public int NumLevel { get; set; }
        public Int64 NumLevelExperience { get; set; }
        public virtual ICollection<User> Friends { get; set; }

            }   
}
