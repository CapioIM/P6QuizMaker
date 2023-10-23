using System.Security.Cryptography.X509Certificates;

namespace P6QuizMaker
{
    internal class Program
    {

        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.PrintAskToGetQuestionForQuiz();
                QuizQuestionAndAnswers quiz = new QuizQuestionAndAnswers();
                quiz.QuestionText = Console.ReadLine();


                bool moreAnswers = true;
                while (moreAnswers)
                {
                    Console.Write("Type answer : ");
                    quiz.AnswersList.Add(Console.ReadLine());
                    Console.WriteLine("Is this correct answer ?");
                    if (UIMethods.MakeDecision() == true)
                    {
                        quiz.CorrectAnswersIndex.Add(quiz.AnswersList.Count());
                    }


                    UIMethods.PrintAddAnswer();
                    moreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.PrintAddQuestion();
                addQuestions = UIMethods.MakeDecision();
            }

        }
    }
}