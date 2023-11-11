namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();
            int score = 0;

            bool interestedToUseProgramm = true;
            while (interestedToUseProgramm)
            {
                UIMethods.WelcomeText();
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    bool manageQuestions = true;
                    while (manageQuestions)
                    {
                        Question quizmaker = new Question();
                        QuizmakerList.Add(quizmaker);
                        quizmaker.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                        bool addMoreAnswers = true;
                        while (addMoreAnswers)
                        {
                            string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                            quizmaker.AnswersList.Add(answerText);
                            Logic.AddCorrectAnswersToList(answerText, quizmaker);
                            addMoreAnswers = UIMethods.GetAdditionalAnswer();
                        }
                        manageQuestions = UIMethods.GetAdditionalQuestions();
                        Console.Clear();
                    }

                    FileOperations.CreateXMLSerializeFile(QuizmakerList);
                    continue;
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();
                }

                bool playingQuizMaker = true;
                while (playingQuizMaker)
                {
                    int randomQuestionIndex = Logic.GetRandomIndex(QuizmakerList);
                    Console.WriteLine("Please type number associated with answer");

                    UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList,randomQuestionIndex);

                    score = Logic.UserAnswerCheckWithScore(QuizmakerList, score, randomQuestionIndex);

                    Console.WriteLine("Would you like to play another question ?");
                    playingQuizMaker = UIMethods.MakeDecisionYorN();
                    Console.Clear();
                }

                interestedToUseProgramm = UIMethods.MakeDecisionYorN();
            }
        }
    }
}