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
                        QuizmakerList = FileOperations.Deserialize();
                        ManageQuestions.ShowListOfQuestion(QuizmakerList);

                        Question quizmakerQuestion = ManageQuestions.AddNewQuestion(ManageQuestions.IsNewQuestion(), QuizmakerList);

                        quizmakerQuestion.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                        ManageQuestions.AddAnswersToQuestion(quizmakerQuestion);

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
                    UIMethods.DisplayAddNumberText();
                    UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList, randomQuestionIndex);

                    score = Logic.UserAnswerCheckWithScore(QuizmakerList, score, randomQuestionIndex);

                    playingQuizMaker = UIMethods.MakeDecisionYorN();
                    Console.Clear();
                }
                UIMethods.DisplayPlayAnotherQuestionText();
                interestedToUseProgramm = UIMethods.MakeDecisionYorN();
            }
        }
    }
}