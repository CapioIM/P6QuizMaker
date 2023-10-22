using System.Security.Cryptography.X509Certificates;

namespace P6QuizMaker
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string testQuestion = "What Color is sky ? ";               //Lazy Test things
            List<string> testAnswerList = new List<string>();
            testAnswerList.Add("blue");
            testAnswerList.Add("green");
            testAnswerList.Add("gray");
            string testCorrectAnswer = "blue";


            UIMethods.WelcomeText();
            Texts.GetQuestion();
            ObjectTest newObject = new ObjectTest();
            newObject.QuestionTest = testQuestion;
            newObject.AnswersList = testAnswerList;
            newObject.CorrectAnswers = testCorrectAnswer;

            Console.WriteLine(newObject.QuestionTest);
            foreach (string answer in newObject.AnswersList)
            {
            Console.WriteLine(answer);
            }
            Console.WriteLine(newObject.CorrectAnswers);
        }
    }
}