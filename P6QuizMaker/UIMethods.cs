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
            return (Console.ReadLine().ToLower() != "n");
        }

        public static void PrintPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        public static bool GetAdditionalQuestions()
        {
            Console.WriteLine("Would you like to add another Question ?");
            bool additionalQuestion = MakeDecision();
            return additionalQuestion;
        }
        public static bool GetAdditionalAnswer()
        {
            Console.WriteLine("Would you like to add additional Answer ?");
            bool addAnswer = MakeDecision();
            return addAnswer;
        }
        public static string GetAndDisplayTypeAnswerText()
        {
            Console.Write("Type answer : ");
            string text = GetUserInput();
            return text;
        }
        public static bool IsCorrectAnswer()
        {
            Console.WriteLine("Is this correct answer ? : ");
            bool isAdditionalAnswer = MakeDecision();
            return isAdditionalAnswer;
        }
    }
}
