namespace P6QuizMaker
{
    public class QuestionsAndAnswers
    {
        private string _questionText;
        private List<string> _answersList;
        private List<int> _correctAnswersList;

        public QuestionsAndAnswers()
        {
            _answersList = new List<string>();
            _correctAnswersList = new List<int>();
        }

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
        public int AnswersListCount
        {
            get
            {
                return _answersList.Count;
            }
        }

        public int CorrectAnswersListCount
        {
            get { return _correctAnswersList.Count; }
        }

        public string AnswerListValueAtIndex(int value)
        {
            return _answersList[value];
        }

    }
}
