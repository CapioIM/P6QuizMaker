namespace P6QuizMaker
{
    internal class ManageQuestions
    {
        /// <summary>
        /// add answer to specified object
        /// </summary>
        /// <param name="quizmaker"> object name, if in list where to find specific object </param>
        public static void AddAnswersToQuestion(Question quizmaker)
        {
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                quizmaker.AnswersList.Add(answerText);
                AddCorrectAnswersToList(answerText, quizmaker);
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        private static void AddCorrectAnswer(Question quizmaker)
        {
            int answerNumber;
            bool CorrectAnswerDuplicateCheck = true;
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                answerNumber = UIMethods.DiplayGetNumberText(quizmaker);
                foreach (int correctAnswerNumber in quizmaker.CorrectAnswersList)
                {
                    if (correctAnswerNumber == (answerNumber - 1))
                    {
                        CorrectAnswerDuplicateCheck = false;
                    }
                }
                if (CorrectAnswerDuplicateCheck)
                {
                    quizmaker.CorrectAnswersList.Add(answerNumber - 1);
                }
                else
                {
                    Console.WriteLine("This answer is already in the list");
                }
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        /// <summary>
        /// if true adds index of matching string in AnswersList
        /// </summary>
        /// <param name="answerText">input string of Answer</param>
        /// <param name="quizmaker">Object variable name</param>
        private static void AddCorrectAnswersToList(string answerText, Question quizmaker)
        {
            if (UIMethods.IsCorrectAnswer())
            {
                quizmaker.CorrectAnswersList.Add(quizmaker.AnswersList.IndexOf(answerText));
            }
        }

        private static Question AddNewQuestion(List<Question> QuizmakerList)
        {
            Question quizmakerQuestion = new Question();
            QuizmakerList.Add(quizmakerQuestion);
            return quizmakerQuestion;
        }

        public static void Manage()
        {
            List<Question> QuizmakerList = FileOperations.Deserialize();

            bool amending = true;
            while (amending)
            {
                Console.Clear();                                                                                                        // loop start
                UIMethods.WelcomeText();                                                                                                   // welcome text                 
                UIMethods.DisplayOptionsTargetToModify();                                                                                   // print Target to modify 
                int amendUserChoice = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ModificationTarget)).Length);

                ModificationTarget modificationTarget = UIMethods.ModificationTargetChoice(amendUserChoice);
                if (modificationTarget == ModificationTarget.Exit)
                {
                    return;
                }

                int questionToAmend = 0;

                if (modificationTarget == ModificationTarget.AnswerList || modificationTarget == ModificationTarget.CorrectAnswerList)                   // if not questions than do this
                {
                    questionToAmend = UIMethods.ShowAnswersListInfo(QuizmakerList, modificationTarget);
                }

                ModificationOptions modificationOptions = ModificationOptions.Add;

                if (modificationTarget != ModificationTarget.SaveChanges)
                {
                    modificationOptions = UIMethods.ShowModificationOptionsInfo();
                }

                if (modificationOptions == ModificationOptions.Exit)
                {
                    continue;
                }

                switch (modificationTarget)
                {
                    case ModificationTarget.Questions:                                                                  //questions

                        if (modificationOptions != ModificationOptions.Add)
                        {
                            UIMethods.ShowListOfQuestion(QuizmakerList);
                            UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                            questionToAmend = UIMethods.GetUserInputNum(QuizmakerList.Count) - 1;
                        }

                        switch (modificationOptions)
                        {
                            case ModificationOptions.Add:                                                               //add
                                var question = AddNewQuestion(QuizmakerList);
                                question.QuestionText = UIMethods.GetQuestionText();
                                AddAnswersToQuestion(question);
                                break;
                            case ModificationOptions.Remove:                                                            //remove
                                QuizmakerList.RemoveAt(questionToAmend);
                                break;
                            case ModificationOptions.Amend:                                                             // amend
                                UIMethods.ModifyQuestionText(QuizmakerList[questionToAmend]);
                                break;
                            case ModificationOptions.Exit:                                                              // Exit
                                continue;
                        }
                        break;

                    case ModificationTarget.AnswerList:                                                             // Answer List
                        Console.WriteLine("Type number of answer you want to make changes to!");
                        int answerCount = QuizmakerList[questionToAmend].AnswersList.Count;
                        switch (modificationOptions)
                        {
                            case ModificationOptions.Add:                                                           // Add
                                AddAnswersToQuestion(QuizmakerList[questionToAmend]);
                                break;
                            case ModificationOptions.Remove:                                                        // Remove
                                int answerToRemove = UIMethods.GetUserInputNum(answerCount) - 1;
                                RemoveAnswerFromAnswerList(answerToRemove, QuizmakerList[questionToAmend]);
                                break;
                            case ModificationOptions.Amend:                                                          // Amend
                                int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
                                UIMethods.DisplayTextAskWhatToChange();
                                QuizmakerList[questionToAmend].AnswersList[answerToAmend] = UIMethods.GetUserInput();
                                break;
                            case ModificationOptions.Exit:                                                          // Exit
                                continue;
                        }
                        break;

                    case ModificationTarget.CorrectAnswerList:                                                  // Correct Answer List
                        UIMethods.DisplayPlayAnswerNumber();
                        int correctAnswerCount = QuizmakerList[questionToAmend].CorrectAnswersList.Count;
                        switch (modificationOptions)
                        {
                            case ModificationOptions.Add:                                                       // Add
                                AddCorrectAnswer(QuizmakerList[questionToAmend]);
                                break;
                            case ModificationOptions.Remove:                                                    // Remove
                                int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                                QuizmakerList[questionToAmend].CorrectAnswersList.RemoveAt(answerToRemove);
                                break;
                            case ModificationOptions.Amend:                                                     // Amend
                                UIMethods.DisplayTextAskWhatToChange();
                                int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                                QuizmakerList[questionToAmend].CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(QuizmakerList[questionToAmend].CorrectAnswersList.Count) - 1;
                                break;
                            case ModificationOptions.Exit:                                                      //Exit
                                continue;
                        }
                        break;
                    case ModificationTarget.SaveChanges:
                        {
                            FileOperations.CreateXMLSerializeFile(QuizmakerList);                                           // create xmlSerialization
                            continue;
                        }
                    case ModificationTarget.Exit:
                        {
                            continue;
                        }
                }
            }
        }


        private static void RemoveAnswerFromAnswerList(int answerNumberToRemove, Question quizmaker)
        {
            quizmaker.AnswersList.RemoveAt(answerNumberToRemove);
            foreach (int answer in quizmaker.CorrectAnswersList)
            {
                if (answer == answerNumberToRemove)
                {
                    quizmaker.CorrectAnswersList.RemoveAt(quizmaker.CorrectAnswersList.IndexOf(answer));
                    break;
                }
            }
        }

    }
}





