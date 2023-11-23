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

        /// <summary>
        /// CW display questions and answers text from object in a list at index of randomQuesitonIndex
        /// </summary>
        /// <param name="QuizmakerList"> List with object Question </param>
        /// <param name="QuestionIndex"> random generated number variable </param>
        public static void DisplayQuestionAndAnswersToPlayer(List<Question> QuizmakerList, int QuestionIndex)
        {
            Console.WriteLine($"Please answer this Question: {QuizmakerList[QuestionIndex].QuestionText}");
            foreach (string answers in QuizmakerList[QuestionIndex].AnswersList)
            {
                Console.Write($"{QuizmakerList[QuestionIndex].AnswersList.IndexOf(answers) + 1}" + "-");
                Console.WriteLine(answers);
            }
        }
        public static void WelcomeText()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                " You can add questions with answers or you can play Quizmaker and answer questions.\n");
        }

        public static void DisplayChoiceManagePlay()
        {
            Console.WriteLine(
                "Press 1 to Manage Questions\n" +
                "Press 2 to Play Quizmaker"
                );
        }

        /// <summary>
        /// Asks user to enter integer, untill number is entered
        /// </summary>
        /// <returns> user entered integer </returns>
        public static int GetUserInputNum()
        {
            int choiceNumber = 0;
            bool convertToInt = false;
            while (!convertToInt)
            {
                convertToInt = int.TryParse(Console.ReadLine(), out choiceNumber);
                if (convertToInt)
                {
                    return choiceNumber;
                }
                else
                {
                    Console.WriteLine("Please enter Number !");
                }
            }
            return choiceNumber; //not all code paths return a value
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

        public static int DiplayGetNumberText(Question quizmaker)
        {
            Console.Write("Type answer Number : ");
            return GetUserInputNum(quizmaker.AnswersList.Count);
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

        public static bool IsCorrectAnswer()
        {
            Console.Write("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }


        /// <summary>
        /// WriteLine List with object Question text
        /// </summary>
        /// <param name="list"> list with/of objects </param>
        public static void ShowListOfQuestion(List<Question> list)
        {
            foreach (Question question in list)
            {
                Console.WriteLine($"{list.IndexOf(question) + 1}" + " " + question.QuestionText);
            }
        }

        public static void ShowListOfAnswers(Question quizmaker, ModificationTarget amendChoice)
        {
            if (amendChoice == ModificationTarget.AnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in quizmaker.AnswersList)
                {
                    Console.WriteLine($"{quizmaker.AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }
            }
            if (amendChoice == ModificationTarget.CorrectAnswerList)
            {
                Console.WriteLine("Here's list of Answers: ");
                foreach (string answer in quizmaker.AnswersList)
                {
                    Console.WriteLine($"{quizmaker.AnswersList.IndexOf(answer) + 1}" + " " + answer);
                }

                Console.WriteLine("Here's list of Correct Answers");
                foreach (int answer in quizmaker.CorrectAnswersList)
                {
                    Console.WriteLine($"{quizmaker.CorrectAnswersList.IndexOf(answer) + 1}" + " " + $"{quizmaker.AnswersList[answer]}");
                }
            }
        }

        public static void DisplayTextAddRemoveAmend()
        {
            Console.WriteLine(
                                 "Press 1 to Amend  \n" +
                                 "Press 2 to Remove \n" +
                                 "Press 3 to Add ");
        }
        public static void ModifyQuestionText(Question question)
        {
            Console.WriteLine($"Question you are changing is : {question.QuestionText}");
            question.QuestionText = UIMethods.GetQuestionText();
        }

        public static void DisplayTextQuestionToRemoveOrAmend(ModificationOptions modifyOrRemove)
        {
            Console.WriteLine($"Type number associated with question to {modifyOrRemove.ToString()}!");
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
            }
            return 0;
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
            }
            return 0;
        }

    }
}


