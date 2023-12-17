namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void DisplayPlayAnswerNumber()
        {
            Console.WriteLine("Please type number associated with answer.");
        }

        public static void DisplayPlayAnotherQuestionText()
        {
            Console.WriteLine("Would you like to play another question ?");
        }

        public static void WelcomeText()
        {
            ClearConcole();
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                " You can add questions with answers or you can play Quizmaker and answer questions.\n");
        }

        public static void DisplayGameDiscription()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Game !\n" +
                "You are asked question and you need to press number to pick correct answer!");
        }

        public static void DisplayGameModeChoice()
        {
            Console.WriteLine(
                "Press 1 to Manage Questions\n" +
                "Press 2 to Play Quizmaker\n" +
                "Press 3 to Exit Programm"
                );
        }

        /// <summary>
        /// Choice of enum to provide amount of items in enum
        /// </summary>
        /// <param name="enumChoice"></param>
        /// <returns> int of amount of items in enum </returns>
        public static int EnumLength(EnumChoice enumChoice)
        {
            switch (enumChoice)
            {
                case EnumChoice.ModificationOptions:
                    return Enum.GetNames(typeof(ModificationOptions)).Length;
                case EnumChoice.ModificationTarget:
                    return Enum.GetNames(typeof(ModificationTarget)).Length;
                default:
                    {
                        return 0;
                    }
            }
        }
        public static int GetUserInputNum(int enumChoice)
        {
            int choiceNumber = 0;
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out choiceNumber);
                if (convertToInt && choiceNumber > 0 && choiceNumber <= enumChoice)
                {
                    return choiceNumber;
                }
                if (!convertToInt || (convertToInt && (choiceNumber <= 0 || choiceNumber > enumChoice)))
                {
                    Console.WriteLine($"Please enter number less than {enumChoice + 1}!");
                    convertToInt = false;
                }
            }
            return choiceNumber;
        }


        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
        public static string GetQuestionText()
        {
            Console.Write("Please write question for QuizMaker ! : ");
            return GetUserInput();
        }

        public static bool MakeDecisionYorN()
        {
            DisplayTextPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        public static void DisplayTextPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        public static bool GetAdditionalAnswer()
        {
            Console.Write("Would you like to add additional Answer ? : ");
            return MakeDecisionYorN();
        }

        public static int DiplayGetNumberText(QuestionsAndAnswers quizmaker)
        {
            Console.Write("Type answer Number : ");
            return GetUserInputNum(quizmaker.AnswersListCount);
        }

        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer to be added: ");
            return GetUserInput();
        }

        public static void DisplayTextAskWhatToChange()
        {
            Console.WriteLine("What this answer would you like to change to ?");
        }

        /// <summary>
        /// is this answer Correct ?
        /// </summary>
        /// <returns> bool </returns>
        public static bool IsCorrectAnswer()
        {
            Console.Write("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }


        /// <summary>
        /// WriteLine List with object Question text
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<QuestionsAndAnswers> list)
        {
            foreach (QuestionsAndAnswers question in list)
            {
                Console.WriteLine($"{list.IndexOf(question) + 1}" + " " + question.QuestionText);
            }
        }

        public static void DisplayTextAddRemoveAmend()
        {
            Console.WriteLine(
                                 "Press 1 to Amend  \n" +
                                 "Press 2 to Remove \n" +
                                 "Press 3 to Add \n" +
                                 "Press 4 to Return to previous menu");
        }
        public static void ModifyQuestionText(QuestionsAndAnswers question)
        {
            Console.WriteLine($"Question you are changing is : {question.QuestionText}");
            question.QuestionText = UIMethods.GetQuestionText();
        }

        public static void DisplayTextQuestionToRemoveOrAmend(ModificationOptions modifyOrRemove)
        {
            Console.WriteLine($"Type number associated with question to {modifyOrRemove}!");
        }

        public static ModificationTarget ModificationTargetChoice(int modificationTargetChoice)
        {
            switch (modificationTargetChoice)
            {
                case 1:
                    return ModificationTarget.Questions;
                case 2:
                    return ModificationTarget.AnswerList;
                case 3:
                    return ModificationTarget.CorrectAnswerList;
                case 5:
                    return ModificationTarget.SaveChanges;
                default:
                    return ModificationTarget.Exit;
            }
        }

        public static ModificationOptions ModificationOptionChoice(int modificationOptionChoice)
        {
            switch (modificationOptionChoice)
            {
                case 1:
                    return ModificationOptions.Amend;
                case 2:
                    return ModificationOptions.Remove;
                case 3:
                    return ModificationOptions.Add;
                default:
                    return ModificationOptions.Exit;
            }
        }

        public static GameMode GameModeChoice(int manageOrPlay)
        {
            switch (manageOrPlay)
            {
                case 0:
                    return GameMode.Manage;
                case 1:
                    return GameMode.Play;
                default:
                    return GameMode.Exit;
            }
        }

        public static int ShowAnswersListInfo(List<QuestionsAndAnswers> QuizmakerList, ModificationTarget modificationTarget)
        {
            ShowListOfQuestion(QuizmakerList);
            Console.WriteLine($"Answers for which question would you like to modify?");
            int questionToAmend = GetUserInputNum(QuizmakerList.Count) - 1;
            UIMethods.DisplayAnswers(QuizmakerList[questionToAmend]);

            if (IsCorrectAnswerList(modificationTarget))
            {
                UIMethods.DisplayCorrectAnswers(QuizmakerList[questionToAmend]);
            }

            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
            return questionToAmend;
        }
        public static ModificationOptions ShowModificationOptionsInfo()
        {
            int countEnum = UIMethods.EnumLength(EnumChoice.ModificationOptions);
            UIMethods.DisplayTextAddRemoveAmend();
            int addRemoveAmendUserChoice = UIMethods.GetUserInputNum(countEnum);
            ModificationOptions modificationOptions = UIMethods.ModificationOptionChoice(addRemoveAmendUserChoice);
            return modificationOptions;
        }

        public static void DisplayOptionsTargetToModify()
        {
            Console.WriteLine("What would you like to amend:\n" +
                               " 1 - Questions \n" +
                               " 2 - Answers\n" +
                               " 3 - Correct Answers\n" +
                               " 4 - Return to game mode choice\n" +
                               " 5 - Save Changes");
        }

        public static void DisplayChangeGameMode()
        {
            Console.WriteLine("Would you like to return to game menu ?");
        }
        public static void ClearConcole()
        {
            Console.Clear();
        }

        private static bool IsCorrectAnswerList(ModificationTarget modificationTarget)
        {
            if (modificationTarget == ModificationTarget.CorrectAnswerList)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public static void DisplayAnswers(QuestionsAndAnswers questionData)
        {
            Console.WriteLine("Here's list of Answers: ");
            foreach (string answer in questionData.AnswersList)
            {
                Console.WriteLine($"{questionData.AnswersList.IndexOf(answer) + 1}" + " " + answer);
            }
        }

        /// <summary>
        /// takes list of object and display whole list
        /// </summary>
        public static void DisplayCorrectAnswers(QuestionsAndAnswers questionData)
        {
            Console.WriteLine("Here's list of Correct Answers");
            foreach (int answer in questionData.CorrectAnswersList)
            {
                Console.WriteLine($"Answer Nr: {questionData.CorrectAnswersList.IndexOf(answer) + 1} Description of answer: {questionData.AnswersList[answer]} .");
            }
        }


    }
}


