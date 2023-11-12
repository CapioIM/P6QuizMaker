namespace P6QuizMaker
{
    public class Question
    {
        private string _questionText { get; set; }
        public List<string> AnswersList = new List<string>();
        public List<string> CorrectAnswersList = new List<string>();

        public override string ToString()
        {
            return $"{_questionText}";
        }

        public string QuestionText
        {
            get
            {
                return _questionText;
            }
            set
            {
                _questionText = value;
            }
        }
    }
}
