namespace Educon.ViewModels
{
    public class MultiPlayerEndGameViewModel
    {
        public string NamOpponent { get; set; }
        public int QtyCorQuestionsOpponent { get; set; }
        public int QtyCorQuestions { get; set; }
        public int QtyQuestions { get; set; }
        public int QtyExperience { get; set; }
        public bool BothFinishedGame { get; set; }
    }
}