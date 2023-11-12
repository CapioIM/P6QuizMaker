using System.Xml.Serialization;

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
                UIMethods.WelcomeText();                                        //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();                 //choice to manage quesitons or play

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    Console.WriteLine("Do you want to add new question or amend existing question");
                    int newOrAmend = UIMethods.GetUserInputNum();               // choice to add new or amend existing

                    if (newOrAmend == 1)                                        // add new question
                    {
                        bool addNewQuestions = true;
                        while (addNewQuestions)
                        {
                            QuizmakerList = FileOperations.Deserialize();
                            ManageQuestions.ShowListOfQuestion(QuizmakerList);

                            Question quizmakerQuestion = ManageQuestions.AddNewQuestion(ManageQuestions.IsNewQuestion(), QuizmakerList);

                            quizmakerQuestion.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                            ManageQuestions.AddAnswersToQuestion(quizmakerQuestion);

                            addNewQuestions = UIMethods.GetAdditionalQuestions();
                            Console.Clear();
                        }
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