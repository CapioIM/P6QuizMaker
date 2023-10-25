using System.Security.Cryptography.X509Certificates;

namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            List<QuizQuestionAndAnswers> QuizList = new List<QuizQuestionAndAnswers>();

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.DisplayAskToTypeQuestionText();
                QuizQuestionAndAnswers quiz = new QuizQuestionAndAnswers();
                QuizList.Add(quiz);
                Logic.AddQuestionInput(quiz.QuestionText);

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    UIMethods.DisplayTypeAnswerText();
                    Logic.AddTextToAnswerList(quiz.AnswersList);
                    UIMethods.DisplayIsCorrectAnswerText();
                    Logic.SetCorrectAnswerIndex(quiz.CorrectAnswersIndexList, quiz.AnswersList);
                    UIMethods.DisplayAddAnswerText();
                    addMoreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.DisplayAddQuestionText();
                addQuestions = UIMethods.MakeDecision();

                foreach (var question in QuizList)
                {
                    Console.WriteLine(question.QuestionText);
                }
            }
        }
    }
}