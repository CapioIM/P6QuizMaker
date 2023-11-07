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

        public static void WelcomeAddQuestionsChoice()
        {
            Console.WriteLine("" +
                "Type Question to add to list of Questions!");
        }

        public static string GetUserInput()
        {
            string textMessage = Console.ReadLine();
            return textMessage;
        }
        public static string DisplayAskToTypeQuestionText()
        {
            Console.Write("Please write question for QuizMaker ! : ");
            var text = GetUserInput();
            return text;
        }

        public static bool MakeDecisionYorN()
        {
            PrintPressYesOrNo();
            var testString = Console.ReadLine().ToLower();
            var testChar = testString.ToCharArray();
            return (testChar[0] != 'n');
        }

        public static void PrintPressYesOrNo()
        {
            Console.Write("Press Y - if Yes or N - if No! : ");
        }

        public static bool GetAdditionalQuestions()
        {
            Console.WriteLine("Would you like to add another Question ?");
            bool additionalQuestion = MakeDecisionYorN();
            return additionalQuestion;
        }
        public static bool GetAdditionalAnswer()
        {
            Console.WriteLine("Would you like to add additional Answer ?");
            bool addAnswer = MakeDecisionYorN();
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
            bool isAdditionalAnswer = MakeDecisionYorN();
            return isAdditionalAnswer;
        }
    }
}
