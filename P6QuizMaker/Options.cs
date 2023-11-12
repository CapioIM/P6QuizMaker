namespace P6QuizMaker
{
    internal class Options
    {
        public enum OptionChoice
        {
            Add = 1,
            Remove = 2,
            Amend = 3
        }

        public enum List
        {
            QuestionsText = 1,
            AnswerList = 2,
            CorrectAnswerList = 3
        }

        public static void DisplayList(List<Question> QuizmakerList, int whichQuestiontoAmend, int choice)
        {
            if (Convert.ToInt32(List.CorrectAnswerList) == choice)
            {
                foreach (string answer in QuizmakerList[whichQuestiontoAmend].CorrectAnswersList)
                {
                    Console.WriteLine($"{QuizmakerList[whichQuestiontoAmend].CorrectAnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (Convert.ToInt32(List.AnswerList) == choice)
            {
                foreach (string answer in QuizmakerList[whichQuestiontoAmend].AnswersList)
                {
                    Console.WriteLine($"{QuizmakerList[whichQuestiontoAmend].AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (Convert.ToInt32(List.QuestionsText) == choice)
            {
                foreach (Question question in QuizmakerList)
                {
                    Console.WriteLine(QuizmakerList[whichQuestiontoAmend].QuestionText);
                }
            }
        }

        public static void AddAnswer(Question quizmaker, int answerOrCorrect)
        {
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                if (Convert.ToInt32(List.AnswerList) == 2)
                {
                    quizmaker.AnswersList.Add(answerText);
                    ManageQuestions.AddCorrectAnswersToList(answerText, quizmaker);
                }
                if (Convert.ToInt32(List.CorrectAnswerList) == 3)
                {
                    quizmaker.CorrectAnswersList.Add(answerText);
                }
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        public static void AmendQuestionText(List<Question> QuizmakerList, int questionToAmend)
        {
            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
            QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
        }

    }
}
