namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void DisplayAddNumberText()
        {
            Console.WriteLine("Please type number associated with answer");
        }

        public static void DisplayPlayAnotherQuestionText()
        {
            Console.WriteLine("Would you like to play another question ?");
        }

    /// <summary>
    /// CW display questions and answers text from object in a list at index of randomQuesitonIndex
    /// </summary>
    /// <param name="QuizmakerList"> List with object Question </param>
    /// <param name="randomQuestionIndex"> random generated number variable </param>
    public static void DisplayQuestionAndAnswersToPlayer(List<Question> QuizmakerList, int randomQuestionIndex)
        {
            Console.WriteLine($"Please answer this Question: {QuizmakerList[randomQuestionIndex].QuestionText}");
            foreach (string answers in QuizmakerList[randomQuestionIndex].AnswersList)
            {
                Console.Write($"{QuizmakerList[randomQuestionIndex].AnswersList.IndexOf(answers) + 1}" + "-");
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
                "Press 1 to manage Questions\n" +
                "Press 2 to Play Quizmaker"
                );
        }

        /// <summary>
        /// Asks user to enter integer, untill number is entered
        /// </summary>
        /// <returns> user entered integer </returns>
        public static int GetUserInputNum()
        {
            int choiceNumber;
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
            return 0; //not all code paths return a value
        }


        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
        public static string DisplayAskToTypeQuestionText()
        {
            Console.Write("Please write question for QuizMaker ! : ");
            return GetUserInput();
        }

        public static bool MakeDecisionYorN()
        {
            PrintPressYesOrNo();
            string answer = Console.ReadLine().ToLower();
            char[] firstChar = answer.ToCharArray();
            return (firstChar[0] != 'n');
        }

        public static void PrintPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        public static bool GetAdditionalQuestions()
        {
            Console.WriteLine("Would you like to add more Questions ?");
            return MakeDecisionYorN();
        }
        public static bool GetAdditionalAnswer()
        {
            Console.Write("Would you like to add additional Answer ? : ");
            return MakeDecisionYorN();
        }
        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer : ");
            return GetUserInput();
        }
        public static bool IsCorrectAnswer()
        {
            Console.WriteLine("Is this correct answer ? : ");
            return MakeDecisionYorN();
        }
    }
}
