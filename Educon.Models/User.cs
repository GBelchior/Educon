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
        public bool IsOnline { get; set; }
        public int NumEnergyAnswers { get; set; }
        public int NumWaterAnswers { get; set; }
        public int NumEnvironmentAnswers { get; set; }
        public int NumRecyclingAnswers { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
        public Int64 QtdExperience { get; set; }
        public int NumLevel
        {
            get
            {
                // Fórmula: Nível = 0.5 * raiz(xp)
                return Convert.ToInt32(Math.Floor((0.1 * Math.Sqrt(QtdExperience))));
            }
        }
        public virtual ICollection<User> Friends { get; set; }

    }
}
