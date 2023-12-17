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

        /// <summary>
        /// removes answer from answer List and removes correct answer if exists
        /// </summary>
        public void RemoveAnswerFromList()
        {
            int indexToRemoveAt = UIMethods.GetUserInputNum(AnswersList.Count) - 1;
            _answersList.RemoveAt(indexToRemoveAt);
            foreach (int answer in CorrectAnswersList)
            {
                if (answer == indexToRemoveAt)
                {
                    CorrectAnswersList.RemoveAt(CorrectAnswersList.IndexOf(answer));
                    break;
                }
            }
        }

        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public void DisplayAnswers()
        {
            Console.WriteLine("Here's list of Answers: ");
            foreach (string answer in AnswersList)
            {
                Console.WriteLine($"{AnswersList.IndexOf(answer) + 1}" + " " + answer);
            }
        }

        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public void DisplayCorrectAnswers()
        {
            Console.WriteLine("Here's list of Correct Answers");
            foreach (int answer in CorrectAnswersList)
            {
                Console.WriteLine($"Answer Nr: {CorrectAnswersList.IndexOf(answer) + 1} Description of answer: {AnswersList[answer]} .");
            }
        }


    }
}
