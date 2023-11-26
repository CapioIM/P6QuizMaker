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
                GameMode gameModeChoice = UIMethods.GameModeChoice(manageOrPlay);

                if (gameModeChoice == GameMode.Manage)
                {
                    QuizmakerList = FileOperations.Deserialize();
                    bool amendQuestionsAndAnswers = true;
                    while (amendQuestionsAndAnswers)
                    {
                        bool amending = true;
                        while (amending)
                        {
                            UIMethods.DisplayOptionsTargetToModify();

                            int amendUserChoice = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ModificationTarget)).Length);
                            ModificationTarget modificationTarget = UIMethods.ModificationTargetChoice(amendUserChoice);
                            if (modificationTarget == ModificationTarget.Exit)
                            {
                                amending = false;
                                amendQuestionsAndAnswers = false;
                                Console.Clear();
                                continue;
                            }
                            int countEnum = UIMethods.EnumLength(EnumChoice.ModificationOptions);
                            ModificationOptions modificationOptions = ModificationOptions.Add;

                            int questionToAmend = 0;

                            if (modificationTarget == ModificationTarget.AnswerList || modificationTarget == ModificationTarget.CorrectAnswerList)                   // if not questions than do this
                            {
                                questionToAmend = UIMethods.ShowAnswersListInfo(QuizmakerList, modificationTarget);
                            }

                            modificationOptions = UIMethods.ShowModificationOptionsInfo();
                           
                            switch (modificationTarget)
                            {
                                case ModificationTarget.Questions:                                                                      //questions

                                    if (modificationOptions == ModificationOptions.Exit)
                                    {
                                        Console.Clear();
                                        continue;
                                    }

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
                                        case ModificationOptions.Exit:
                                            Console.Clear();
                                            continue;
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
                                        case ModificationOptions.Exit:
                                            Console.Clear();
                                            continue;
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
                                        case ModificationOptions.Exit:
                                            Console.Clear();
                                            continue;
                                    }
                                    break;
                                case ModificationTarget.Exit:
                                    {
                                        Console.Clear();
                                        amending = false;
                                        amendQuestionsAndAnswers = false;
                                        continue;
                                    }
                            }
                            if (amending)
                            {
                                Console.WriteLine("Do you want to keep changing Question text, answers or correct answers ?");
                                amending = UIMethods.MakeDecisionYorN();
                                Console.Clear();
                            }
                        }
                        if (amendQuestionsAndAnswers)
                        {
                            Console.WriteLine("Would you like to continue managing questions and answers ?");
                            FileOperations.CreateXMLSerializeFile(QuizmakerList);                                           // create xmlSerialization
                            amendQuestionsAndAnswers = UIMethods.MakeDecisionYorN();
                            Console.Clear();
                        }
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




