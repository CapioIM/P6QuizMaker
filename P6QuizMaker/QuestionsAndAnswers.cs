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

        public string QuestionText
        {
            get { return _questionText; }
            set { _questionText = value; }
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

        public static QuestionsAndAnswers CopyQuestionObject(QuestionsAndAnswers originalQuestionAndData)
        {
            QuestionsAndAnswers copyObj = new QuestionsAndAnswers();
            copyObj.QuestionText = originalQuestionAndData.QuestionText;
            foreach (string answer in originalQuestionAndData.AnswersList)
            {
                copyObj.AnswersList.Add(answer);
            }
            return copyObj;
        }

    }
}
