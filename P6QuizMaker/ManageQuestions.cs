namespace P6QuizMaker
{
    internal class ManageQuestions
    {

        public static void Manage()
        {
            List<QuestionsAndAnswers> questionList = FileOperations.DeserializeFiles();

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
                    UIMethods.DisplayCorrectAnswerExists();
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


        /// <summary>
        /// This method modifies question object , add new question, remove existing question, amend question text
        /// </summary>
        /// <param name="modificationOptions"> (user)choice of option </param>
        /// <param name="questionList"> List with questions </param>
        /// <param name="questionToMakeChanges"> question reference to amend question Text </param>
        /// <param name="questionToAmend"> variable which question in list to make changes to </param>
        private static void ModifyQuestionsOptions(ModificationOptions modificationOptions, List<QuestionsAndAnswers> questionList, QuestionsAndAnswers questionToMakeChanges, int questionToAmend)
        {
            questionToAmend = GetQuestionIndexNotAddOption(modificationOptions,questionList,questionToAmend);

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                               //add
                    QuestionsAndAnswers question = CreateNewQuestion(questionList);
                    AddMultipleAnswerToList(question);
                    break;
                case ModificationOptions.Remove:                                                            //remove
                    questionList.RemoveAt(questionToAmend);
                    break;
                case ModificationOptions.Amend:                                                             // amend
                    UIMethods.ModifyQuestionText(questionToMakeChanges);
                    break;
            }
        }

        /// <summary>
        /// modify Answer List Options
        /// </summary>
        /// <param name="questionToMakeChanges"> Question object </param>
        /// <param name="modificationOptions"> Option choice </param>
        private static void ModifyAnswerListOptions(QuestionsAndAnswers questionToMakeChanges, ModificationOptions modificationOptions)
        {
            DisplayTextNotForAddToList(modificationOptions);

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                           // Add
                    AddMultipleAnswerToList(questionToMakeChanges);
                    break;
                case ModificationOptions.Remove:                                                        // Remove
                    RemoveAnswerFromList(questionToMakeChanges);
                    break;
                case ModificationOptions.Amend:                                                          // Amend
                    AmendEntryInAnswerList(questionToMakeChanges);
                    break;
            }
        }

        private static void DisplayTextNotForAddToList(ModificationOptions modificationOptions)
        {
            if (modificationOptions != ModificationOptions.Add)
            {
                UIMethods.DisplayTypeAnswerNumberToModify(modificationOptions);
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

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                       // Add
                    AddCorrectAnswer(questionToMakeChanges);
                    break;
                case ModificationOptions.Remove:                                                    // Remove
                    RemoveCorrectAnswerFromList(questionToMakeChanges);
                    break;
                case ModificationOptions.Amend:                                                     // Amend
                    AmendEntryInCorrectAnswerList(questionToMakeChanges);
                    break;
            }
        }

        private static void RemoveCorrectAnswerFromList(QuestionsAndAnswers questionToMakeChanges)
        {
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersListCount;
            int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
            questionToMakeChanges.CorrectAnswersList.RemoveAt(answerToRemove);
        }

        private static void AmendEntryInAnswerList(QuestionsAndAnswers questionToMakeChanges)
        {
            int answerCount = questionToMakeChanges.AnswersListCount;
            int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
            UIMethods.DisplayTextAskWhatToChange();
            questionToMakeChanges.AnswersList[answerToAmend] = UIMethods.GetUserInput();
        }
        private static void AmendEntryInCorrectAnswerList(QuestionsAndAnswers questionToMakeChanges)
        {
            UIMethods.DisplayTextAskWhatToChange();
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersListCount;
            int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
            questionToMakeChanges.CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(questionToMakeChanges.CorrectAnswersListCount) - 1;
        }

        private static void AddMultipleAnswerToList(QuestionsAndAnswers questionToMakeChanges)
        {
            bool addMoreAnswers = true;
            while (addMoreAnswers)
            {
                string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                questionToMakeChanges.AnswersList.Add(answerText);
                if (UIMethods.IsCorrectAnswer())
                {
                    int answerIndex = questionToMakeChanges.AnswersList.IndexOf(answerText);
                    questionToMakeChanges.CorrectAnswersList.Add(answerIndex);
                }
                addMoreAnswers = UIMethods.GetAdditionalAnswer();
            }
        }

        /// <summary>
        /// removes answer from answer List and removes correct answer if exists
        /// </summary>
        private static void RemoveAnswerFromList(QuestionsAndAnswers questionToMakeChanges)
        {
            int indexToRemoveAt = UIMethods.GetUserInputNum(questionToMakeChanges.AnswersListCount) - 1;
            questionToMakeChanges.AnswersList.RemoveAt(indexToRemoveAt);
            foreach (int answer in questionToMakeChanges.CorrectAnswersList)
            {
                if (answer == indexToRemoveAt)
                {
                    int answerIndex = questionToMakeChanges.CorrectAnswersList.IndexOf(answer);
                    questionToMakeChanges.CorrectAnswersList.RemoveAt(answerIndex);
                    break;
                }
            }
        }
        private static int GetQuestionIndexNotAddOption(ModificationOptions modificationOptions, List<QuestionsAndAnswers> questionList,int questionToAmend)
        {
            if (modificationOptions != ModificationOptions.Add)
            {
                UIMethods.ShowListOfQuestion(questionList);
                UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                questionToAmend = UIMethods.GetUserInputNum(questionList.Count) - 1;
            }
                return questionToAmend;
        }

    }

}






