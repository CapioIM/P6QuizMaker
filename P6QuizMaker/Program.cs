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
                UIMethods.WelcomeText();                                                                              //welcome text
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ManageOrPlay)).Length);             //choice to manage quesitons or play

                if (manageOrPlay == Convert.ToInt32(ManageOrPlay.Manage))
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        bool amending = true;
                        while (amending)
                        {
                            Console.WriteLine("Would you like to amend:\n" +
                                " 1 - Questions \n" +
                                " 2 - Answers\n" +
                                " 3 - Correct Answers");

                            int amendUserChoice = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ModificationTarget)).Length) - 1;
                            ModificationTarget modificaitonTarget = Options.ModificationTargetChoice(amendUserChoice);
                            int questionToAmend = UIMethods.GetUserInputNum(QuizmakerList.Count) - 1;                        //choice which question to amend

                            switch (modificaitonTarget)
                            {
                                case ModificationTarget.QuestionsText:
                                    int maxCountEnumChoice = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                                    UIMethods.ShowListOfAnswers(QuizmakerList[questionToAmend], modificaitonTarget);
                                    UIMethods.DisplayTextAddRemoveAmend();
                                    int addRemoveAmendUserChoice = UIMethods.GetUserInputNum(maxCountEnumChoice);
                                    ModificationOptions modificationOptions = Options.ModificationOptionChoice(addRemoveAmendUserChoice);

                                    switch (modificationOptions)
                                    {
                                        case ModificationOptions.Add:
                                            var question = ManageQuestions.AddNewQuestion(QuizmakerList);
                                            question.QuestionText = UIMethods.DisplayAskToTypeQuestionText();
                                            ManageQuestions.AddAnswersToQuestion(question);
                                            break;
                                        case ModificationOptions.Remove:
                                            UIMethods.ShowListOfQuestion(QuizmakerList);                                                    // show list of questions
                                            int questionToRemove = UIMethods.GetUserInputNum() - 1;
                                            QuizmakerList.RemoveAt(questionToRemove);
                                            break;
                                        case ModificationOptions.Amend:
                                            UIMethods.ModifyQuestionText(QuizmakerList, questionToAmend);
                                            break;
                                    }
                                    Console.Clear();
                                    break;

                                case ModificationTarget.AnswerList:
                                    maxCountEnumChoice = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                                    UIMethods.ShowListOfAnswers(QuizmakerList[questionToAmend], modificaitonTarget);
                                    UIMethods.DisplayTextAddRemoveAmend();
                                    addRemoveAmendUserChoice = UIMethods.GetUserInputNum(maxCountEnumChoice);
                                    modificationOptions = Options.ModificationOptionChoice(addRemoveAmendUserChoice);
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    Console.WriteLine("Type number of answer you want to make changes to!");
                                    int answerCount = QuizmakerList[questionToAmend].AnswersList.Count;
                                    switch (modificationOptions)
                                    {
                                        case ModificationOptions.Add:
                                            ManageQuestions.AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                            break;
                                        case ModificationOptions.Remove:
                                            int answerToRemove = UIMethods.GetUserInputNum(answerCount) - 1;
                                            QuizmakerList[questionToAmend].AnswersList.RemoveAt(answerToRemove);
                                            break;
                                        case ModificationOptions.Amend:
                                            int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                            break;
                                    }
                                    Console.Clear();
                                    break;

                                case ModificationTarget.CorrectAnswerList:
                                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                                    UIMethods.ShowListOfAnswers(QuizmakerList[questionToAmend], modificaitonTarget);

                                    UIMethods.DisplayTextAddRemoveAmend();
                                    maxCountEnumChoice = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                                    addRemoveAmendUserChoice = UIMethods.GetUserInputNum(maxCountEnumChoice);
                                    modificationOptions = Options.ModificationOptionChoice(addRemoveAmendUserChoice);
                                    UIMethods.DisplayTextAnswerNumber();
                                    int correctAnswerCount = QuizmakerList[questionToAmend].CorrectAnswersList.Count;
                                    switch (modificationOptions)
                                    {
                                        case ModificationOptions.Add:
                                            ManageQuestions.AddCorrectAnswer(QuizmakerList[questionToAmend]);
                                            break;
                                        case ModificationOptions.Remove:
                                            int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                                            QuizmakerList[questionToAmend].CorrectAnswersList.RemoveAt(answerToRemove);
                                            break;
                                        case ModificationOptions.Amend:
                                            Console.WriteLine("What this answer would you like to change to ?");
                                            int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                                            QuizmakerList[questionToAmend].CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(QuizmakerList[questionToAmend].CorrectAnswersList.Count) - 1;
                                            break;
                                        default:
                                            Console.WriteLine("Program is taking a nap");
                                            break;
                                    }
                                    Console.Clear();
                                    break;
                            }
                            Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                            amending = UIMethods.MakeDecisionYorN();
                            Console.Clear();
                        }
                        Console.WriteLine("Would you like to continue managing questions and answers ?");
                        FileOperations.CreateXMLSerializeFile(QuizmakerList);  // create xml
                        amendQuestionsAndAnswers = UIMethods.MakeDecisionYorN();
                        Console.Clear();
                    }
                }

                if (manageOrPlay == (int)ManageOrPlay.Play)
                {
                    QuizmakerList = FileOperations.Deserialize();

                    bool playingQuizMaker = true;
                    while (playingQuizMaker)
                    {
                        int randomQuestionIndex = Logic.GetRandomNumber(QuizmakerList.Count - 1);
                        UIMethods.DisplayTextAnswerNumber();
                        UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList, randomQuestionIndex);

                        score += Logic.UserAnswerCheckWithScore(QuizmakerList, randomQuestionIndex);
                        Console.WriteLine($"Your score: {score}");
                        playingQuizMaker = UIMethods.MakeDecisionYorN();
                        Console.Clear();
                    }
                    UIMethods.DisplayPlayAnotherQuestionText();
                    interestedToUseProgramm = UIMethods.MakeDecisionYorN();
                }

            }
        }
    }
}




