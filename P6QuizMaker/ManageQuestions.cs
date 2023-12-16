namespace P6QuizMaker
{
    internal class ManageQuestions
    {
        /// <summary>
        /// add answer to specified object
        /// </summary>
        /// <param name="quizmaker"> object name, if in list where to find specific object </param>
        public static void AddAnswersToQuestion(QuestionsAndAnswers quizmaker)
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

        private static void AddCorrectAnswer(QuestionsAndAnswers quizmaker)
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
        private static void AddCorrectAnswersToList(string answerText, QuestionsAndAnswers quizmaker)
        {
            if (UIMethods.IsCorrectAnswer())
            {
                quizmaker.CorrectAnswersList.Add(quizmaker.AnswersList.IndexOf(answerText));
            }
        }

        private static QuestionsAndAnswers AddNewQuestion(List<QuestionsAndAnswers> QuizmakerList)
        {
            QuestionsAndAnswers quizmakerQuestion = new QuestionsAndAnswers();
            QuizmakerList.Add(quizmakerQuestion);
            return quizmakerQuestion;
        }

        public static void Manage()
        {
            List<QuestionsAndAnswers> QuizmakerList = FileOperations.DeserializeTest();

            bool amending = true;
            while (amending)
            {
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

                QuestionsAndAnswers questionReference = QuizmakerList[questionToAmend];
                switch (modificationTarget)
                {
                    case ModificationTarget.Questions:                                                                  //questions
                        ModifyQuestionsOptions(modificationOptions, QuizmakerList, questionReference, questionToAmend);
                        break;

                    case ModificationTarget.AnswerList:                                                             // Answer List
                        ModifyAnswerListOptions(questionReference, modificationOptions);
                        break;

                    case ModificationTarget.CorrectAnswerList:                                                  // Correct Answer List
                        ModifyCorrectAnswerListOptions(modificationOptions, questionReference);
                        break;
                    case ModificationTarget.SaveChanges:
                        {
                            FileOperations.CreateXMLSerializeFile(QuizmakerList);                           // create xmlSerialization file
                            continue;
                        }
                    case ModificationTarget.Exit:
                        {
                            continue;
                        }
                }
            }
        }


        private static void RemoveAnswerFromAnswerList(int answerNumberToRemove, QuestionsAndAnswers question)
        {
            question.AnswersList.RemoveAt(answerNumberToRemove);
            foreach (int answer in question.CorrectAnswersList)
            {
                if (answer == answerNumberToRemove)
                {
                    question.CorrectAnswersList.RemoveAt(question.CorrectAnswersList.IndexOf(answer));
                    break;
                }
            }
        }

        private static void ModifyQuestionsOptions(ModificationOptions modificationOptions, List<QuestionsAndAnswers> QuizmakerList, QuestionsAndAnswers questionReference, int questionToAmend)
        {

            if (modificationOptions != ModificationOptions.Add)
            {
                UIMethods.ShowListOfQuestion(QuizmakerList);
                UIMethods.DisplayTextQuestionToRemoveOrAmend(modificationOptions);
                questionToAmend = UIMethods.GetUserInputNum(QuizmakerList.Count) - 1;
            }

            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                               //add
                    QuestionsAndAnswers question = AddNewQuestion(QuizmakerList);
                    question.QuestionText = UIMethods.GetQuestionText();
                    AddAnswersToQuestion(question);
                    break;
                case ModificationOptions.Remove:                                                            //remove
                    QuizmakerList.RemoveAt(questionToAmend);
                    break;
                case ModificationOptions.Amend:                                                             // amend
                    UIMethods.ModifyQuestionText(questionReference);
                    break;
                case ModificationOptions.Exit:                                                              // Exit
                    return;
            }
        }

        private static void ModifyAnswerListOptions(QuestionsAndAnswers questionReference, ModificationOptions modificationOptions)
        {
            Console.WriteLine("Type number of answer you want to make changes to!");
            int answerCount = questionReference.AnswersList.Count;
            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                           // Add
                    questionReference.AddAnswerToList();
                    break;
                case ModificationOptions.Remove:                                                        // Remove
                    int answerToRemove = UIMethods.GetUserInputNum(answerCount) - 1;
                    RemoveAnswerFromAnswerList(answerToRemove, questionReference);
                    break;
                case ModificationOptions.Amend:                                                          // Amend
                    int answerToAmend = UIMethods.GetUserInputNum(answerCount) - 1;
                    UIMethods.DisplayTextAskWhatToChange();
                    questionReference.AnswersList[answerToAmend] = UIMethods.GetUserInput();
                    break;
                case ModificationOptions.Exit:                                                          // Exit
                    return;
            }
        }

        private static void ModifyCorrectAnswerListOptions(ModificationOptions modificationOptions, QuestionsAndAnswers questionReference)
        {
            UIMethods.DisplayPlayAnswerNumber();
            int correctAnswerCount = questionReference.CorrectAnswersList.Count;
  
            switch (modificationOptions)
            {
                case ModificationOptions.Add:                                                       // Add
                AddCorrectAnswer(questionReference);
                break;
            case ModificationOptions.Remove:                                                    // Remove
                    int answerToRemove = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                    questionReference.CorrectAnswersList.RemoveAt(answerToRemove);
                break;
            case ModificationOptions.Amend:                                                     // Amend
                UIMethods.DisplayTextAskWhatToChange();
                int answerToAmend = UIMethods.GetUserInputNum(correctAnswerCount) - 1;
                questionReference.CorrectAnswersList[answerToAmend] = UIMethods.GetUserInputNum(questionReference.CorrectAnswersList.Count) - 1;
                break;
            case ModificationOptions.Exit:                                                      //Exit
                return;
            }
        }

    }
}





