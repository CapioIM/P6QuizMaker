namespace P6QuizMaker
{
    internal class ManageQuestions
    {
        /// <summary>
        /// add answer to specified object
        /// </summary>
        /// <param name="quizmaker"> object name, if in list where to find specific object </param>
        public static void AddAnswersToQuestion(Question quizmaker)
        {
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                quizmaker.AnswersList.Add(answerText);
                AddCorrectAnswersToList(answerText, quizmaker);
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        /// <summary>
        /// if true adds index of matching string in AnswersList
        /// </summary>
        /// <param name="answerText">input string of Answer</param>
        /// <param name="quizmaker">Object variable name</param>
        public static void AddCorrectAnswersToList(string answerText, Question quizmaker)
        {
            if (UIMethods.IsCorrectAnswer())
            {
                quizmaker.CorrectAnswersList.Add(answerText);
            }
        }

        public static Question AddNewQuestion(List<Question> QuizmakerList)
        {
                Question quizmakerQuestion = new Question();
                QuizmakerList.Add(quizmakerQuestion);
                return quizmakerQuestion;
        }



    }
}
