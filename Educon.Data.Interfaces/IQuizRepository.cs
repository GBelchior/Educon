using Educon.Models;

namespace Educon.Data.Interfaces
{
    public interface IQuizRepository 
    {
        Question GetQuestion(int ANidQuestion);
        void ComputeAnswer(int ANidUser, int ANidQuestion);
    }
}
