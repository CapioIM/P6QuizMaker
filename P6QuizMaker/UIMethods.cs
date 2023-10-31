namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void WelcomeText()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                " You will be asked to type questions and answers to these questions.\n" +
                " After you will enter answers program will ask you to pick if answer is correct.\n" +
                " And lastly program will bring random question with answers.\n");
        }

        public static string GetUserInput()
        {
            string textMessage = Console.ReadLine();
            return textMessage;
        }
        public static void DisplayAskToTypeQuestionText()
        {
            Console.Write("Please write question for Quiz ! : ");
        }

        public static bool MakeDecision()
        {
            PrintPressYesOrNo();
            return (char.ToLower(Console.ReadKey().KeyChar) != 'n');
        }

        public static void PrintPressYesOrNo()
        {
            Console.WriteLine("Press Y if want to continue or N to stop! : ");
        }

        public static void DisplayAddQuestionText()
        {
            Console.WriteLine("Would you like to add another Question ?");
        }
        public static void DisplayAddAnswerText()
        {
            Console.WriteLine("Would you like to add another Answer ?");
        }
        public static void DisplayTypeAnswerText()
        {
            Console.Write("Type answer : ");
        }
        public static void DisplayIsCorrectAnswerText()
        {
            Console.WriteLine("Is this correct answer ? : ");

        }
        /// <summary>
        /// type text which is added to Answers List
        /// </summary>
        /// <param name="answersList"> List name where to add text </param>
        public static void AddTextToAnswerList(List<string> answersList)
        {
            answersList.Add(Console.ReadLine());
        }

    }
}
