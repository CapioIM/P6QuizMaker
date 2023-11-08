namespace P6QuizMaker
{                                                   // comented code is to speed up testing :)
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();

            while (true)
            {
                UIMethods.WelcomeText();
                int manageOrPlay = UIMethods.GetUserInputNum();

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    bool addQuestions = true;
                    while (addQuestions)
                    {
                        UIMethods.WelcomeAddQuestionsChoice();

                        Question quizmaker = new Question();
                        QuizmakerList.Add(quizmaker);
                        quizmaker.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                        bool addMoreAnswers = true;
                        while (addMoreAnswers)
                        {
                            string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                            quizmaker.AnswersList.Add(answerText);

                            if (UIMethods.IsCorrectAnswer())
                            {
                                quizmaker.CorrectAnswersIndexList.Add(quizmaker.AnswersList.IndexOf(answerText));
                            }

                            addMoreAnswers = UIMethods.GetAdditionalAnswer();
                        }
                        addQuestions = UIMethods.GetAdditionalQuestions();
                        Console.Clear();
                        UIMethods.WelcomeText();
                    }

                    FileOperations.CreateXMLSerializeFile(QuizmakerList);
                    break;
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();

                }
                Console.ReadLine();
            }
        }
    }
}