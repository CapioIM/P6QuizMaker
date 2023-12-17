namespace P6QuizMaker
{
    internal class ManageQuestions
    {

        private static void AddCorrectAnswer(QuestionsAndAnswers question)
        {
            int answerNumber;
            bool CorrectAnswerDuplicateCheck = true;
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                answerNumber = UIMethods.DiplayGetNumberText(question);
                foreach (int correctAnswerNumber in question.CorrectAnswersList)
                {
                    if (correctAnswerNumber == (answerNumber - 1))
                    {
                        CorrectAnswerDuplicateCheck = false;
                    }
                }
                if (CorrectAnswerDuplicateCheck)
                {
                    question.CorrectAnswersList.Add(answerNumber - 1);
                }
                else
                {
                    Console.WriteLine("This answer is already in the list");
                }
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        private static QuestionsAndAnswers CreateNewQuestion(List<QuestionsAndAnswers> questionList)
        {
            QuestionsAndAnswers newQuestion = new QuestionsAndAnswers();
            questionList.Add(newQuestion);
            newQuestion.QuestionText = UIMethods.GetQuestionText();
            return newQuestion;
        }

        public static void Manage()
        {
            List<QuestionsAndAnswers> questionList = FileOperations.DeserializeTest();

            bool amending = true;
            while (amending)
            {
                UIMethods.DisplayOptionsTargetToModify();                                                                                   // print Target to modify 
                int amendUserChoice = UIMethods.GetUserInputNum(Enum.GetNames(typeof(ModificationTarget)).Length);

                ModificationTarget modificationTarget = UIMethods.ModificationTargetChoice(amendUserChoice);
                if (modificationTarget == ModificationTarget.Exit)
                {
                    UIMethods.ClearConcole();
                    return;
                }

                int questionToAmend = 0;

                if (modificationTarget == ModificationTarget.AnswerList || modificationTarget == ModificationTarget.CorrectAnswerList)                   // if not questions than do this
                {
                    questionToAmend = UIMethods.ShowAnswersListInfo(questionList, modificationTarget);
                }

                ModificationOptions modificationOptions = ModificationOptions.Add;

                if (modificationTarget != ModificationTarget.SaveChanges)
                {
                    modificationOptions = UIMethods.ShowModificationOptionsInfo();
                }

                if (modificationOptions == ModificationOptions.Exit)
                {
                    UIMethods.ClearConcole();
                    continue;
                }

                QuestionsAndAnswers questionBeingAmended = questionList[questionToAmend];
                switch (modificationTarget)
                {
                    case ModificationTarget.Questions:                                                                  //questions
                        ModifyQuestionsOptions(modificationOptions, questionList, questionBeingAmended, questionToAmend);
                        break;

                    case ModificationTarget.AnswerList:                                                             // Answer List
                        ModifyAnswerListOptions(questionBeingAmended, modificationOptions);
                        break;

                    case ModificationTarget.CorrectAnswerList:                                                  // Correct Answer List
                        ModifyCorrectAnswerListOptions(modificationOptions, questionBeingAmended);
                        break;
                    case ModificationTarget.SaveChanges:
                        {
                            FileOperations.CreateXMLSerializeFile(questionList);                           // create xmlSerialization file
                            continue;
                        }
                }
            }
        }


        /// <summary>
        /// This method modifies question object , add new question, remove existing question, amend question text
        /// </summary>
        /// <param name="modificationOptions"> (user)choice of option </param>
        /// <param name="questionList"> List with questions </param>
        /// <param name="questionToMakeChanges"> question reference to amend question Text </param>
        /// <param name="questionToAmend"> variable which question in list to make changes to </param>
        private static void ModifyQuestionsOptions(ModificationOptions modificationOptions, List<QuestionsAndAnswers> questionList, QuestionsAndAnswers questionToMakeChanges, int questionToAmend)
        {
            if (modificationOptions != ModificationOptions.Add)
            {
                UIMethods.ShowListOfQuestion(questionList);
                UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                questionToAmend = UIMethods.GetUserInputNum(questionList.Count) - 1;
            }

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                               //add
                    QuestionsAndAnswers question = CreateNewQuestion(questionList);
                    question.AddAnswerToList();
                    break;
                case ModificationOptions.Remove:                                                            //remove
                    questionList.RemoveAt(questionToAmend);
                    break;
                case ModificationOptions.Amend:                                                             // amend
                    UIMethods.ModifyQuestionText(questionToMakeChanges);
                    break;
                case ModificationOptions.Exit:                                                              // Exit
                    return;
            }
        }

        /// <summary>
        /// modify Answer List Options
        /// </summary>
        /// <param name="questionToMakeChanges"> Question object </param>
        /// <param name="modificationOptions"> Option choice </param>
        private static void ModifyAnswerListOptions(QuestionsAndAnswers questionToMakeChanges, ModificationOptions modificationOptions)
        {
            Console.WriteLine("Type number of answer you want to make changes to!");
            int answerCount = questionToMakeChanges.AnswersList.Count;
            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                           // Add
                    questionToMakeChanges.AddAnswerToList();
                    break;
                case ModificationOptions.Remove:                                                        // Remove
                    questionToMakeChanges.RemoveAnswerFromList();
                    break;
                case ModificationOptions.Amend:                                                          // Amend
                    int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
                    UIMethods.DisplayTextAskWhatToChange();
                    questionToMakeChanges.AnswersList[answerToAmend] = UIMethods.GetUserInput();
                    break;
                case ModificationOptions.Exit:                                                          // Exit
                    return;
            }
        }

        /// <summary>
        /// Modify Correct answer list
        /// </summary>
        /// <param name="questionToMakeChanges"> Question object </param>
        /// <param name="modificationOptions"> Option choice </param>
        private static void ModifyCorrectAnswerListOptions(ModificationOptions modificationOptions, QuestionsAndAnswers questionToMakeChanges)
        {

            UIMethods.DisplayPlayAnswerNumber();
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersList.Count;

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                       // Add
                    AddCorrectAnswer(questionToMakeChanges);
                    break;
                case ModificationOptions.Remove:                                                    // Remove
                    RemoveAnswer(questionToMakeChanges);
                    break;
                case ModificationOptions.Amend:                                                     // Amend
                    UIMethods.DisplayTextAskWhatToChange();
                    int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                    questionToMakeChanges.CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(questionToMakeChanges.CorrectAnswersList.Count) - 1;
                    break;
                case ModificationOptions.Exit:                                                      //Exit
                    return;
            }
        }

        private static void RemoveAnswer(QuestionsAndAnswers questionToMakeChanges)
        {
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersList.Count;
            int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
            questionToMakeChanges.CorrectAnswersList.RemoveAt(answerToRemove);
        }
    }
}





