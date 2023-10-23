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
        public static void PrintAskToGetQuestionForQuiz()
        {
            Console.WriteLine(" Please write question for Quiz !");
        }

        public static bool MakeDecision()
        {
            if (char.ToLower(Console.ReadKey().KeyChar) != 'n')
            {
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.WriteLine();
                return false;
            }
        }

        public static void PrintPressYesOrNo()
        {
            Console.WriteLine(" Press Y if want to continue or N to stop! ");
        }

        public static void PrintAddQuestion()
        {
            Console.WriteLine(" Would you like to add another Question ?\n");
        }
        public static void PrintAddAnswer()
        {
            Console.WriteLine(" Would you like to add another Answer ?\n");
        }
    }
}
