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
            if (char.ToLower(Console.ReadKey().KeyChar) != 'n')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PrintPressYesOrNo()
        {
            Console.WriteLine("Press Y if want to continue or N to stop! : ");
        }

        public static void DisplayAddQuestionText()
        {
            Console.WriteLine("Would you like to add another Question ?\n");
        }
        public static void DisplayAddAnswerText()
        {
            Console.WriteLine("Would you like to add another Answer ?\n");
        }
        public static void DisplayTypeAnswerText()
        {
            Console.Write("Type answer : ");
        }
        public static void DisplayIsCorrectAnswerText()
        {
            Console.WriteLine("Is this correct answer ? : ");

        }


    }
}
