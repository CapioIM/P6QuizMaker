namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();
            Texts.GetQuestion();
            ObjectTest newObject = new ObjectTest();
            newObject.Question = UIMethods.GetUserInput();

        }
    }
}