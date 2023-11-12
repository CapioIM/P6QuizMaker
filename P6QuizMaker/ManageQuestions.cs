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

        public static Question AddNewQuestion(List<Question> QuizmakerList)
        {
                Question quizmakerQuestion = new Question();
                QuizmakerList.Add(quizmakerQuestion);
                return quizmakerQuestion;
        }



        /// <summary>
        /// WriteLine List with object
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<Question> list)
        {
            foreach (Question question in list)
            {
                Console.WriteLine($"{list.IndexOf(question)+1}" + " " + question.QuestionText);
            }
        }

        public static void ShowListOfAnswers(List<Question> QuizmakerList, int questionToAmend)
        {
            foreach (string answer in QuizmakerList[questionToAmend].AnswersList)
            {
                Console.WriteLine($"{QuizmakerList[questionToAmend].AnswersList.IndexOf(answer) + 1}" + " " + answer);
            }
        }

    }
}
