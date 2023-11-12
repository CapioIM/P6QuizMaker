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
                quizmaker.CorrectAnswersIndexList.Add(answerText);
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

        public static void ShowListOfAnswers(List<Question> QuizmakerList, int questionToAmend,int amendChoice)
        {
            if (amendChoice == 2)
            {
                foreach (string answer in QuizmakerList[questionToAmend].AnswersList)
                {
                    Console.WriteLine($"{QuizmakerList[questionToAmend].AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (amendChoice == 3)
            {
                foreach (string answer in QuizmakerList[questionToAmend].CorrectAnswersIndexList)
                {
                    Console.WriteLine($"{QuizmakerList[questionToAmend].CorrectAnswersIndexList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
        }

    }
}
