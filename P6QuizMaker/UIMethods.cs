namespace P6QuizMaker
{
    internal class UIMethods
    {
        public static void WelcomeText()
        {
            Console.WriteLine("                 Welcome to Quiz Maker Program !\n" +
                "You will be asked to type questions and answers to these questions.\n" +
                "After you will enter answers program will ask you to pick if answer is correct.\n" +
                "And lastly program will bring random question with answers.\n");
        }

        public static string GetUserInput()
        {
            string textMessage = Console.ReadLine();
            return textMessage;
        }
    }
}
