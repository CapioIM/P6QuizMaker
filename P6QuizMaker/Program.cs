namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();
            Texts.GetQuestion();
            QuizQuestions.StoreQuestions(UIMethods.GetUserInput());
        }
    }
}