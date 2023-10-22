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

            while (true)
            {
                Texts.PrintAskToGetQuestionForQuiz();
                QuizQuestionAndAnswers quiz = new QuizQuestionAndAnswers();
                quiz.QuestionTest = testQuestion;
                quiz.AnswersList = testAnswerList;
                quiz.CorrectAnswers = testCorrectAnswer;


                Console.WriteLine(quiz.QuestionTest);
                foreach (string answer in quiz.AnswersList)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine(quiz.CorrectAnswers);

                Console.WriteLine("Would you like to enter another Question ?");
                
                if (char.ToLower(Console.ReadKey().KeyChar) != 'n')
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

        }
    }
}