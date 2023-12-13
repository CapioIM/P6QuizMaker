namespace P6QuizMaker
{
    public class Question
    {
        private string _questionText { get; set; }
        private List<string> _answersList = new List<string>();
        private List<int> _correctAnswersList = new List<int>();

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

        public List<string> AnswersList
        {
            get
            {
                return _answersList;
            }
        }

        public List<int> CorrectAnswersList
        {
            get
            {
                return _correctAnswersList;
            }
        }
    }
}
