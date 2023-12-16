namespace P6QuizMaker
{
    public class QuestionsAndAnswers
    {
        private string _questionText { get; set; }
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
    
        public void AddAnswerToList()
        {
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                _answersList.Add(answerText);
                if (UIMethods.IsCorrectAnswer())
                {
                    _correctAnswersList.Add(_answersList.IndexOf(answerText));
                }
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }
/*
        public void RemoveAnswerFromList()
        {
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
*/
    }
}
