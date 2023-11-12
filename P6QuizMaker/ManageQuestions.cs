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
                Logic.AddCorrectAnswersToList(answerText, quizmaker);
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
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
