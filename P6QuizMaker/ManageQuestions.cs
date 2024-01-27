using P6QuizMaker.Enums;

namespace P6QuizMaker
{
    internal class ManageQuestions
    {
        /// <summary>
        /// Method to Manage Object Data,Lists,New objects,Remove objects
        /// </summary>
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

                if (modificationTarget == ModificationTarget.AnswerList || modificationTarget == ModificationTarget.CorrectAnswerList)                   // if Answer List or Correct Answer List than do this
                {
                    questionToAmend = UIMethods.ShowAnswersListInfo(questionList, modificationTarget);
                }

                ModificationOption modificationOptions = ModificationOption.Add;

                if (modificationTarget != ModificationTarget.SaveChanges)
                {
                    modificationOptions = UIMethods.ShowModificationOptionsInfo();
                }

                if (modificationOptions == ModificationOption.Exit)
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

                    case ModificationTarget.AnswerList:                                                                  // Answer List
                        ModifyAnswerListOptions(questionBeingAmended, modificationOptions);
                        break;

                    case ModificationTarget.CorrectAnswerList:                                                         // Correct Answer List
                        ModifyCorrectAnswerListOptions(modificationOptions, questionBeingAmended);
                        break;
                    case ModificationTarget.SaveChanges:
                        {
                            FileOperations.CreateXMLSerializeFile(questionList);                                     // create xmlSerialization file
                            continue;
                        }
                }
            }
        }

        /// <summary>
        /// user input number(index of AnswersList) add to Correct Answers List if number is not in the list, ask if user wants to repeat
        /// </summary>
        /// <param name="question"> Provided object , which Correct answers list will be modified </param>
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

        /// <summary>
        /// bring new object to life and add to List of obejcts
        /// </summary>
        /// <param name="questionList"> List where object will be added to </param>
        /// <returns></returns>
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
        private static void ModifyQuestionsOptions(ModificationOption modificationOptions, List<QuestionsAndAnswers> questionList, QuestionsAndAnswers questionToMakeChanges, int questionToAmend)
        {
            questionToAmend = GetQuestionIndexNotAddOption(modificationOptions,questionList,questionToAmend);

            switch (modificationOptions)
            {
                case ModificationOption.Add:                                                               //add
                    QuestionsAndAnswers question = CreateNewQuestion(questionList);
                    AddMultipleAnswerToList(question);
                    break;
                case ModificationOption.Remove:                                                            //remove
                    questionList.RemoveAt(questionToAmend);
                    break;
                case ModificationOption.Amend:                                                             // amend
                    UIMethods.ModifyQuestionText(questionToMakeChanges);
                    break;
            }
        }

        /// <summary>
        /// modify Answer List Options
        /// </summary>
        /// <param name="questionToMakeChanges"> Question object </param>
        /// <param name="modificationOptions"> Option choice </param>
        private static void ModifyAnswerListOptions(QuestionsAndAnswers questionToMakeChanges, ModificationOption modificationOptions)
        {
            DisplayTextNotForAddToList(modificationOptions);

            switch (modificationOptions)
            {
                case ModificationOption.Add:                                                           // Add
                    AddMultipleAnswerToList(questionToMakeChanges);
                    break;
                case ModificationOption.Remove:                                                        // Remove
                    RemoveAnswerFromList(questionToMakeChanges);
                    break;
                case ModificationOption.Amend:                                                          // Amend
                    AmendEntryInAnswerList(questionToMakeChanges);
                    break;
            }
        }
        /// <summary>
        /// Display text as long as != ModificationOptions.Add
        /// </summary>
        /// <param name="modificationOptions"></param>
        private static void DisplayTextNotForAddToList(ModificationOption modificationOptions)
        {
            if (modificationOptions != ModificationOption.Add)
            {
                UIMethods.DisplayTypeAnswerNumberToModify(modificationOptions);
            }
        }

        /// <summary>
        /// Modify Correct answer list
        /// </summary>
        /// <param name="questionToMakeChanges"> Question object </param>
        /// <param name="modificationOptions"> Option choice </param>
        private static void ModifyCorrectAnswerListOptions(ModificationOption modificationOptions, QuestionsAndAnswers questionToMakeChanges)
        {

            UIMethods.DisplayPlayAnswerNumber();

            switch (modificationOptions)
            {
                case ModificationOption.Add:                                                       // Add
                    AddCorrectAnswer(questionToMakeChanges);
                    break;
                case ModificationOption.Remove:                                                    // Remove
                    RemoveCorrectAnswerFromList(questionToMakeChanges);
                    break;
                case ModificationOption.Amend:                                                     // Amend
                    AmendEntryInCorrectAnswerList(questionToMakeChanges);
                    break;
            }
        }
        /// <summary>
        /// Removes correct answer from list
        /// </summary>
        /// <param name="questionToMakeChanges"> provide object </param>
        private static void RemoveCorrectAnswerFromList(QuestionsAndAnswers questionToMakeChanges)
        {
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersListCount;
            int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
            questionToMakeChanges.CorrectAnswersList.RemoveAt(answerToRemove);
        }
        /// <summary>
        /// user choose index in list to amend, user input replaces data at index in list
        /// </summary>
        /// <param name="questionToMakeChanges"> object which list to modify </param>
        private static void AmendEntryInAnswerList(QuestionsAndAnswers questionToMakeChanges)
        {
            int answerCount = questionToMakeChanges.AnswersListCount;
            int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
            UIMethods.DisplayTextAskWhatToChange();
            questionToMakeChanges.AnswersList[answerToAmend] = UIMethods.GetUserInput();
        }
        /// <summary>
        /// Display Text, user choose index in CorrectAnswerList to amend, user input replaces index in list
        /// </summary>
        /// <param name="questionToMakeChanges">  object which list to modify  </param>
        private static void AmendEntryInCorrectAnswerList(QuestionsAndAnswers questionToMakeChanges)
        {
            UIMethods.DisplayTextAskWhatToChange();
            int correctAnswerCount = questionToMakeChanges.CorrectAnswersListCount;
            int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
            questionToMakeChanges.CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(questionToMakeChanges.CorrectAnswersListCount) - 1;
        }
        /// <summary>
        /// Add user input to AnswerList , ask user if index of added input can be added to Correct Answer List, ask user wants to enter additional input to AnswerList
        /// </summary>
        /// <param name="questionToMakeChanges"></param>
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

        /// <summary>
        /// Display List of questions for all enum options apart from Add
        /// </summary>
        /// <param name="modificationOptions"> enum option </param>
        /// <param name="questionList"> list of Question objects </param>
        /// <param name="questionToAmend"> List index int var </param>
        /// <returns> returns index in list , index is changed if enum != ModificationOptions.Add </returns>
        private static int GetQuestionIndexNotAddOption(ModificationOption modificationOptions, List<QuestionsAndAnswers> questionList,int questionToAmend)
        {
            if (modificationOptions != ModificationOption.Add)
            {
                UIMethods.ShowListOfQuestion(questionList);
                UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                questionToAmend = UIMethods.GetUserInputNum(questionList.Count) - 1;
            }
                return questionToAmend;
        }
    }
}






