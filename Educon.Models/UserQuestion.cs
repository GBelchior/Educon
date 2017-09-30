using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Models
{
    public class UserQuestion
    {
        public int NidQuestion { get; set; }
        public int NidUser { get; set; }
        public int QtdAnswers { get; set; }
        public virtual Question Question{ get; set; }
        public virtual User User { get; set; }

    }
}
