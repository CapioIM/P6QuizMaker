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



        /*
                public static bool IsQuestionListEmpty(List<Question> list)
                {
                    if (list.Any())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                public static bool IsAnswerListEmpty(List<string> list)
                {
                    if (list.Any())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
        */
    }
}
