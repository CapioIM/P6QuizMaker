namespace P6QuizMaker
{                                                   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();

            while (true)
            {
                UIMethods.WelcomeText();
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();
                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    bool addQuestions = true;
                    while (addQuestions)
                    {
                        Question quizmaker = new Question();
                        QuizmakerList.Add(quizmaker);
                        quizmaker.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                        bool addMoreAnswers = true;
                        while (addMoreAnswers)
                        {
                            string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                            quizmaker.AnswersList.Add(answerText);

                            Logic.AddCorrectAnswersToList(answerText,quizmaker);

                            addMoreAnswers = UIMethods.GetAdditionalAnswer();
                        }
                        addQuestions = UIMethods.GetAdditionalQuestions();
                        Console.Clear();
                    }

                    FileOperations.CreateXMLSerializeFile(QuizmakerList);
                    continue;
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();
                }

                //

                Console.ReadLine();
            }
        }
    }
}