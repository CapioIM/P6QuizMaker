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
                UIMethods.WelcomeText();                                                                //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();                                         //choice to manage quesitons or play

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        QuizmakerList = FileOperations.Deserialize();
                        UIMethods.ShowListOfQuestion(QuizmakerList);
                        int questionToAmend = UIMethods.GetUserInputNum() - 1;                          //choice which question to amend
                        Console.WriteLine($"{QuizmakerList[questionToAmend].QuestionText}");
                        UIMethods.ShowListOfQuestion(QuizmakerList);                              // show list of questions

                        bool amending = true;
                        while (amending)
                        {
                            Console.WriteLine("Would you like to amend:\n" +
                                " 1 - Question Text\n" +
                                " 2 - Answers\n" +
                                " 3 - Correct Answers\n");

                            int amendUserChoice = UIMethods.GetUserInputNum() - 1;
                            Options.ModificaitonTarget modificaitonTarget = Options.ModificationTargetChoice(amendUserChoice);

                            switch (modificaitonTarget)
                            {
                                case Options.ModificaitonTarget.QuestionsText:
                                    Options.ModifyQuestionText(QuizmakerList, questionToAmend);
                                    break;

                                case Options.ModificaitonTarget.AnswerList:
                                    UIMethods.DisplayTextAddRemoveAmend();
                                    int maxCountEnumChoice = UIMethods.EnumLength(Options.EnumChoice.ModificationOptions);
                                    int addRemoveAmendUserChoice = UIMethods.GetUserInputNum(maxCountEnumChoice);
                                    Options.ModificationOptions modificationOptions = Options.ModificationOptionChoice(addRemoveAmendUserChoice);
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    UIMethods.ShowListOfAnswers(QuizmakerList, questionToAmend, amendUserChoice);
                                    UIMethods.DisplayTextAnswerNumber();
                                    switch (modificationOptions)
                                    {
                                        case Options.ModificationOptions.Add:
                                            ManageQuestions.AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                            break;
                                        case Options.ModificationOptions.Remove:
                                            int answerToRemove = UIMethods.GetUserInputNum() - 1;
                                            QuizmakerList[questionToAmend].AnswersList.RemoveAt(answerToRemove);
                                            break;
                                        case Options.ModificationOptions.Amend:
                                            int answerToAmend = UIMethods.GetUserInputNum() - 1;
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                            break;
                                        default:
                                            Console.WriteLine("Program is taking a nap");
                                            break;
                                    }
                                    break;

                                case Options.ModificaitonTarget.CorrectAnswerList:
                                    UIMethods.DisplayTextAddRemoveAmend();
                                    maxCountEnumChoice = UIMethods.EnumLength(Options.EnumChoice.ModificationOptions);
                                    addRemoveAmendUserChoice = UIMethods.GetUserInputNum(maxCountEnumChoice);
                                    modificationOptions = Options.ModificationOptionChoice(addRemoveAmendUserChoice);
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    UIMethods.ShowListOfAnswers(QuizmakerList, questionToAmend, amendUserChoice);
                                    UIMethods.DisplayTextAnswerNumber();
                                    switch (modificationOptions)
                                    {
                                        case Options.ModificationOptions.Add:
                                            ManageQuestions.AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                            break;
                                        case Options.ModificationOptions.Remove:
                                            int answerToRemove = UIMethods.GetUserInputNum() - 1;
                                            QuizmakerList[questionToAmend].CorrectAnswersList.RemoveAt(answerToRemove);

                                            break;
                                        case Options.ModificationOptions.Amend:
                                            int answerToAmend = UIMethods.GetUserInputNum() - 1;
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            QuizmakerList[questionToAmend].CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum() - 1;
                                            break;
                                        default:
                                            Console.WriteLine("Program is taking a nap");
                                            break;
                                    }
                                    break;
                            }

                        }
                        Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                        amending = UIMethods.MakeDecisionYorN();

                    }
                    Console.WriteLine("end of manage while loop to test programm");
                    FileOperations.CreateXMLSerializeFile(QuizmakerList);  // create xml
                    amendQuestionsAndAnswers = UIMethods.MakeDecisionYorN();
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();
                }

                bool playingQuizMaker = true;
                while (playingQuizMaker)
                {
                    int randomQuestionIndex = Logic.GetRandomIndex(QuizmakerList);
                    UIMethods.DisplayTextAnswerNumber();
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




