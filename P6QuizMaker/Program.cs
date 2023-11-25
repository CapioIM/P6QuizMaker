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
                int manageOrPlay = UIMethods.GetUserInputNum(Enum.GetNames(typeof(GameMode)).Length) - 1;             //choice to manage quesitons or play
                GameMode gameModeChoice = GameMode.Manage;
            

                if (gameModeChoice == GameMode.Manage)
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        bool amending = true;
                        while (amending)
                        {
                            Console.WriteLine("What would you like to amend:\n" +
                                " 1 - Questions \n" +
                                " 2 - Answers\n" +
                                " 3 - Correct Answers");

                            int amendUserChoice = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ModificationTarget)).Length);
                            ModificationTarget modificationTarget = UIMethods.ModificationTargetChoice(amendUserChoice);

                            int countEnum = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                            ModificationOptions modificationOptions = ModificationOptions.Add;

                            int questionToAmend = 0;
                            int addRemoveAmendUserChoice = 0;

                            if (modificationTarget != ModificationTarget.Questions)                                             // answers 
                            {
                                UIMethods.ShowListOfQuestion(QuizmakerList);
                                Console.WriteLine($"Answers for which question would you like to modify?");
                                questionToAmend = UIMethods.GetUserInputNum(QuizmakerList.Count) - 1;
                                UIMethods.ShowListOfAnswers(QuizmakerList[questionToAmend], modificationTarget);
                                UIMethods.DisplayTextAddRemoveAmend();
                                addRemoveAmendUserChoice = UIMethods.GetUserInputNum(countEnum);
                                modificationOptions = UIMethods.ModificationOptionChoice(addRemoveAmendUserChoice);
                            }

                            switch (modificationTarget)
                            {
                                case ModificationTarget.Questions:                                                                      //questions
                                    countEnum = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                                    UIMethods.DisplayTextAddRemoveAmend();
                                    addRemoveAmendUserChoice = UIMethods.GetUserInputNum(countEnum);
                                    modificationOptions = UIMethods.ModificationOptionChoice(addRemoveAmendUserChoice);

                                    if (modificationOptions != ModificationOptions.Add)
                                    {
                                        UIMethods.ShowListOfQuestion(QuizmakerList);
                                        UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                                        questionToAmend = UIMethods.GetUserInputNum(QuizmakerList.Count) - 1;
                                    }
                                    switch (modificationOptions)
                                    {
                                        case ModificationOptions.Add:                                                                   //add
                                            var question = ManageQuestions.AddNewQuestion(QuizmakerList);
                                            question.QuestionText = UIMethods.GetQuestionText();
                                            ManageQuestions.AddAnswersToQuestion(question);
                                            break;
                                        case ModificationOptions.Remove:                                                                 //remove
                                            QuizmakerList.RemoveAt(questionToAmend);
                                            break;
                                        case ModificationOptions.Amend:                                                                     // amend
                                            UIMethods.ModifyQuestionText(QuizmakerList[questionToAmend]);
                                            break;
                                    }
                                    break;

                                case ModificationTarget.AnswerList:

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
                                            UIMethods.DisplayTextAskWhatToChange();
                                            QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                            break;
                                    }
                                    break;

                                case ModificationTarget.CorrectAnswerList:

                                    UIMethods.DisplayPlayAnswerNumber();
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
                                            UIMethods.DisplayTextAskWhatToChange();
                                            int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                                            QuizmakerList[questionToAmend].CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(QuizmakerList[questionToAmend].CorrectAnswersList.Count) - 1;
                                            break;
                                    }
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

                if (gameModeChoice == GameMode.Play)
                {
                    QuizmakerList = FileOperations.Deserialize();

                    bool playingQuizMaker = true;
                    while (playingQuizMaker)
                    {
                        int randomQuestionIndex = Logic.GetRandomNumber(QuizmakerList.Count - 1);
                        UIMethods.DisplayPlayAnswerNumber();
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




