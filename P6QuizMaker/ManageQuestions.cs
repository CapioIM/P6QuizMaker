namespace P6QuizMaker
{
    internal class ManageQuestions
    {

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
                quizmaker.CorrectAnswersIndexList.Add(quizmaker.AnswersList.IndexOf(answerText));
            }
        }

        public static bool IsNewQuestion()
        {
            return UIMethods.GetNewQuestion();
        }

        public static Question AddNewQuestion(bool yes, List<Question> QuizmakerList)
        {
            if (yes)
            {
                Question quizmakerQuestion = new Question();
                QuizmakerList.Add(quizmakerQuestion);
                return quizmakerQuestion;
            }
            
            return null;
        }



        /// <summary>
        /// WriteLine List with object
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<Question> list)
        {
            foreach (Question question in list)
            {
                Console.WriteLine($"{list.IndexOf(question)}" + " " + question.QuestionText);
            }
        }

    }
}
